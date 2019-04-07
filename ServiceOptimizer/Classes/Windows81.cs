using Newtonsoft.Json;
using ServiceOptimizer.Classes.Modelo;
using System;
using System.Collections.Generic;
using System.IO;

namespace ServiceOptimizer.Classes
{
    class Windows81
    {
        public Boolean isByte { get; set; }

        public Windows81(ref byte op)
        {
            Console.WriteLine("1 - Lists and Backup - Your Windows Services");
            Console.WriteLine("2 - DEFAULT - Windows 8.1 [HOME]");
            Console.WriteLine("3 - DEFAULT - Windows 8.1 [PRO]");
            Console.WriteLine("4 - DEFAULT - Windows 8.1 [ENTERPRISE]");
            Console.WriteLine("5 - BlackViper - Safe");
            Console.WriteLine("6 - Restore client Backup");
            Console.WriteLine("0 - Exit");

            Console.Write($"{Environment.NewLine}Select an option: ");
            Console.Out.Flush();
            isByte = Byte.TryParse(Console.ReadLine(), out op);
        }

        public void loadJSON(ref List<BlackViperModel> listWin10)
        {
            string sourceFile = @"ConfigJSON_w81.json";
            listWin10 = JsonConvert.DeserializeObject<List<BlackViperModel>>(File.ReadAllText(sourceFile));
        }

        public void loadJSON(ref List<ServiceClientModel> listBackupUser)
        {
            string sourceFile = @"ConfigUser.json";
            listBackupUser = JsonConvert.DeserializeObject<List<ServiceClientModel>>(File.ReadAllText(sourceFile));
        }

        public void listAndBackup_WindowsServices(ref byte op)
        {
            ServicosWin.ListService();
            op = 255;
        }

        public void Restore_WindowsServiceBackup(ref byte op, List<ServiceClientModel> listBackupUser)
        {
            foreach (ServiceClientModel item in listBackupUser)
            {
                string nameService = String.Empty;
                if (item.Service_Name != null && item.Service_Name.Contains("_"))
                {
                    nameService = item.Service_Name.Split('_')[0];
                }
                else
                {
                    nameService = item.Service_Name;
                }

                if (item.StartType != null && item.StartType.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.StartType != null && item.StartType.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.StartType != null && item.StartType.Contains("Disabled"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Disabled);
                }
                else
                {
                    Console.WriteLine("SVC_NAME: {0} Não Configurado ou Instalado.", (String.IsNullOrEmpty(nameService) ? "Null" : nameService));
                }
            }
            op = 0;
        }

        public void setDefault_WindowsHome(ref byte op, List<BlackViperModel> listWin10)
        {
            foreach (BlackViperModel item in listWin10)
            {
                string nameService = String.Empty;
                if (item.Service_Name != null && item.Service_Name.Contains("_"))
                {
                    nameService = item.Service_Name.Split('_')[0];
                }
                else
                {
                    nameService = item.Service_Name;
                }

                if (item.DEFAULT_Windows81 != null && item.DEFAULT_Windows81.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Windows81 != null && item.DEFAULT_Windows81.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Windows81 != null && item.DEFAULT_Windows81.Contains("Disabled"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Disabled);
                }
                else
                {
                    Console.WriteLine("SVC_NAME: {0} Não Configurado ou Instalado.", (String.IsNullOrEmpty(nameService) ? "Null" : nameService));
                }
            }
            op = 0;
        }

        public void setDefault_WindowsPro(ref byte op, List<BlackViperModel> listWin10)
        {
            foreach (BlackViperModel item in listWin10)
            {
                string nameService = String.Empty;
                if (item.Service_Name != null && item.Service_Name.Contains("_"))
                {
                    nameService = item.Service_Name.Split('_')[0];
                }
                else
                {
                    nameService = item.Service_Name;
                }

                if (item.DEFAULT_Windows81_Pro != null && item.DEFAULT_Windows81_Pro.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Windows81_Pro != null && item.DEFAULT_Windows81_Pro.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Windows81_Pro != null && item.DEFAULT_Windows81_Pro.Contains("Disabled"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Disabled);
                }
                else
                {
                    Console.WriteLine("SVC_NAME: {0} Não Configurado ou Instalado.", (String.IsNullOrEmpty(nameService) ? "Null" : nameService));
                }
            }
            op = 0;
        }

        public void setDefault_WindowsEnterprise(ref byte op, List<BlackViperModel> listWin10)
        {
            foreach (BlackViperModel item in listWin10)
            {
                string nameService = String.Empty;
                if (item.Service_Name != null && item.Service_Name.Contains("_"))
                {
                    nameService = item.Service_Name.Split('_')[0];
                }
                else
                {
                    nameService = item.Service_Name;
                }

                if (item.DEFAULT_Windows81_Enterprise != null && item.DEFAULT_Windows81_Enterprise.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Windows81_Enterprise != null && item.DEFAULT_Windows81_Enterprise.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Windows81_Enterprise != null && item.DEFAULT_Windows81_Enterprise.Contains("Disabled"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Disabled);
                }
                else
                {
                    Console.WriteLine("SVC_NAME: {0} Não Configurado ou Instalado.", (String.IsNullOrEmpty(nameService) ? "Null" : nameService));
                }
            }
            op = 0;
        }

        public void setBlackViper_Safe(ref byte op, List<BlackViperModel> listWin10)
        {
            foreach (BlackViperModel item in listWin10)
            {
                string nameService = String.Empty;
                if (item.Service_Name != null && item.Service_Name.Contains("_"))
                {
                    nameService = item.Service_Name.Split('_')[0];
                }
                else
                {
                    nameService = item.Service_Name;
                }

                if (item.Safe != null && item.Safe.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.Safe != null && item.Safe.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.Safe != null && item.Safe.Contains("Disabled"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Disabled);
                }
                else
                {
                    Console.WriteLine("SVC_NAME: {0} Não Configurado ou Instalado.", (String.IsNullOrEmpty(nameService) ? "Null" : nameService));
                }
            }
            op = 0;
        }
    }
}
