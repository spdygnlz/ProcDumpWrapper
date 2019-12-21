

namespace ProcDumpWrapper
{
    public class FilterExcludeExceptionsOption : Option
    {
        public override int Order => 5;
        public override string Name => "Exception Filter (Exclude)";
        public override string Description => "Filter (exclude) on the content of exceptions and debug logging. Wildcards are supported.";
        public string Filter { get; set; }
        public override string GetArguments()
        {
            return $"-fx {Filter}";
        }
    }
}