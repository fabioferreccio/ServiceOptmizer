using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using ServiceOptimizer.Classes;
using ServiceOptimizer.Classes.Modelo;

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
                            if (!json_isLoaded && (op > 0 && op < 8))
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
                                case 8:
                                    referencia.convert_CsvToJson(ref list, ref op);
                                    json_isLoaded = true;
                                    Console.Clear();
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
                    case 2:
                        do
                        {
                            Windows81 referencia = new Windows81(ref op);
                            if (!json_isLoaded && (op > 0 && op < 7))
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
                                case 7:
                                    referencia.convert_CsvToJson(ref list, ref op);
                                    json_isLoaded = true;
                                    Console.Clear();
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
                    case 3:
                        do
                        {
                            Windows8 referencia = new Windows8(ref op);
                            if (!json_isLoaded && (op > 0 && op < 7))
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
                                case 7:
                                    referencia.convert_CsvToJson(ref list, ref op);
                                    json_isLoaded = true;
                                    Console.Clear();
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
                    case 4:
                        do
                        {
                            Windows7 referencia = new Windows7(ref op);
                            if (!json_isLoaded && (op > 0 && op < 12))
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
                                    referencia.setDefault_WindowsSTARTER(ref op, list);
                                    break;
                                case 3:
                                    referencia.setDefault_WindowsHomeBasic(ref op, list);
                                    break;
                                case 4:
                                    referencia.setDefault_WindowsHomePremiun(ref op, list);
                                    break;
                                case 5:
                                    referencia.setDefault_WindowsProfissional(ref op, list);
                                    break;
                                case 6:
                                    referencia.setDefault_WindowsUltimate(ref op, list);
                                    break;
                                case 7:
                                    referencia.setDefault_WindowsEnterprise(ref op, list);
                                    break;
                                case 8:
                                    referencia.setBlackViper_Safe(ref op, list);
                                    break;
                                case 9:
                                    referencia.setBlackViper_Tweaked(ref op, list);
                                    break;
                                case 10:
                                    referencia.setBlackViper_BareBones(ref op, list);
                                    break;
                                case 11:
                                    referencia.loadJSON(ref listUser);
                                    referencia.Restore_WindowsServiceBackup(ref op, listUser);
                                    break;
                                case 12:
                                    referencia.convert_CsvToJson(ref list, ref op);
                                    json_isLoaded = true;
                                    Console.Clear();
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
                    Console.WriteLine($"{Environment.NewLine}{"".PadRight(105, '*')}");
                    Console.WriteLine($"{Environment.NewLine}Não foi possível conceder acesso como Admin. As operações realizadas poderão ter Acesso Negado!");
                    Console.WriteLine($"{Environment.NewLine}Error: {ex.Message}");
                    Console.WriteLine($"{Environment.NewLine}{"".PadRight(105, '*')}");
                }
            }
            return administrativeMode;
        }
    }
}
