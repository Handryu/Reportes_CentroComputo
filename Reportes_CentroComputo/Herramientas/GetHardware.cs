using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Reportes_CentroComputo.Herramientas
{
    class GetHardware
    {
        public string SearchInfo(string Key,string Name)
        {
            string result="";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select "+Name+" from "+Key);

            try
            {
                foreach (ManagementObject share in searcher.Get())
                {
                    foreach (PropertyData PC in share.Properties)
                    {

                        if (PC.Value != null && PC.Value.ToString() != "")
                        {
                            switch (PC.Value.GetType().ToString())
                            {
                                case "System.String[]":
                                    string[] str = (string[])PC.Value;

                                    foreach (string st in str)
                                        result += st + " ";

                                    break;
                                case "System.UInt16[]":
                                    ushort[] shortData = (ushort[])PC.Value;

                                    foreach (ushort st in shortData)
                                        result += st.ToString() + " ";  

                                    break;

                                default:
                                    result = PC.Value.ToString();
                                    break;
                            }
                            break;
                        }
                        else
                        { 
                        }
                    }
                }
            }


            catch (Exception exp)
            {
                Console.WriteLine("can't get data because of the followeing error \n" + exp.Message);
            }

            return result;
        }

        private IEnumerable<string> GetInstalledProgramsFromRegistry(RegistryView registryView)
        {
            var result = new List<string>();
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView).OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        if (IsProgramVisible(subkey))
                        {
                            result.Add((string)subkey.GetValue("DisplayName"));
                        }
                    }
                }
            }

            return result;
        }

        private bool IsProgramVisible(RegistryKey subkey)
        {
            var name = (string)subkey.GetValue("DisplayName");
            var releaseType = (string)subkey.GetValue("ReleaseType");
            //var unistallString = (string)subkey.GetValue("UninstallString");
            var systemComponent = subkey.GetValue("SystemComponent");
            var parentName = (string)subkey.GetValue("ParentDisplayName");
            Console.WriteLine("{0},{1},{2},{3}", name, releaseType, systemComponent, parentName);
            return
                !string.IsNullOrEmpty(name)
                && string.IsNullOrEmpty(releaseType)
                && string.IsNullOrEmpty(parentName)
                && (systemComponent == null || (int)systemComponent == 0);
        }

        public List<Object> getInstalledPrograms()
        {
            var result = new List<string>();
            result.AddRange(GetInstalledProgramsFromRegistry(RegistryView.Registry32));
            result.AddRange(GetInstalledProgramsFromRegistry(RegistryView.Registry64));
            List<Object> programas = new List<Object>();
            foreach (var item in result)
            {
                programas.Add(item);
            }
            return programas.Distinct().ToList();
        }
    }
}
