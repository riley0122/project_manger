namespace ProjectManager;

static class ProjectDirectory {
    private static readonly string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    public static readonly string path = System.IO.Path.Combine(home, "projects");
    public static readonly string config_file_path = System.IO.Path.Combine(path, ".projectmanager.xml");

    static void Create() {
        Console.WriteLine("Creating directory {0}", path);
        Directory.CreateDirectory(path);
        string default_config = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?>"
                            + "\n<config>"
                            + "\n\t<defaultEditor>code</defaultEditor>"
                            + "\n</config>";
        File.WriteAllText(config_file_path, default_config);

        return;
    }

    public static bool Verify()
    {
        if (File.Exists(config_file_path)) return true;

        if (Directory.Exists(path))
        {
            // Directory exists but not config file: Dont create it as there might be something there
            Console.WriteLine("{0} Is an existing directory, but there is no config file there.\nPress any key to exit...", path);
            Console.ReadKey();
            return false;
        } else Create();

        return true;
    }
}
