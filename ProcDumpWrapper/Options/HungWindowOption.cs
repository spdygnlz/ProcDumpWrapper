

namespace ProcDumpWrapper
{
    public class HungWindowOption : Option
    {
        public override int Order => 60;
        public override string Name => "Hung Window";
        public override string Description => "Write dump if process has a hung window (does not respond to window messages for at least 5 seconds).";
        public override string GetArguments()
        {
            return "-h";
        }
    }
}