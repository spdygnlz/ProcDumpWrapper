

namespace ProcDumpWrapper
{
    public class KillWhenFinishedOption : Option
    {
        public override int Order => 90;
        public override string Name => "Kill Process When Finished";
        public override string Description => "Kill the process after cloning (-r), or at the end of dump collection";
        public override string GetArguments()
        {
            return "-k";
        }
    }
}