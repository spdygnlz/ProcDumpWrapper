

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class CallbackDumpOption : Option
    {
        public override int Order => 3;
        public override string Name => "Create Callback Dump";
        public override string Description => "Write a Callback dump file. Include memory defined by the MiniDumpWriteDump callback routine named MiniDumpCallbackRoutine of the specified DLL.";

        public string DllName { get; set; }
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