

using System;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class NumberOfDropsOption : Option
    {
        public override int Order => 130;
        public override string Name => "Exit after # of Drops";
        public override string Description => "Number of dumps to write before exiting.";
        private int _drops;

        public int Drops
        {
            get => _drops;
            set
            {
                if (_drops != value)
                {
                    _drops = value;
                    OnOptionsChanged(_drops.ToString());
                }
            }
        }

        public override Type GroupType => typeof(DumpTypeGroup);

        public override string GetArguments()
        {
            return $"-n {Drops}";
        }
    }
}