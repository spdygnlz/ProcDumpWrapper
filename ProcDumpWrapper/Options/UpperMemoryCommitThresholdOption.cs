

namespace ProcDumpWrapper
{
    public class UpperMemoryCommitThresholdOption : Option
    {
        public override int Order => 110;
        public override string Name => "Upper Memory Commit Threshold";
        public override string Description => "Memory commit threshold in MB at which to create a dump.";

        public int Threshold { get; set; }
        public override string GetArguments()
        {
            return $"-m {Threshold}";
        }
    }
}