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
        private static  void CheckDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);//TODO:cath exceprions;

        }

        public static async Task Write(string path, List<ClassInfo> generatedClasses)
        {
            CheckDirectory(path);
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
