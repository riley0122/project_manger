namespace ProjectManager;

static class Args {
    static List<List<string>>? args_g;

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

        args_g = a;
        return a;
    }

    public static bool HasArg(string name, List<List<string>>? args)
    {
        args ??= args_g;

        foreach (List<string> arg in args)
        {
            if (arg[0] == name) return true;
        }
        return false;
    }

    public static string GetArg(string name, List<List<string>>? args)
    {
        args ??= args_g;

        foreach (List<string> arg in args)
        {
            if (arg[0] == name) return arg[1];
        }
        throw new Exception();
    }
}