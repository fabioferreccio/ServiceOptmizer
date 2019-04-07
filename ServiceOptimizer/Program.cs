using System;
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
            byte so = 255;
            bool isByte = true;
            bool json_isLoaded = false;

            do
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the service optimizer - {Environment.OSVersion} {Environment.NewLine}");
                Console.WriteLine($"Select the desired operating system: {Environment.NewLine}");
                Console.WriteLine($"1 - Windows 10");
                Console.WriteLine($"2 - Windows 8.1");
                Console.WriteLine($"3 - Windows 8");
                Console.WriteLine($"4 - Windows 7");
                Console.WriteLine($"0 - Exit");

                Console.Write($"{Environment.NewLine}Select an option: ");
                Console.Out.Flush();
                isByte = Byte.TryParse(Console.ReadLine(), out so);

                Console.Clear();
                Console.WriteLine($"Welcome to the service optimizer - {Environment.OSVersion} {Environment.NewLine}");

                switch (so)
                {
                    case 0:
                        break;
                    case 1:
                        do
                        {
                            Windows10 referencia = new Windows10(ref op);
                            if (!json_isLoaded)
                            {
                                referencia.loadJSON(ref list);
                                json_isLoaded = true;
                            }

                            switch (op)
                            {
                                case 1:
                                    referencia.listAndBackup_WindowsServices(ref op);
                                    break;
                                case 2:
                                    referencia.setBlackViper_SafeForDesktop(ref op, list);
                                    break;
                                case 3:
                                    referencia.setBlackViper_SafeForLaptopOrTablet(ref op, list);
                                    break;
                                case 4:
                                    referencia.setBlackViper_TweakedForDesktop(ref op, list);
                                    break;
                                case 5:
                                    referencia.setDefault_WindowsHome(ref op, list);
                                    break;
                                case 6:
                                    referencia.setDefault_WindowsPro(ref op, list);
                                    break;
                                case 7:
                                    referencia.loadJSON(ref listUser);
                                    referencia.Restore_WindowsServiceBackup(ref op, listUser);
                                    break;
                            }

                            if(op != 255 && op != 0)
                            {
                                Console.WriteLine($"{Environment.NewLine}{"".PadRight(105, '*')}");
                                Console.WriteLine($"{Environment.NewLine} Processo Finalizado!");
                                System.Threading.Thread.Sleep(5000);
                            }
                        } while (op != 0);
                        json_isLoaded = false;
                        break;
                    case 2:
                        do
                        {
                            Windows81 referencia = new Windows81(ref op);
                            if (!json_isLoaded)
                            {
                                referencia.loadJSON(ref list);
                                json_isLoaded = true;
                            }

                            switch (op)
                            {
                                case 1:
                                    referencia.listAndBackup_WindowsServices(ref op);
                                    break;
                                case 2:
                                    referencia.setDefault_WindowsHome(ref op, list);
                                    break;
                                case 3:
                                    referencia.setDefault_WindowsPro(ref op, list);
                                    break;
                                case 4:
                                    referencia.setDefault_WindowsEnterprise(ref op, list);
                                    break;
                                case 5:
                                    referencia.setBlackViper_Safe(ref op, list);
                                    break;
                                case 6:
                                    referencia.loadJSON(ref listUser);
                                    referencia.Restore_WindowsServiceBackup(ref op, listUser);
                                    break;
                            }

                            if (op != 255 && op != 0)
                            {
                                Console.WriteLine($"{Environment.NewLine}{"".PadRight(105, '*')}");
                                Console.WriteLine($"{Environment.NewLine} Processo Finalizado!");
                                System.Threading.Thread.Sleep(5000);
                            }
                        } while (op != 0);
                        json_isLoaded = false;
                        break;
                    default:
                        Console.WriteLine("Not Yet implemented, Sorry!!");
                        System.Threading.Thread.Sleep(5000);
                        break;
                }

            } while (so != 0);
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
    }
}
