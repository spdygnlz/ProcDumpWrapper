

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class AvoidOutageAtOption :  Option
    {
        int Timeout { get; set; }

        public override int Order => 5;

        public override string Name => "Avoid outage at...";
        public override string Description => "Avoid outage at Timeout. Cancel the trigger's collection at N seconds.";

        public override string GetArguments()
        {
            return $"-at {Timeout}";
        }

    }
}