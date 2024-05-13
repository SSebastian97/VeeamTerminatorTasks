using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TerminatorTasks
{
    class ProcessManager
    {
        //I've used readonly because I've seen that it's good practice while using threads 
        private readonly ProcessLister processLister; 
        private readonly Message message;

        public ProcessManager(ProcessLister processLister, Message message)
        {
            this.processLister = processLister;
            this.message = message;
        }

        public async Task CheckAndKill()    //method which we can use to check and destroy the processes
        {
            var processes = processLister.ListAll();
            int lifeTime=message.EnterLifeTime(); 
            var processName = message.EnterTaskName();
            var refresh= message.RefreshFreq();
            
           
            await IsAlive(processName,refresh,lifeTime);

        }

            public async Task IsAlive(string name, int refreshFreq, int lifetime)
        {
            bool exitLoop = false;

            while (!exitLoop)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                    if (keyInfo.Key == ConsoleKey.Q)
                    {
                        exitLoop = true;

                        Console.WriteLine("Exiting the loop.");
                        break;
                    }
                }

                var processes = Process.GetProcessesByName(name);

                if (processes.Length == 0)//check if there exists any of the wanted processes
                {
                    Console.WriteLine($"The process '{name}' doesn't exist.");
                }
                else
                {
                    Console.WriteLine($"The process '{name}' you're looking for exists.");
                    Thread.Sleep(lifetime);

                    foreach (Process process in processes)
                    {
                        process.Kill();
                        break;
                    }
                }

                // Wait for the specified frequency
                await Task.Delay(refreshFreq * 1000);
            }
        }
        


    }

 
    }

