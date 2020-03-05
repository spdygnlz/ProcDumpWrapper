

using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ProcDumpWrapper
{
    public class AvoidOutageAtOption :  Option
    {
        private int _timeout;

        public int Timeout
        {
            get => _timeout;
            set
            {
                if (_timeout != value)
                {
                    _timeout = value;
                    OnOptionsChanged(_timeout.ToString());
                }
            }
        }

        public override int Order => 5;

        public override string Name => "Avoid outage at...";
        public override string Description => "Avoid outage at Timeout. Cancel the trigger's collection at N seconds.";

        public override string GetArguments()
        {
            return $"-at {Timeout}";
        }

    }
}