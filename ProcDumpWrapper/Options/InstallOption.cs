

using System;
using System.Collections.Generic;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class InstallOption : Option
    {
        public override int Order => 80;
        public override string Name => "Install as JIT";
        public override string Description => "Install ProcDump as the AeDebug postmortem debugger. Only -ma, -mp, -d and -r are supported as additional options.";

        private string _dumpFolder;

        public string DumpFolder
        {
            get => _dumpFolder;
            set
            {
                if (_dumpFolder != value)
                {
                    _dumpFolder = value;
                    OnOptionsChanged(_dumpFolder);
                }
            }
        }

        public override Type GroupType => typeof(JITGroup);

        public override string GetArguments()
        {
            return "-i";
        }
        public override List<Type> ConflictingTypes => new List<Type>()
        {
            typeof(AvoidOutageAtOption),
            typeof(AvoidOutageOption),
            typeof(BreakpointsAsExceptionsOption),
            typeof(CPUMinThresholdOption),
            typeof(CPUMaxThresholdOption),
            typeof(DelayOption),
            typeof(DisplayDebugOption),
            typeof(FilterExcludeExceptionsOption),
            typeof(FilterIncludeExceptionsOption),
            typeof(HungWindowOption),
            typeof(InvokeMinidumpCallbackOfDllOption),
            typeof(LaunchProcessOption),
            typeof(LowerMemoryCommitThresholdOption),
            typeof(NativeDebuggerOption),
            typeof(NumberOfDropsOption),
            typeof(OverwriteDumpOption),
            typeof(PerformanceCounterAboveOption),
            typeof(PerformanceCounterBelowOption),
            typeof(TerminateOption),
            typeof(UnhandledExceptionOption),
            typeof(UpperMemoryCommitThresholdOption),
            typeof(WaitForProcessStartOption),
            typeof(UninstallOption),
        };
    }
}