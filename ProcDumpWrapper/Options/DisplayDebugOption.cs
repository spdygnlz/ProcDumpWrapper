

namespace ProcDumpWrapper
{
    public class DisplayDebugOption : Option
    {
        public override int Order => 100;
        public override string Name => "Display Debug Logging";
        public override string Description => "Display the debug logging of the process.";
        public override string GetArguments()
        {
            return "-l";
        }
    }
}