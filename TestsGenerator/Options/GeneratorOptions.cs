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
        public GeneratorOptions(int maxReadCoount, int maxProcessCount, int maxWriteCount)
        {
            this.maxReadCoount = maxReadCoount;
            this.maxProcessCount = maxProcessCount;
            this.maxWriteCount = maxWriteCount;
        }

     

    }
}
