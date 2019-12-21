

namespace ProcDumpWrapper
{
    public class LowerMemoryCommitThresholdOption : Option
    {
        public override int Order => 111;
        public override string Name => "Lower Memory Commit Threshold";
        public override string Description => "Trigger when memory commit drops below specified MB value.";

        public int Threshold { get; set; }
        public override string GetArguments()
        {
            return $"-ml {Threshold}";
        }
    }
}