using ConsoleApp1.LoggerService;
using MetroLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LogerService.Instance.WriteToLog<Program>("Hello Logger", LogLevel.Info, new NullReferenceException());
            Console.WriteLine("Pfgbcm cltkfyf");
        }
    }
}
