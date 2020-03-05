

using System;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public class OverwriteDumpOption : Option
    {
        public override int Order => 140;
        public override string Name => "Overwrite Existing Dump";
        public override string Description => "Overwrite an existing dump file.";
        public override string GetArguments()
        {
            return "-o";
        }

        public override Type GroupType => typeof(DumpTypeGroup);
    }
}