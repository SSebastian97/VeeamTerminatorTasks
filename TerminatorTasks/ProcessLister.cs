using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminatorTasks
{
    internal class ProcessLister
    {
        public Process[] ListAll()
        {
            return Process.GetProcesses();
        }
    }
}
