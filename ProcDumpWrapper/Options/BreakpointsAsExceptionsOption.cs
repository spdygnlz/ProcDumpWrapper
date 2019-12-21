

using System;
using System.Collections.Generic;

namespace ProcDumpWrapper
{
    public class BreakpointsAsExceptionsOption : Option
    {
        public override int Order => 10;
        public override string Name => "Breakpoints as Exceptions";
        public override string Description => "Treat debug breakpoints as exception (otherwise ignore them).";

        public override string GetArguments()
        {
            return "-b";
        }
    }
}