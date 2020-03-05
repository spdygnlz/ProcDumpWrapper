

using System;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class PerformanceCounterAboveOption : Option
    {
        public override int Order => 140;
        public override string Name => "Trigger on Performance Counter (Above)";
        public override string Description => "Trigger on the specified performance counter when the threshold is exceeded. Note: to specify a process counter when there are multiple instances of the process running, use the process ID with the following syntax: \"\\Process(<name>_<pid>)\\counter\"";
        private string _counterArgs;

        public string CounterArgs
        {
            get => _counterArgs;
            set
            {
                if (_counterArgs != value)
                {
                    _counterArgs = value;
                    OnOptionsChanged(_counterArgs);
                }
            }
        }

        public override Type GroupType => typeof(ThresholdGroup);

        public override string GetArguments()
        {
            return $"-p {CounterArgs}";
        }
    }
}