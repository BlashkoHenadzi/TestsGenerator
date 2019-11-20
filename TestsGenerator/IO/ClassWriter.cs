using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator.IO
{
    public class ClassWriter
    {
        private readonly string path;

        public ClassWriter(string path)
        {
            this.path = path;
        }

        private   void CheckDirectory()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);//TODO:cath exceprions;

        }

        public  async Task Write( List<ClassInfo> generatedClasses)
        {
            CheckDirectory();
            foreach (ClassInfo classInfo in generatedClasses)
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(path, "\\", classInfo.name)))
                {
                    await writer.WriteAsync(classInfo.Body);
                }
            }

        }
        
    }
}
