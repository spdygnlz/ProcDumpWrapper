

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class CallbackDumpOption : Option
    {
        public override int Order => 3;
        public override string Name => "Create Callback Dump";
        public override string Description => "Write a Callback dump file. Include memory defined by the MiniDumpWriteDump callback routine named MiniDumpCallbackRoutine of the specified DLL.";

        private string _dllName;

        public string DllName
        {
            get => _dllName;
            set
            {
                if (_dllName != value)
                {
                    _dllName = value;
                    OnOptionsChanged(_dllName);
                }
            }
        }


        public override string GetArguments()
        {
            return $"-md {DllName}";
        }

        public override List<Type> ConflictingTypes => new List<Type>()
        {
            typeof(MiniDumpOption),
            typeof(CompactedFullDumpOption),
            typeof(CustomDumpOption),
            typeof(FullDumpOption),
            typeof(KernelDumpOption),
            typeof(UninstallOption),
        };

    }
}