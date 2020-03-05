
using System;
using System.Collections.Generic;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class CPUMinThresholdOption : Option
    {
        public override int Order => 25;
        public override string Name => "CPU Min Threshold";
        public override string Description => "CPU threshold below which to create a dump of the process.";

        private int _cpuThreshold;

        public int CPUThreshold
        {
            get => _cpuThreshold;
            set
            {
                if (_cpuThreshold != value)
                {
                    _cpuThreshold = value;
                    OnOptionsChanged(_cpuThreshold.ToString());
                }
            }
        }

        public override Type GroupType => typeof(ThresholdGroup);

        public override string GetArguments()
        {
            return $"-cl {CPUThreshold}";
        }

    }
}