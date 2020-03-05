

using System;
using System.Collections.Generic;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class CPUMaxThresholdOption : Option
    {
        public override int Order => 20;
        public override string Name => "CPU Max Threshold";
        public override string Description => "CPU threshold at which to create a dump of the process.";

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
            return $"-c {CPUThreshold}";
        }

    }
}