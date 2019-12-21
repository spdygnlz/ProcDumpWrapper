

namespace ProcDumpWrapper
{
    public class LaunchProcessOption : Option
    {
        public override int Order => 220;
        public override string Name => "Launch Process with Args";
        public override string Description => "Launch the specified image with optional arguments. If it is a Store Application or Package, ProcDump will start on the next activation (only).";

        public string Arguments { get; set; }


        public override string GetArguments()
        {
            return $"-x {Arguments}";
        }
    }
}