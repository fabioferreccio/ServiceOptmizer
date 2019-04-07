using Newtonsoft.Json;
using ServiceOptimizer.Classes.Modelo;
using System;
using System.Collections.Generic;
using System.IO;

namespace ServiceOptimizer.Classes
{
    class Windows7
    {
        public Boolean isByte { get; set; }

        public Windows7(ref byte op)
        {
            Console.WriteLine(" 1 - Lists and Backup - Your Windows Services");
            Console.WriteLine(" 2 - DEFAULT - Windows 7 [Starter]");
            Console.WriteLine(" 3 - DEFAULT - Windows 7 [HOME BASIC]");
            Console.WriteLine(" 4 - DEFAULT - Windows 7 [HOME Premiun]");
            Console.WriteLine(" 5 - DEFAULT - Windows 7 [Profissional]");
            Console.WriteLine(" 6 - DEFAULT - Windows 7 [Ultimate]");
            Console.WriteLine(" 7 - DEFAULT - Windows 7 [Enterpise]");
            Console.WriteLine(" 8 - BlackViper - Safe");
            Console.WriteLine(" 9 - BlackViper - Tweaked");
            Console.WriteLine("10 - BlackViper - Bare Bones");
            Console.WriteLine("11 - Restore client Backup");
            Console.WriteLine(" 0 - Exit");

            Console.Write($"{Environment.NewLine}Select an option: ");
            Console.Out.Flush();
            isByte = Byte.TryParse(Console.ReadLine(), out op);
        }

        public void loadJSON(ref List<BlackViperModel> listWin7)
        {
            string sourceFile = @"ConfigJSON_w7.json";
            listWin7 = JsonConvert.DeserializeObject<List<BlackViperModel>>(File.ReadAllText(sourceFile));
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

        public void setDefault_WindowsSTARTER(ref byte op, List<BlackViperModel> listWin7)
        {
            foreach (BlackViperModel item in listWin7)
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

                if (item.DEFAULT_Starter != null && item.DEFAULT_Starter.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Starter != null && item.DEFAULT_Starter.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Starter != null && item.DEFAULT_Starter.Contains("Disabled"))
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

        public void setDefault_WindowsHomeBasic(ref byte op, List<BlackViperModel> listWin7)
        {
            foreach (BlackViperModel item in listWin7)
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

                if (item.DEFAULT_Home_Basic != null && item.DEFAULT_Home_Basic.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Home_Basic != null && item.DEFAULT_Home_Basic.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Home_Basic != null && item.DEFAULT_Home_Basic.Contains("Disabled"))
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

        public void setDefault_WindowsHomePremiun(ref byte op, List<BlackViperModel> listWin7)
        {
            foreach (BlackViperModel item in listWin7)
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

                if (item.DEFAULT_Home_Premium != null && item.DEFAULT_Home_Premium.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Home_Premium != null && item.DEFAULT_Home_Premium.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Home_Premium != null && item.DEFAULT_Home_Premium.Contains("Disabled"))
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

        public void setDefault_WindowsProfissional(ref byte op, List<BlackViperModel> listWin7)
        {
            foreach (BlackViperModel item in listWin7)
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

                if (item.DEFAULT_Professional != null && item.DEFAULT_Professional.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Professional != null && item.DEFAULT_Professional.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Professional != null && item.DEFAULT_Professional.Contains("Disabled"))
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

        public void setDefault_WindowsUltimate(ref byte op, List<BlackViperModel> listWin7)
        {
            foreach (BlackViperModel item in listWin7)
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

                if (item.DEFAULT_Ultimate != null && item.DEFAULT_Ultimate.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Ultimate != null && item.DEFAULT_Ultimate.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Ultimate != null && item.DEFAULT_Ultimate.Contains("Disabled"))
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

        public void setDefault_WindowsEnterprise(ref byte op, List<BlackViperModel> listWin7)
        {
            foreach (BlackViperModel item in listWin7)
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

                if (item.DEFAULT_Enterprise != null && item.DEFAULT_Enterprise.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Enterprise != null && item.DEFAULT_Enterprise.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Enterprise != null && item.DEFAULT_Enterprise.Contains("Disabled"))
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

        public void setBlackViper_Safe(ref byte op, List<BlackViperModel> listWin7)
        {
            foreach (BlackViperModel item in listWin7)
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

        public void setBlackViper_Tweaked(ref byte op, List<BlackViperModel> listWin7)
        {
            foreach (BlackViperModel item in listWin7)
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

                if (item.Tweaked != null && item.Tweaked.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.Tweaked != null && item.Tweaked.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.Tweaked != null && item.Tweaked.Contains("Disabled"))
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

        public void setBlackViper_BareBones(ref byte op, List<BlackViperModel> listWin7)
        {
            foreach (BlackViperModel item in listWin7)
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

                if (item.Bare_bones != null && item.Bare_bones.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.Bare_bones != null && item.Bare_bones.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.Bare_bones != null && item.Bare_bones.Contains("Disabled"))
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
