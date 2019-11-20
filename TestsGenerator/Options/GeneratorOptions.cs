using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator.Options
{
    public class GeneratorOptions
    {
        public int maxReadCoount { get; }
        public int maxProcessCount { get; }
        public int maxWriteCount { get; }
        public string Writepath { get; }
        public string Readpath { get; }
        public GeneratorOptions(int maxReadCoount, int maxProcessCount, int maxWriteCount,string writepath,string readpath)
        {
            this.maxReadCoount = maxReadCoount;
            this.maxProcessCount = maxProcessCount;
            this.maxWriteCount = maxWriteCount;
            this.Readpath = readpath;
            this.Writepath = writepath;
        }

     

    }
}
