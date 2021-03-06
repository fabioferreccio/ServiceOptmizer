﻿using CsvHelper;
using Newtonsoft.Json;
using ServiceOptimizer.Classes.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static ServiceOptimizer.Classes.Modelo.CSVRepository;
using System.Linq;

namespace ServiceOptimizer.Classes
{
    class Windows10
    {
        public Boolean isByte { get; set; }

        public Windows10(ref byte op)
        {
            Console.WriteLine("1 - Lists and Backup - Your Windows Services");
            Console.WriteLine("2 - BlackViper - Safe for Desktop");
            Console.WriteLine("3 - BlackViper - Safe for Laptop or Tablet");
            Console.WriteLine("4 - BlackViper - Tweaked for Desktop");
            Console.WriteLine("5 - DEFAULT - Windows 10 [HOME]");
            Console.WriteLine("6 - DEFAULT - Windows 10 [PRO]");
            Console.WriteLine("7 - Restore client Backup");
            Console.WriteLine("8 - Convert CSV (ConfigCSV_w10) to JSON");
            Console.WriteLine("0 - Exit");

            Console.Write($"{Environment.NewLine}Select an option: ");
            Console.Out.Flush();
            isByte = Byte.TryParse(Console.ReadLine(), out op);
        }

        public void loadJSON(ref List<BlackViperModel> listWin10)
        {
            string sourceFile = @"ConfigJSON.json";
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

                if (item.DEFAULT_Home != null && item.DEFAULT_Home.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.DEFAULT_Home != null && item.DEFAULT_Home.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.DEFAULT_Home != null && item.DEFAULT_Home.Contains("Disabled"))
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

        public void setBlackViper_SafeForDesktop(ref byte op, List<BlackViperModel> listWin10)
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

                if (item.Safe_Desktop != null && item.Safe_Desktop.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.Safe_Desktop != null && item.Safe_Desktop.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.Safe_Desktop != null && item.Safe_Desktop.Contains("Disabled"))
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

        public void setBlackViper_SafeForLaptopOrTablet(ref byte op, List<BlackViperModel> listWin10)
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

                if (item.Safe_Desktop != null && item.Safe_Mobile.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (item.Safe_Desktop != null && item.Safe_Mobile.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (item.Safe_Desktop != null && item.Safe_Mobile.Contains("Disabled"))
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

        public void setBlackViper_TweakedForDesktop(ref byte op, List<BlackViperModel> listWin10)
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

        public void convert_CsvToJson(ref List<BlackViperModel> listWin10, ref byte op)
        {
            try
            {
                string sourceFile = @"ConfigCSV_w10.csv";
                using (TextReader fileReader = File.OpenText(sourceFile))
                {
                    var csv = new CsvReader(fileReader);
                    csv.Configuration.HasHeaderRecord = true;
                    csv.Configuration.Delimiter = ",";
                    csv.Configuration.Encoding = Encoding.UTF8;

                    csv.Configuration.RegisterClassMap(new StrBlackViper_Win10_ClassMap());
                    listWin10 = csv.GetRecords<BlackViperModel>().ToList<BlackViperModel>();
                    File.WriteAllText(@"ConfigJSON.json", JsonConvert.SerializeObject(listWin10, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar Leitura do Arquivo: {0}", ex.Message);
            }
            op = 255;
        }
    }
}
