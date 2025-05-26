using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Updater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Eksik argüman.");
                return;
            }

            string exePath = args[0];
            string zipPath = args[1];
            string appDir = Path.GetDirectoryName(exePath);

            Thread.Sleep(3000);

            try
            {
                if (File.Exists(exePath))
                    File.Delete(exePath);

                ZipFile.ExtractToDirectory(zipPath, appDir, true);
                File.Delete(zipPath);

                Process.Start(Path.Combine(appDir, Path.GetFileName(exePath)));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Güncelleme hatası: " + ex.Message);
            }
        }
    }
}
