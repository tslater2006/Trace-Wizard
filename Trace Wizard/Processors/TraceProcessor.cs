using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraceWizard.Data;

namespace TraceWizard.Processors
{
    public class TraceProcessor : BackgroundWorker
    {
        string _file;
        private TraceData Data = new TraceData();

        public TraceProcessor(string filename)
        {
            _file = filename;
            this.DoWork += TraceProcessor_DoWork;
        }

        private void TraceProcessor_DoWork(object sender, DoWorkEventArgs e)
        {
            var lineCount = File.ReadLines(_file).Count();

            List<ITraceProcessor> Processors = new List<ITraceProcessor>();
            Processors.Add(new SQLProcessor());
            Processors.Add(new StackTraceProcessor());

            /* NOTE: This one is purposefully last because it relies on SQL and StackTrace data in post process */
            Processors.Add(new ExecutionPathProcessor());
            foreach (ITraceProcessor proc in Processors)
            {
                proc.ProcessorInit(Data);
            }
            long lineNumber = 0;
            using (StreamReader sr = new StreamReader(_file))
            {
                while (sr.EndOfStream == false)
                {
                    if (this.WorkerSupportsCancellation && this.CancellationPending)
                    {
                        e.Result = null;
                        e.Cancel = true;
                        return;
                    }
                    string line = sr.ReadLine();
                    lineNumber++;
                    if (this.WorkerReportsProgress)
                    {
                        this.ReportProgress((int)(((double)lineNumber / (double)lineCount) * 100));
                    }
                    foreach (ITraceProcessor proc in Processors)
                    {
                        proc.ProcessLine(line, lineNumber);

                    }                    
                }
            }

            foreach (ITraceProcessor proc in Processors)
            {
                proc.ProcessorComplete(Data);
            }
            for (var x = 0; x < Processors.Count; x++ ) {
                Processors[x] = null;
            }
            Processors = null;
            //exec.ResolveSQLStatements(sql);
            System.GC.Collect();
            e.Result = Data;
        }
    }

}
