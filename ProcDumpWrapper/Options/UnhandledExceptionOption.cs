

namespace ProcDumpWrapper
{
    public class UnhandledExceptionOption : Option
    {
        public override int Order => 30;
        public override string Name => "Unhandled Exception";
        public override string Description => "Write a dump when the process encounters an unhandled exception. Include the 1 to create dump on first chance exceptions.";

        public UnhandledExceptionOption()
        {
            Enabled = true;
        }

        public override string GetArguments()
        {
            return "-e 1";
        }
    }

}