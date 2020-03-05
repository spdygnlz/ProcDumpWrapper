

namespace ProcDumpWrapper
{
    public class InvokeMinidumpCallbackOfDllOption : Option
    {
        public override int Order => 130;
        public override string Name => "Invoke Minidump Callback";
        public override string Description => "Invoke the minidump callback routine named MiniDumpCallbackRoutine of the specified DLL.";

        private string _callbackDll;

        public string CallbackDll
        {
            get => _callbackDll;
            set
            {
                if (_callbackDll != value)
                {
                    _callbackDll = value;
                    OnOptionsChanged(_callbackDll);
                }
            }
        }

        public override string GetArguments()
        {
            return $"-d {CallbackDll}";
        }
    }
}