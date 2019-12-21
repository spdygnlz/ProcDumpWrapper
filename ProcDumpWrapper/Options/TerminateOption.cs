

namespace ProcDumpWrapper
{
    public class TerminateOption : Option
    {
        public override int Order => 190;
        public override string Name => "Dump on Termination";
        public override string Description => "Write a dump when the process terminates.";
        public override string GetArguments()
        {
            return "-t";
        }
    }
}