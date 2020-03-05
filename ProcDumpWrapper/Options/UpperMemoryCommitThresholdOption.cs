

using System;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class UpperMemoryCommitThresholdOption : Option
    {
        public override int Order => 110;
        public override string Name => "Upper Memory Commit Threshold";
        public override string Description => "Memory commit threshold in MB at which to create a dump.";

        private string _threshold;

        public string Threshold
        {
            get => _threshold;
            set
            {
                if (_threshold != value)
                {
                    _threshold = value;
                    OnOptionsChanged(_threshold);
                }
            }
        }

        public override Type GroupType => typeof(ThresholdGroup);

        public override string GetArguments()
        {
            return $"-m {Threshold}";
        }
    }
}