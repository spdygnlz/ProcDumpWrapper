

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class FullDumpOption : Option
    {
        public override int Order => 1;
        public override string Name => "Create Full Dump";
        public override string Description => "Write a dump file with all process memory. The default dump format only includes thread and handle information.";
        public override string GetArguments()
        {
            return "-ma";
        }
        public override List<Type> ConflictingTypes => new List<Type>()
        {
            typeof(CallbackDumpOption),
            typeof(CompactedFullDumpOption),
            typeof(MiniDumpOption),
            typeof(CustomDumpOption),
            typeof(KernelDumpOption),
            typeof(UninstallOption),
        };
    }
}