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
                using (FileStream writer = new FileStream(Path.Combine(path, classInfo.name+".cs"),FileMode.Create,FileAccess.Write))
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(classInfo.Body);
                    await writer.WriteAsync(bytes, 0,bytes.Length);
                }
            }
        }
    }
}
