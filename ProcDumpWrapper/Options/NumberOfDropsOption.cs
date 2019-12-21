

namespace ProcDumpWrapper
{
    public class NumberOfDropsOption : Option
    {
        public override int Order => 130;
        public override string Name => "Exit after # of Drops";
        public override string Description => "Number of dumps to write before exiting.";
        public int Drops { get; set; }
        public override string GetArguments()
        {
            return $"-n {Drops}";
        }
    }
}