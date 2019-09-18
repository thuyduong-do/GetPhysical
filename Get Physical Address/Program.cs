using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Physical_Address
{
    class Program
    {
        static void Main(string[] args)
        {
            Process Netprocess = new Process();
            Netprocess.StartInfo.FileName = "ipconfig.exe";
            Netprocess.StartInfo.Arguments = "/all";
            Netprocess.StartInfo.UseShellExecute = false;
            Netprocess.StartInfo.RedirectStandardOutput = true;
            Netprocess.StartInfo.CreateNoWindow = true;
            Netprocess.Start();

            string results = Netprocess.StandardOutput.ReadToEnd();
            Netprocess.WaitForExit();
            Console.WriteLine(results);
            
           

            string[] lines = results.Split(new string[] { Environment.NewLine },  //tao array string , cat ghep de lay tung dong 1
                             StringSplitOptions.RemoveEmptyEntries);              // bo qua dong nao k co character gi
            var GetPhysical = from line in lines
                              let PAdd = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              where PAdd.Contains("Physical Address")
                              //select new 


            ////______________________NET STAT_____________________________________
            // var networkConnection = from line in lines
            //                         let cols = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //                         where cols.Count() == 5 
            //                         select new { A = cols[0], B = cols[1], C = cols[2], PID = cols[4] };
            //// var getPhysicalAddress = networkConnection.Select(PA => ) 


            //foreach (var line in networkConnection)
            //{
            //    Console.WriteLine(line);
            //}
            //___________________________________________________________________________
            Console.ReadLine();


        }
    }
}
