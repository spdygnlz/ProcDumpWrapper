

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class CustomDumpOption : Option
    {
        public override int Order => 2;
        public override string Name => "Create Custom Dump";
        public override string Description => "Write a custom dump file. Include memory defined by the specified MINIDUMP_TYPE mask (Hex).";

        public string MINIDUMP_TYPE { get; set; }
        public override string GetArguments()
        {
            return $"-mc {MINIDUMP_TYPE}";
        }

        public override List<Type> ConflictingTypes => new List<Type>()
        {
            typeof(CallbackDumpOption),
            typeof(CompactedFullDumpOption),
            typeof(MiniDumpOption),
            typeof(FullDumpOption),
            typeof(KernelDumpOption),
            typeof(UninstallOption),
        };
    }
}