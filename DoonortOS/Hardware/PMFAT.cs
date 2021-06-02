using System;
using System.IO;
using Sys = Cosmos.System;


namespace doos_cli_re2.Hardware
{
    public static class PMFAT {

    public static string CurrentDirectory = @"0:\";
    public static void Initialize()
        {
            try
            {
                var fs = new Sys.FileSystem.CosmosVFS();
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[ doonort os ] - ok\n");
                Console.ResetColor();
                Console.Clear();
            }
            // unknown exception
            catch (Exception ex)
            {
                Console.WriteLine("Error intializing FAT file system!");
                Console.WriteLine("[INTERNAL] " + ex.Message);
            }
        }
    public static bool FileExists(string file) { return File.Exists(file); }
    public static bool FolderExists(string path) { return Directory.Exists(path); }
    }
}
