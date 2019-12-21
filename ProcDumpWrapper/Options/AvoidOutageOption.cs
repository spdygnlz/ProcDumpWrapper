

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class AvoidOutageOption : Option
    {
        public override int Order => 1;
        public override string Name => "Avoid Outage";

        public override string Description 
        { 
            get => "Avoid outage. If the trigger will cause the target to suspend for a prolonged time due to an exceeded concurrent dump limit, the trigger will be skipped."; 
        }

        public override string GetArguments()
        {
            return "-a -r";
        }

    }
}