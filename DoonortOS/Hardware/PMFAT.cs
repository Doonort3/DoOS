
using System;
using System.IO;
using Doos_cli.Core;
using FS = Cosmos.System.FileSystem;

namespace Doos_cli.Hardware
{
    public static class PMFAT {

    public static string CurrentDirectory = @"0:\";
    // device
    public static FS.CosmosVFS device;

    // init
    public static void Initialize()
    {
        try
        {
            device = new FS.CosmosVFS();
            FS.VFS.VFSManager.RegisterVFS(device);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            CLI_lite.InitializeLite();
            throw;
        }
        // init
        
            // Kernel.INIT();
            // return true;
    }
    public static bool FileExists(string file) { return File.Exists(file); }
    public static bool FolderExists(string path) { return Directory.Exists(path); }
    }
}
