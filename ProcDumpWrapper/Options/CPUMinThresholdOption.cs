
using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class CPUMinThresholdOption : Option
    {
        public override int Order => 25;
        public override string Name => "CPU Min Threshold";
        public override string Description => "CPU threshold below which to create a dump of the process.";

        public int CPUThreshold { get; set; }

        public override string GetArguments()
        {
            return $"-cl {CPUThreshold}";
        }

    }
}