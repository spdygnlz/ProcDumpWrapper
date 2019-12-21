

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class CompactedFullDumpOption : Option
    {
        public override int Order => 7;
        public override string Name => "Create Compacted Full Dump";
        public override string Description => "Write a dump file with thread and handle information, and all read/write process memory. To minimize dump size, memory areas larger than 512MB are searched for, and if found, the largest area is excluded. A memory area is the collection of same sized memory allocation areas. The removal of this (cache) memory reduces Exchange and SQL Server dumps by over 90%.";
        public override string GetArguments()
        {
            return "-mp";
        }

        public override List<Type> ConflictingTypes => new List<Type>()
        {
            typeof(CallbackDumpOption),
            typeof(MiniDumpOption),
            typeof(CustomDumpOption),
            typeof(FullDumpOption),
            typeof(KernelDumpOption),
            typeof(UninstallOption),
        };
    }
}