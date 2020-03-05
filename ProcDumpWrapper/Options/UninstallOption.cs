

using System;
using System.Collections.Generic;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class UninstallOption : Option
    {
        public override int Order => 200;
        public override string Name => "Uninstall as JIT Debugger";
        public override string Description => "Uninstalls ProcDump as the postmortem debugger.";
        public override string GetArguments()
        {
            return "-u";
        }

        public override Type GroupType => typeof(JITGroup);

        public override List<Type> ConflictingTypes => new List<Type>()
        {
            typeof(AvoidOutageAtOption),
            typeof(AvoidOutageOption),
            typeof(BreakpointsAsExceptionsOption),
            typeof(CallbackDumpOption),
            typeof(CloneOption),
            typeof(CompactedFullDumpOption),
            typeof(CPUMinThresholdOption),
            typeof(CPUMaxThresholdOption),
            typeof(CustomDumpOption),
            typeof(DelayOption),
            typeof(DisplayDebugOption),
            typeof(FilterExcludeExceptionsOption),
            typeof(FilterIncludeExceptionsOption),
            typeof(FullDumpOption),
            typeof(HungWindowOption),
            typeof(InstallOption),
            typeof(InvokeMinidumpCallbackOfDllOption),
            typeof(KernelDumpOption),
            typeof(KillWhenFinishedOption),
            typeof(LaunchProcessOption),
            typeof(LowerMemoryCommitThresholdOption),
            typeof(MiniDumpOption),
            typeof(NativeDebuggerOption),
            typeof(NumberOfDropsOption),
            typeof(OverwriteDumpOption),
            typeof(PerformanceCounterAboveOption),
            typeof(PerformanceCounterBelowOption),
            typeof(TerminateOption),
            typeof(UnhandledExceptionOption),
            typeof(UpperMemoryCommitThresholdOption),
            typeof(WaitForProcessStartOption),
        };
    }
}