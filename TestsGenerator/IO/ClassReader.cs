using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator.IO
{
    public class ClassReader
    {
        


        public static async Task<string> Read(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return await reader.ReadToEndAsync();
            }

        }
    }
}
