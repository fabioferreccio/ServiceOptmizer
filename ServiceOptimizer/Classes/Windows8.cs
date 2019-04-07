using CsvHelper;
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
    class Windows8
    {
        public Boolean isByte { get; set; }

        public Windows8(ref byte op)
        {
            Console.WriteLine("1 - Lists and Backup - Your Windows Services");
            Console.WriteLine("2 - DEFAULT - Windows 8 [HOME]");
            Console.WriteLine("3 - DEFAULT - Windows 8 [PRO]");
            Console.WriteLine("4 - DEFAULT - Windows 8 [ENTERPRISE]");
            Console.WriteLine("5 - BlackViper - Safe");
            Console.WriteLine("6 - Restore client Backup");
            Console.WriteLine("7 - Convert CSV (ConfigCSV_w8) to JSON");
            Console.WriteLine("0 - Exit");

            Console.Write($"{Environment.NewLine}Select an option: ");
            Console.Out.Flush();
            isByte = Byte.TryParse(Console.ReadLine(), out op);
        }

        public void loadJSON(ref List<BlackViperModel> listWin8)
        {
            string sourceFile = @"ConfigJSON_w8.json";
            listWin8 = JsonConvert.DeserializeObject<List<BlackViperModel>>(File.ReadAllText(sourceFile));
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

        public void setDefault_WindowsHome(ref byte op, List<BlackViperModel> listWin8)
        {
            foreach (BlackViperModel item in listWin8)
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

        public void setDefault_WindowsPro(ref byte op, List<BlackViperModel> listWin8)
        {
            foreach (BlackViperModel item in listWin8)
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

        public void setDefault_WindowsEnterprise(ref byte op, List<BlackViperModel> listWin8)
        {
            foreach (BlackViperModel item in listWin8)
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

        public void setBlackViper_Safe(ref byte op, List<BlackViperModel> listWin8)
        {
            foreach (BlackViperModel item in listWin8)
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

        public void convert_CsvToJson(ref List<BlackViperModel> listWin8, ref byte op)
        {
            try
            {
                string sourceFile = @"ConfigCSV_w8.csv";
                using (TextReader fileReader = File.OpenText(sourceFile))
                {
                    var csv = new CsvReader(fileReader);
                    csv.Configuration.HasHeaderRecord = true;
                    csv.Configuration.Delimiter = ",";
                    csv.Configuration.Encoding = Encoding.UTF8;

                    csv.Configuration.RegisterClassMap(new StrBlackViper_Win8_ClassMap());
                    listWin8 = csv.GetRecords<BlackViperModel>().ToList<BlackViperModel>();
                    File.WriteAllText(@"ConfigJSON_w8.json", JsonConvert.SerializeObject(listWin8, new JsonSerializerSettings
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
