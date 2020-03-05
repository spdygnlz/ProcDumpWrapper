
namespace ProcDumpWrapper
{
    public class WaitForProcessStartOption : Option
    {
        public override int Order => 210;
        public override string Name => "Wait for Process Start";
        public override string Description => "Wait for the specified process to launch if it's not running. Can be a Process name, Service name, or PID.";

        private string _processName;

        public string ProcessName
        {
            get => _processName;
            set
            {
                if (_processName != value)
                {
                    _processName = value;
                    OnOptionsChanged(_processName);
                }
            }
        }

        public WaitForProcessStartOption()
        {
            Enabled = true;
        }

        public override string GetArguments()
        {
            return $"-w {ProcessName}";
        }
    }
}