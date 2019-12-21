

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class CPUMaxThresholdOption : Option
    {
        public override int Order => 20;
        public override string Name => "CPU Max Threshold";
        public override string Description => "CPU threshold at which to create a dump of the process.";

        public int CPUThreshold { get; set; }

        public override string GetArguments()
        {
            return $"-c {CPUThreshold}";
        }

    }
}