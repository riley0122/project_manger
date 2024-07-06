using System.Xml;
using System.Collections.Generic;

namespace ProjectManager;

class Program
{
    public static List<List<string>>? args_g;

    public static List<List<string>> ParseArgs(string[] args)
    {
        List<List<string>> a = new List<List<string>>();
        for (int i = 0; i < args.Length; i++)
        {
            if (!args[i].StartsWith("--")) continue;

            if (args[i].Contains("="))
            {
                string current = args[i].Replace("\\\\", "🃏");
                current = current.Replace("\\=", "🂡");

                string[] split = args[i].Split("=");

                string name = split[0];
                name = name.Substring(2);
                name = name.Replace("🃏", "\\");
                name = name.Replace("🂡", "=");

                string value = split[1];
                value = value.Replace("🃏", "\\");
                value = value.Replace("🂡", "=");

                a.Add(new List<string> { name, value });
            } else
            {
                string name = args[i];
                name = name.Substring(2);

                a.Add(new List<string> { name, "set" });
            }
        }

        return a;
    }

    public static bool HasArg(List<List<string>> args, string name)
    {
        foreach (List<string> arg in args)
        {
            if (arg[0] == name) return true;
        }
        return false;
    }

    public static string GetArg(List<List<string>> args, string name)
    {
        foreach (List<string> arg in args)
        {
            if (arg[0] == name) return arg[1];
        }
        throw new Exception();
    }

    public static void Main(string[] args)
    {
        args_g = ParseArgs(args);

        string home_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string projects_path = System.IO.Path.Combine(home_path, "projects");
        string config_file_path = System.IO.Path.Combine(projects_path, ".projectmanager.xml");

        if (File.Exists(config_file_path))
        {
            // Exists: Read config
            XmlDocument doc = new XmlDocument();
            doc.Load(config_file_path);
        } else if (Directory.Exists(projects_path))
        {
            // Directory exists but not config file: Dont create it as there might be something there
            Console.WriteLine("{0} Is an existing directory, but there is no config file there.\nPress any key to exit...", projects_path);
            Console.ReadKey();
            return;
        } else
        {
            Console.WriteLine("Creating directory {0}", projects_path);
            // Doesn't exist: create it
            Directory.CreateDirectory(projects_path);
            string default_config = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?>"
                                + "\n<config>"
                                + "\n\t<defaultEditor>code</defaultEditor>"
                                + "\n</config>";
            File.WriteAllText(config_file_path, default_config);
        }

        if (HasArg(args_g, "test"))
        {
            Console.WriteLine("Running tests...");
            // TODO: Write tests
            return;
        }
    }
}
