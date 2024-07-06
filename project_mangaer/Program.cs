namespace ProjectManager;

class Program
{
    public static int Main(string[] args)
    {
        Args.ParseArgs(args);

        if (!ProjectDirectory.Verify()) return 1;

        if (args.Length < 1) return 1;

        return 0;
    }
}
