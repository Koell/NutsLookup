using System;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace NutsLookup
{
    public class NutsService : IDisposable
    {
        private SQLiteConnection memoryConn;

        public NutsService()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = "NutsLookup.Data.nuts.db";

            using var stream = assembly.GetManifestResourceStream(resourcePath);
            if (stream == null)
                throw new FileNotFoundException("Embedded DB not found: " + resourcePath);

            var tempFile = Path.GetTempFileName();
            using (var fileStream = File.Create(tempFile))
                stream.CopyTo(fileStream);

            var diskConn = new SQLiteConnection($"Data Source={tempFile}");
            diskConn.Open();

            memoryConn = new SQLiteConnection("Data Source=:memory:");
            memoryConn.Open();

            diskConn.BackupDatabase(memoryConn, "main", "main", -1, null, 0);
            diskConn.Close();
            File.Delete(tempFile);
        }

        public string? GetNutsCode(string alpha2, string zip)
        {
            using var cmd = memoryConn.CreateCommand();
            cmd.CommandText = "SELECT nuts_3 FROM nuts WHERE alpha_2 = @alpha2 AND zip = @zip";
            cmd.Parameters.AddWithValue("@alpha2", alpha2.ToUpperInvariant());
            cmd.Parameters.AddWithValue("@zip", zip);
            var result = cmd.ExecuteScalar();
            return result?.ToString();
        }

        public void Dispose()
        {
            memoryConn?.Dispose();
        }
    }
}