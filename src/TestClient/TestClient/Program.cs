using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using CalcServer.Client;
using CalcServer.Contracts;

namespace TestClient
{
    class Program
    {
        static Random rand = new Random();
        static ManualResetEvent mre = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            List<XmlTestData> tests = new List<XmlTestData>()
            {
                new XmlTestData(){ ClassName = "CalcServer.Toolboxes.MathToolbox", ClassVersion = "1.0.0.0", FunctionName = "MinMax", DataToProcess = GenerateRandomNumbersList(5, 100) },
                new XmlTestData(){ ClassName = "CalcServer.Toolboxes.MathToolbox", ClassVersion = "1.0.0.0", FunctionName = "MinMaxIdx", DataToProcess = GenerateRandomNumbersList(5, 100) },
                new XmlTestData(){ ClassName = "CalcServer.Toolboxes.StatisticsToolbox", ClassVersion = "1.0.0.0", FunctionName = "MeanStdDev", DataToProcess = GenerateRandomNumbersList(5, 100) },
                new XmlTestData(){ ClassName = "CalcServer.Toolboxes.StatisticsToolbox", ClassVersion = "1.0.0.0", FunctionName = "WordsCount", DataToProcess = "a test string"}
            };

            for (int i = 0; i < tests.Count; i++)
            {
                string taskDataStr = tests[i].ToString();
                Console.WriteLine(taskDataStr);

                new Thread(() =>
                {
                    string taskDataName = string.Format("TaskData-{0}", i);

                    Console.WriteLine(Environment.NewLine + taskDataName);

                    TaskExecution te = new TaskExecution("http://localhost:9001/ProcessingService/", TimeSpan.FromSeconds(1));
                    te.OnTaskExecutionCompleted += new TaskExecutionCompletedHandler(te_OnTaskExecutionCompleted);
                    te.OnTaskExecutionProgress += new TaskExecutionProgressHandler(te_OnTaskExecutionProgress);

                    te.SetTaskData(taskDataName, taskDataStr);
                    te.Start();
                }
                ) { IsBackground = true }.Start();

                mre.WaitOne();

                Thread.Sleep(2000);
                Console.WriteLine(Environment.NewLine + "==========" + Environment.NewLine);

                mre.Reset();
            }

            Console.WriteLine("Premere <Invio> per terminare l'applicazione...");
            Console.ReadLine();
        }

        private static void te_OnTaskExecutionCompleted(object sender, TaskExecutionCompletedEventArgs e)
        {
            string result = string.Empty;
            string report = string.Empty;

            if (e.Cancelled)
            {
                report = string.Format("Annullato (task id = {0}).", e.Id);
            }
            else if (e.Error != null)
            {
                report = string.Format("Errore (task id = {0}).", e.Id) + e.Error.Message;
            }
            else
            {
                TaskResults tr = e.Result;
                report = string.Format("Completato (task id = {0}) in {1} con {2} errori.",
                    e.Id, tr.ElapsedTime, tr.EncounteredErrors.Length);

                result = string.Format("Risultati (task id = {0}).", e.Id) + Environment.NewLine + tr.Contents;
            }

            Console.WriteLine(report);
            Console.WriteLine("result: " + result);

            mre.Set();
        }

        private static void te_OnTaskExecutionProgress(object sender, TaskExecutionProgressEventArgs e)
        {
            string report = string.Empty;

            report += DateTime.Now + ": ";
            report += "[";
            report += string.Format("Stato (task id = {0}): {1}.", e.Id, e.State.ToString());
            /*if (e.Error != null)
            {
                text += "(";
                text += "Errore. " + e.Error.Message;
                text += ")";
            }*/
            report += "]";
            report += Environment.NewLine;

            Console.WriteLine(report);
        }

        private static string GenerateRandomNumbersList(int count, int max)
        {
            int[] numbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                numbers[i] = rand.Next(max);
            }

            return string.Join<int>(" ", numbers);
        }
    }
}
