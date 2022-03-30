using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Cleanup
{
    public class Management
    {

        public string Test()
        {
            string temp = "";
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                temp = $"User:\t{result["RegisteredUser"]}" +
                $"\nOrg.:\t{result["Organization"]}" +
                $"\nO/S :\t{result["Name"]}";
            }

            return temp;
        }

        public string TestHest()
        {
            string temp = "";
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");

            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            //create object searcher
            ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher(scope, query);

            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                temp = $"\nBootDevice : {m["BootDevice"]}";

            }

            return $"testhest start" + temp + "\nTesthest Slut";

        }

        public List<string> PopulateDisk()

        {

            List<string> disk = new List<string>();

            SelectQuery selectQuery = new SelectQuery("Win32_LogicalDisk");

            ManagementObjectSearcher mnagementObjectSearcher = new ManagementObjectSearcher(selectQuery);

            foreach (ManagementObject managementObject in mnagementObjectSearcher.Get())

            {

                disk.Add(managementObject.ToString());

            }

            return disk;

        }

        public string HovedLager()
        {
            string temp = "";
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                temp = $"Total Visible Memory: {result["TotalVisibleMemorySize"]}KB" +
                $"\nFree Physical Memory: {result["FreePhysicalMemory"]}KB" +
                $"\nTotal Virtual Memory: {result["TotalVirtualMemorySize"]}KB" +
                $"Free Virtual Memory: {result["FreeVirtualMemory"]}KB";
            }

            return temp;

        }

        public string GetDiskMetaData()
        {
            string temp = "";
            System.Management.ManagementScope managementScope = new System.Management.ManagementScope();

            System.Management.ObjectQuery objectQuery = new System.Management.ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);

            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            foreach (ManagementObject managementObject in managementObjectCollection)

            {

                temp = $"Disk Name :{managementObject["Name"].ToString()}" +

                $"\nFreeSpace: {managementObject["FreeSpace"].ToString()}" +

                $"\nDisk Size: {managementObject["Size"].ToString()}" +

                "\n---------------------------------------------------";

            }

            return temp;

        }

        public string GetHardDiskSerialNumber(string drive = "C")

        {

            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");

            managementObject.Get();

            return managementObject["VolumeSerialNumber"].ToString();

        }

        public string LISTAllServices()
        {
            string temp = "";
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();


            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        temp = $"\nWindows service property name: {serviceProperty.Name}" +
                        $"\nWindows service property value: {serviceProperty.Value}";
                    }
                }

                
            }

            return $"There are {objectCollection.Count} Windows services:" + temp +
                    "\n---------------------------------------";


        }
        public string Search()
        {
            string temp = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                temp = $"{name} : {usage}";
                
            }

            return temp;
        }
    }
}
