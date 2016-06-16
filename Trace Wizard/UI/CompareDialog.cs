using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraceWizard.Data;
using TraceWizard.Data.Serialization;
using TraceWizard.Processors;

namespace TraceWizard.UI
{
    public partial class CompareDialog : Form
    {
        TraceData leftData;
        TraceData rightData;
        TraceProcessor leftProcessor;
        TraceProcessor rightProcessor;

        Dictionary<SQLStatement, TreeNode> SQLMap = new Dictionary<SQLStatement, TreeNode>();
        Dictionary<ExecutionCall, TreeNode> ExecMap = new Dictionary<ExecutionCall, TreeNode>();

        public CompareDialog(TraceData initData)
        {
            InitializeComponent();

            if (initData != null)
            {
                leftData = initData;
                UIBuilder.BuildExecutionTree(leftData, execTreeLeft, SQLMap, ExecMap, false);
            }
        }

        private void btnOpenLeft_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Trace Files|*.tracesql|Trace Wizard Files|*.twiz";
            openFileDialog1.FileName = "";
            var result = openFileDialog1.ShowDialog();

            execTreeLeft.Nodes.Clear();
            

            if (result == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                // Process the file

                if (TraceDeserializer.IsSerializedData(filename))
                {
                    if (TraceDeserializer.IsSerializedVersionSupported(filename))
                    {
                        leftData = new TraceDeserializer().DeserializeTraceData(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
                        UIBuilder.BuildExecutionTree(leftData, execTreeLeft, SQLMap, ExecMap, false);
                    }
                    else
                    {
                        MessageBox.Show("This version of Trace Wizard cannot import the serialized data, maybe it was serialized with an older version.");
                    }
                }
                else
                {
                    leftProcessor = new TraceProcessor(filename);
                    leftProcessor.WorkerReportsProgress = true;
                    leftProcessor.WorkerSupportsCancellation = true;

                    leftProcessor.ProgressChanged += ProcessorLeft_ProgressChanged;
                    leftProcessor.RunWorkerCompleted += ProcessorLeft_RunWorkerCompleted;
                    leftProcessor.RunWorkerAsync();
                }
            }
        }
        private void ProcessorLeft_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            leftProgress.Value = e.ProgressPercentage;
        }
        private void ProcessorLeft_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            leftProgress.Value = 0;
            if (e.Cancelled)
            {
                MessageBox.Show("Trace file processing cancelled.");
                System.GC.Collect();
                return;
            }

            leftData = (TraceData)e.Result;

            UIBuilder.BuildExecutionTree(leftData, execTreeLeft, SQLMap, ExecMap, false);

            System.GC.Collect();
        }

        private void btnOpenRight_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Trace Files|*.tracesql|Trace Wizard Files|*.twiz";
            openFileDialog1.FileName = "";
            var result = openFileDialog1.ShowDialog();

            execTreeLeft.Nodes.Clear();


            if (result == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                // Process the file

                if (TraceDeserializer.IsSerializedData(filename))
                {
                    if (TraceDeserializer.IsSerializedVersionSupported(filename))
                    {
                        rightData = new TraceDeserializer().DeserializeTraceData(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
                        UIBuilder.BuildExecutionTree(rightData, execTreeRight, SQLMap, ExecMap, false);
                    }
                    else
                    {
                        MessageBox.Show("This version of Trace Wizard cannot import the serialized data, maybe it was serialized with an older version.");
                    }
                }
                else
                {
                    rightProcessor = new TraceProcessor(filename);
                    rightProcessor.WorkerReportsProgress = true;
                    rightProcessor.WorkerSupportsCancellation = true;

                    rightProcessor.ProgressChanged += ProcessorRight_ProgressChanged;
                    rightProcessor.RunWorkerCompleted += ProcessorRight_RunWorkerCompleted;
                    rightProcessor.RunWorkerAsync();
                }
            }
        }
        private void ProcessorRight_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            rightProgress.Value = e.ProgressPercentage;
        }
        private void ProcessorRight_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            rightProgress.Value = 0;
            if (e.Cancelled)
            {
                MessageBox.Show("Trace file processing cancelled.");
                System.GC.Collect();
                return;
            }

            rightData = (TraceData)e.Result;

            UIBuilder.BuildExecutionTree(rightData, execTreeRight, SQLMap, ExecMap, false);

            System.GC.Collect();
        }

        private void execTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var call = e.Node.Tag as ExecutionCall;

            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text.Equals("Loading..."))
            {
                // build out nodes for call
                BuildExpandingNode(e.Node, call);
            }
        }

        private void BuildExpandingNode(TreeNode node, ExecutionCall call)
        {
            node.Nodes.Clear();
            foreach (var child in call.Children)
            {
                UIBuilder.BuildExecutionTree(node, child, SQLMap, ExecMap, false);
            }
        }

        private void btnCopyToRight_Click(object sender, EventArgs e)
        {
            rightData = leftData;
            UIBuilder.BuildExecutionTree(rightData, execTreeRight, SQLMap, ExecMap, false);
        }
    }
}
