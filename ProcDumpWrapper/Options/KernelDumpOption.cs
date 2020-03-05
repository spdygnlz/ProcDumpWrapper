

using System;
using System.Collections.Generic;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class KernelDumpOption : Option
    {
        public override int Order => 4;
        public override string Name => "Create Kernel Dump";
        public override string Description => "Also write a Kernel dump file. Includes the kernel stacks of the threads in the process. OS doesn't support a kernel dump (-mk) when using a clone (-r). When using multiple dump sizes, a kernel dump is taken for each dump size.";
        public override string GetArguments()
        {
            return "-mk";
        }

        public override Type GroupType => typeof(DumpTypeGroup);

        public override List<Type> ConflictingTypes => new List<Type>()
        {
            typeof(CallbackDumpOption),
            typeof(CompactedFullDumpOption),
            typeof(FullDumpOption),
            typeof(MiniDumpOption),
            typeof(CustomDumpOption),
            typeof(UninstallOption),
        };
    }
}