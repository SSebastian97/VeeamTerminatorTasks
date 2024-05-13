using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace TerminatorTasks
{
    public class Message
    {
       
        public string EnterTaskName()//Process search
        {
            Console.WriteLine("Please enter Task name");    
            return Console.ReadLine();

        }
        public int EnterLifeTime()//Lifetime set
        {
            Console.WriteLine("Please enter the lifetime in seconds:");
            string input = Console.ReadLine();
            double seconds;
            double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out seconds);
            return (int)Math.Truncate(seconds * 1000);
        }

        public int RefreshFreq()//Frequency search
        {
            Console.WriteLine("Please set the refresh frequency in seconds:");
            string input = Console.ReadLine();
            int freq;
            int.TryParse(input, out freq);
            return freq;
        }

    }
}
