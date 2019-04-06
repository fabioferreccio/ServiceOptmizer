﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Linq;
using CsvHelper;
using ServiceOptimizer.Classes;
using ServiceOptimizer.Classes.Modelo;
using static ServiceOptimizer.Classes.Modelo.CSVRepository;
using Newtonsoft.Json;

namespace ServiceOptimizer
{
    public enum windowsOrUserMode
    {
        windows = 0,
        usuario = 1

    }

    class Program
    {
        private static List<BlackViperModel> list = new List<BlackViperModel>();
        private static List<ServiceClientModel> listUser = new List<ServiceClientModel>();

        static void Main(string[] args)
        {
            byte op = 255;
            bool isByte = true;
            if (runOnAdministratorMode())
            {
                CarregarJSON_BlackViper(windowsOrUserMode.windows);

                do
                {
                    Console.WriteLine($"Welcome to the service optimizer: \n");
                    Console.WriteLine("1- Lists and Backup - Your Windows Services.");
                    Console.WriteLine("2- BlackViper - Safe for Desktop.");
                    Console.WriteLine("3- BlackViper - Safe for Laptop or Tablet.");
                    Console.WriteLine("4- BlackViper - Tweaked for Desktop.");
                    Console.WriteLine("5- Restore client Backup.");
                    Console.WriteLine("0- Exit.");
                    
                    Console.Write("\nSelecione uma opção: ");
                    Console.Out.Flush();
                    isByte = Byte.TryParse(Console.ReadLine(), out op);
                    //Convert.ToByte(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Console.Clear();
                            ServicosWin.ListService();
                            op = 255;
                            break;
                        case 2:
                            Console.Clear();
                            BlackViper_SafeForDesktop();
                            Console.WriteLine($"{Environment.NewLine}{"".PadRight(105, '*')}");
                            Console.WriteLine($"{Environment.NewLine} Processo Finalizado!");
                            System.Threading.Thread.Sleep(3000);
                            op = 0;
                            break;
                        case 3:
                            Console.Clear();
                            BlackViper_SafeForLaptopOrTablet();
                            Console.WriteLine($"{Environment.NewLine}{"".PadRight(105, '*')}");
                            Console.WriteLine($"{Environment.NewLine} Processo Finalizado!");
                            System.Threading.Thread.Sleep(3000);
                            op = 0;
                            break;
                        case 4:
                            Console.Clear();
                            BlackViper_TweakedForDesktop();
                            Console.WriteLine($"{Environment.NewLine}{"".PadRight(105, '*')}");
                            Console.WriteLine($"{Environment.NewLine} Processo Finalizado!");
                            System.Threading.Thread.Sleep(3000);
                            op = 0;
                            break;
                        case 5:
                            Console.Clear();
                            CarregarJSON_BlackViper(windowsOrUserMode.usuario);
                            Restore_ClientBackup();
                            Console.WriteLine($"{Environment.NewLine}{"".PadRight(105, '*')}");
                            Console.WriteLine($"{Environment.NewLine} Processo Finalizado!");
                            System.Threading.Thread.Sleep(3000);
                            op = 0;
                            break;
                    }
                } while (op != 0);
            }
            else
            {
                //Console.WriteLine("Software não foi executado como administrador");
                op = (byte)Console.Read();
            }
            
        }

