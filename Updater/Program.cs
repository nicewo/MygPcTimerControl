using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;

namespace Updater
{
    internal class Program
    {
        static void Main()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string selfExe = "updater.exe";

            string zipPath = Directory.GetFiles(dir, "*.zip").FirstOrDefault();
            if (zipPath == null)
            {
                Console.WriteLine("Zip bulunamadı.");
                return;
            }

            Thread.Sleep(3000); // Ana uygulama tamamen kapansın

            try
            {
                using var archive = ZipFile.OpenRead(zipPath);
                foreach (var entry in archive.Entries)
                {
                    string fileName = Path.GetFileName(entry.FullName);
                    if (fileName.Equals(selfExe, StringComparison.OrdinalIgnoreCase)) continue;

                    string targetPath = Path.Combine(dir, entry.FullName);
                    if (!string.IsNullOrEmpty(entry.Name))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(targetPath)!);
                        entry.ExtractToFile(targetPath, true);
                    }
                }

                File.Delete(zipPath);

                string exePath = Path.Combine(dir, "MyGPcTimerControl.exe");
                if (File.Exists(exePath))
                    Process.Start(exePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Güncelleme hatası: " + ex.Message);
                Thread.Sleep(5000);
            }
        }
    }
}
