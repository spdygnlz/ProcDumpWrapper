

namespace ProcDumpWrapper
{
    public class DelayOption : Option
    {
        public override int Order => 160;
        public override string Name => "Delay Dump";
        public override string Description => "Consecutive seconds before dump is written (default is 10).";

        public int Delay { get; set; }
        public override string GetArguments()
        {
            return $"-s {Delay}";
        }
    }
}