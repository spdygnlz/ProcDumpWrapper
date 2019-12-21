

namespace ProcDumpWrapper
{
    public class NativeDebuggerOption : Option
    {
        public override int Order => 50;
        public override string Name => "Native Debugger";
        public override string Description => "Run as a native debugger in a managed process (no interop).";
        public override string GetArguments()
        {
            return "-g";
        }
    }
}