        public static bool runOnAdministratorMode()
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool administrativeMode = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!administrativeMode)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + Assembly.GetExecutingAssembly().CodeBase; ;
                startInfo.Verb = "runas";
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                try
                {
                    Process.Start(startInfo);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{Environment.NewLine}{"".PadRight(105,'*')}");
                    Console.WriteLine($"{Environment.NewLine}Não foi possível conceder acesso como Admin. As operações realizadas poderão ter Acesso Negado!");
                    Console.WriteLine($"{Environment.NewLine}Error: {ex.Message}");
                    Console.WriteLine($"{Environment.NewLine}{"".PadRight(105,'*')}");
                }
            }
            return administrativeMode;
        }

        public static void CarregarCSV_BlackViper()
        {
            try
            {
                string sourceFile = @"ConfigCSV.csv";
                using (TextReader fileReader = File.OpenText(sourceFile))
                {
                    var csv = new CsvReader(fileReader);
                    csv.Configuration.HasHeaderRecord = true;
                    csv.Configuration.Delimiter = ",";
                    csv.Configuration.Encoding = Encoding.UTF8;

                    csv.Configuration.RegisterClassMap(new StrBlackViperClassMap());
                    list = csv.GetRecords<BlackViperModel>().ToList<BlackViperModel>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro ao executar Leitura do Arquivo: {0}", ex.Message);
            }
        }

        public static void CarregarJSON_BlackViper(windowsOrUserMode mode)
        {
            string sourceFile = string.Empty;
            try
            {
                switch (mode)
                {
                    case windowsOrUserMode.windows:
                        sourceFile = @"ConfigJSON.json";
                        list = JsonConvert.DeserializeObject<List<BlackViperModel>>(File.ReadAllText(sourceFile));
                        break;
                    case windowsOrUserMode.usuario:
                        sourceFile = @"ConfigUser.json";
                        listUser = JsonConvert.DeserializeObject<List<ServiceClientModel>>(File.ReadAllText(sourceFile));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar Leitura do Arquivo: {0}", ex.Message);
            }
        }

        public static void BlackViper_SafeForDesktop()
        {
            foreach(BlackViperModel svcSafe in list)
            {
                string nameService = String.Empty;
                if (svcSafe.Service_Name != null && svcSafe.Service_Name.Contains("_"))
                {
                    nameService = svcSafe.Service_Name.Split('_')[0];
                }
                else
                {
                    nameService = svcSafe.Service_Name;
                }

                if (svcSafe.Safe_Desktop != null && svcSafe.Safe_Desktop.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (svcSafe.Safe_Desktop != null && svcSafe.Safe_Desktop.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (svcSafe.Safe_Desktop != null && svcSafe.Safe_Desktop.Contains("Disabled"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Disabled);
                }
                else
                {
                    Console.WriteLine("SVC_NAME: {0} Não Configurado ou Instalado.", (String.IsNullOrEmpty(nameService) ? "Null" : nameService));
                }
            }
        }

        public static void BlackViper_SafeForLaptopOrTablet()
        {
            foreach (BlackViperModel svcSafe in list)
            {
                string nameService = String.Empty;
                if (svcSafe.Service_Name != null && svcSafe.Service_Name.Contains("_"))
                {
                    nameService = svcSafe.Service_Name.Split('_')[0];
                }
                else
                {
                    nameService = svcSafe.Service_Name;
                }

                if (svcSafe.Safe_Mobile != null && svcSafe.Safe_Mobile.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (svcSafe.Safe_Mobile != null && svcSafe.Safe_Mobile.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (svcSafe.Safe_Mobile != null && svcSafe.Safe_Mobile.Contains("Disabled"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Disabled);
                }
                else
                {
                    Console.WriteLine("SVC_NAME: {0} Não Configurado ou Instalado.", (String.IsNullOrEmpty(nameService) ? "Null": nameService));
                }
            }
        }

        public static void BlackViper_TweakedForDesktop()
        {
            foreach (BlackViperModel svcSafe in list)
            {
                string nameService = String.Empty;
                if (svcSafe.Service_Name != null && svcSafe.Service_Name.Contains("_"))
                {
                    nameService = svcSafe.Service_Name.Split('_')[0];
                }
                else
                {
                    nameService = svcSafe.Service_Name;
                }

                if (svcSafe.Tweaked_Desktop != null && svcSafe.Tweaked_Desktop.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (svcSafe.Tweaked_Desktop != null && svcSafe.Tweaked_Desktop.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (svcSafe.Tweaked_Desktop != null && svcSafe.Tweaked_Desktop.Contains("Disabled"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Disabled);
                }
                else
                {
                    Console.WriteLine("SVC_NAME: {0} Não Configurado ou Instalado.", (String.IsNullOrEmpty(nameService) ? "Null" : nameService));
                }
            }
        }

        public static void Restore_ClientBackup()
        {
            foreach (ServiceClientModel svcSafe in listUser)
            {
                string nameService = String.Empty;
                if (svcSafe.Service_Name.Contains("_"))
                {
                    nameService = svcSafe.Service_Name.Split('_')[0];
                }
                else
                {
                    nameService = svcSafe.Service_Name;
                }

                if (svcSafe.StartType.Contains("Manual"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Manual);
                }
                else if (svcSafe.StartType.Contains("Automatic"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Automatic);
                }
                else if (svcSafe.StartType.Contains("Disabled"))
                {
                    ServicosWin.ChangeStartMode(nameService, System.ServiceProcess.ServiceStartMode.Disabled);
                }
                else
                {
                    Console.WriteLine("SVC_NAME: {0} Não Configurado ou Instalado.", nameService);
                }
            }
        }
    }
}
