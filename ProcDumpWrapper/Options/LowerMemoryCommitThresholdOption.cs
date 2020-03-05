

using System;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class LowerMemoryCommitThresholdOption : Option
    {
        public override int Order => 111;
        public override string Name => "Lower Memory Commit Threshold";
        public override string Description => "Trigger when memory commit drops below specified MB value.";

        private int _threshold;

        public int Threshold
        {
            get => _threshold;
            set
            {
                if (_threshold != value)
                {
                    _threshold = value;
                    OnOptionsChanged(_threshold.ToString());
                }
            }
        }

        public override Type GroupType => typeof(ThresholdGroup);

        public override string GetArguments()
        {
            return $"-ml {Threshold}";
        }
    }
}