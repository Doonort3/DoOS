
using System.IO;
using FS = Cosmos.System.FileSystem;

namespace Doos_cli.Hardware
{
    public static class PMFAT {

    public static string CurrentDirectory = @"0:\";
    // device
    public static FS.CosmosVFS device;

    // init
    public static bool Initialize()
    {
        // init
        try
        {
            device = new FS.CosmosVFS();
            FS.VFS.VFSManager.RegisterVFS(device);
            Kernel.INIT();
            return true;
        }
        catch { return false; }
    }
    public static bool FileExists(string file) { return File.Exists(file); }
    public static bool FolderExists(string path) { return Directory.Exists(path); }
    }
}
