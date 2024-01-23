namespace Clothick.Infrastructure.Services;

public static class DirectoryHelper
{
    public static void EnsureDirectoryExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Console.WriteLine($"Directory created: {path}");
        }
    }
}