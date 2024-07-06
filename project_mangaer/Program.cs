namespace ProjectManager;

class Program
{
    public static int Main(string[] args)
    {
        Args.ParseArgs(args);

        if (!ProjectDirectory.Verify()) return 1;

        if (args.Length < 1) return 1;

        string action = args[0];

        switch (action) {
            case "new":
                // Make a new project
            break;
            case "tag":
                // Check if --add or --remove is set then check --name for the value
            break;
            case "open":
                // Open it with the set editor
            break;
            default:
                Console.WriteLine("{0} Is not a valid action!", action);
                return 1;
        }

        return 0;
    }
}
