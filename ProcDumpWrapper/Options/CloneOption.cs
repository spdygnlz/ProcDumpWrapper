

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class CloneOption : Option
    {
        public override int Order => 150;
        public override string Name => "Dump Using Clone";
        public override string Description => "Dump using a clone. Concurrent limit is optional (default 1, max 5). CAUTION: a high concurrency value may impact system performance.";

        private string _concurrentLimit;

        public string ConcurrentLimit
        {
            get => _concurrentLimit;
            set
            {
                if (_concurrentLimit != value)
                {
                    _concurrentLimit = value;
                    OnOptionsChanged(_concurrentLimit);
                }
            }
        }
        public override string GetArguments()
        {
            return $"-r {ConcurrentLimit}";
        }
    }
}