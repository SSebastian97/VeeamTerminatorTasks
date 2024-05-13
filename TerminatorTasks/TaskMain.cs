using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminatorTasks
{
    public class TaskMain
    {
        
        
        static  async Task Main(string[] args)
        {
            var processLister = new ProcessLister();
            var message = new Message();
            var processManager = new ProcessManager(processLister, message);

            foreach (Process process in processLister.ListAll()) //List all the processes from which we can choose
            {
                Console.WriteLine(process.ProcessName);
            }
            

            await processManager.CheckAndKill();
        
            

            
        }
    }
}
