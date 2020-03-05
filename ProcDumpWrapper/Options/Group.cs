using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcDumpWrapper.Options
{
    public interface Group
    {
        string DisplayName { get; }

        int SortOrder { get; }
    }

    public class DumpTypeGroup : Group
    {
        public string DisplayName => "Dump Details";

        public int SortOrder => 1;
    }

    public class JITGroup : Group
    {
        public string DisplayName => "JIT default application";

        public int SortOrder => 100;
    }

    public class ThresholdGroup : Group
    {
        public string DisplayName => "Threshold Triggers";
        public int SortOrder => 50;
    }

    public class MiscGroup : Group
    {
        public string DisplayName => "Misc Options";
        public int SortOrder => 1000;
    }

}
