

namespace ProcDumpWrapper
{
    public class FilterIncludeExceptionsOption : Option
    {
        public override int Order => 5;
        public override string Name => "Exception Filter (Include)";

        public override string Description =>
            "Filter the first chance exceptions. Wildcards (*) are supported. To just display the names without dumping, use a blank (\"\") filter.";

        private string _filter;

        public string Filter
        {
            get => _filter;
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    OnOptionsChanged(_filter);
                }
            }
        }

        public FilterIncludeExceptionsOption()
        {
            Enabled = true;
        }

        public override string GetArguments()
        {
            return $"-f \"{Filter}\"";
        }
    }
}