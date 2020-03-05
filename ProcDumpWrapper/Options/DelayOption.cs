

using System;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class DelayOption : Option
    {
        public override int Order => 160;
        public override string Name => "Delay Dump";
        public override string Description => "Consecutive seconds before dump is written (default is 10).";

        private int _delay;

        public int Delay
        {
            get => _delay;
            set
            {
                if (_delay != value)
                {
                    _delay = value;
                    OnOptionsChanged(_delay.ToString());
                }
            }
        }

        public override Type GroupType => typeof(DumpTypeGroup);

        public override string GetArguments()
        {
            return $"-s {Delay}";
        }
    }
}