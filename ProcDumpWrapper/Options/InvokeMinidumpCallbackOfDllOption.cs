

namespace ProcDumpWrapper
{
    public class InvokeMinidumpCallbackOfDllOption : Option
    {
        public override int Order => 130;
        public override string Name => "Invoke Minidump Callback";
        public override string Description => "Invoke the minidump callback routine named MiniDumpCallbackRoutine of the specified DLL.";

        public string CallbackDll { get; set; }

        public override string GetArguments()
        {
            return $"-d {CallbackDll}";
        }
    }
}