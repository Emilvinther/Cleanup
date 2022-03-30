using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Cleanup;

namespace WMIApp
{
    class Program
    {
        static Management management = new Management();
        static void Main(string[] args)
        {
            Console.WriteLine(management.GetDiskMetaData());
            Console.WriteLine(management.GetHardDiskSerialNumber());
            Console.WriteLine(management.Search());
            Console.WriteLine(management.HovedLager());
            Console.WriteLine(management.Test());
            Console.WriteLine(management.TestHest());
            management.PopulateDisk();
            Console.WriteLine("process søgning");
            Console.WriteLine(management.LISTAllServices());
            Console.ReadKey();

        } //Slut main

        

        
  
        
    }
}
