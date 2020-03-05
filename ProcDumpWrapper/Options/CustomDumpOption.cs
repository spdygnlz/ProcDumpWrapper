

using System;
using System.Collections.Generic;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class CustomDumpOption : Option
    {
        public override int Order => 2;
        public override string Name => "Create Custom Dump";
        public override string Description => "Write a custom dump file. Include memory defined by the specified MINIDUMP_TYPE mask (Hex).";

        private string _minidumpType;

        public string MINIDUMP_TYPE
        {
            get => _minidumpType;
            set
            {
                if (_minidumpType != value)
                {
                    _minidumpType = value;
                    OnOptionsChanged(_minidumpType);
                }
            }
        }
        public override string GetArguments()
        {
            return $"-mc {MINIDUMP_TYPE}";
        }

        public override Type GroupType => typeof(DumpTypeGroup);

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