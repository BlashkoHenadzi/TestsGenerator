using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsGenerator.Options;
using System.Threading.Tasks.Dataflow;
using TestsGenerator.IO;

namespace TestsGenerator
{
    class Generator
    {
        private readonly GeneratorOptions options;
        private readonly ClassReader reader;
        private readonly ClassWriter writer;

        public  Generator(GeneratorOptions options,ClassReader reader,ClassWriter writer)
        {
            this.options = options;
            this.reader = reader;
            this.writer = writer;
        }
        private Task<List<ClassInfo>> GenerateTestClasses(string classs)
        {
            return null;
        }
        public Task Generate(List<string> files)
        {
            ExecutionDataflowBlockOptions maxreadfiles = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = options.maxReadCoount
            };

             ExecutionDataflowBlockOptions maxprocessfiles = new ExecutionDataflowBlockOptions
            {
            MaxDegreeOfParallelism = options.maxProcessCount
            };

            ExecutionDataflowBlockOptions maxwritefiles = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = options.maxWriteCount
            };
           
            var readfiles = new TransformBlock<string, string>(
                new Func<string, Task<string>>(ClassReader.Read),
                 maxreadfiles);
            var processfiles = new TransformBlock<string, List<ClassInfo>>(
               new Func<string, Task<List<ClassInfo>>>(GenerateTestClasses),
                maxprocessfiles);
            var writesfiles = new ActionBlock<List<ClassInfo>>(
              new Action<List<ClassInfo>>((x)=>writer.Write(x).Wait()),
               maxprocessfiles);
            readfiles.LinkTo(processfiles, new DataflowLinkOptions() { PropagateCompletion = true });
            processfiles.LinkTo(writesfiles, new DataflowLinkOptions() { PropagateCompletion = true });
            foreach (var file in files)
                readfiles.Post(file);
            readfiles.Complete();
            return writesfiles.Completion;

        }         

          
        }
    }

