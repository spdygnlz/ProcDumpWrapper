using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class MiniDumpOption : Option
    {
        public override int Order => 5;
        public override string Name => "Create Mini Dump";
        public override string Description => "Write a mini dump file (default).";
        public override string GetArguments()
        {
            return "-mm";
        }

        public override List<Type> ConflictingTypes => new List<Type>()
        {
            typeof(CallbackDumpOption),
            typeof(CompactedFullDumpOption),
            typeof(CustomDumpOption),
            typeof(FullDumpOption),
            typeof(KernelDumpOption),
            typeof(UninstallOption),
        };

    }
}