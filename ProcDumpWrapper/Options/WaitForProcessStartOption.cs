
namespace ProcDumpWrapper
{
    public class WaitForProcessStartOption : Option
    {
        public override int Order => 210;
        public override string Name => "Wait for Process Start";
        public override string Description => "Wait for the specified process to launch if it's not running. Can be a Process name, Service name, or PID.";

        public string ProcessName { get; set; }
        public override string GetArguments()
        {
            return $"-w {ProcessName}";
        }
    }
}