

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class InstallOption : Option
    {
        public override int Order => 80;
        public override string Name => "Install as JIT";
        public override string Description => "Install ProcDump as the AeDebug postmortem debugger. Only -ma, -mp, -d and -r are supported as additional options.";

        public string DumpFolder { get; set; }
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
            typeof(InstallOption),
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