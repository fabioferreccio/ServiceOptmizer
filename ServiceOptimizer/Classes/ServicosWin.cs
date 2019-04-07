using System;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;
using ServiceOptimizer.Classes.Modelo;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace ServiceOptimizer.Classes
{
    class ServicosWin
    {
        public static void StartService(string serviceName, int timeoutMilliseconds = 10000)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                service.Refresh();
                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
                else
                {
                    throw new Exception(string.Format("{0} --> já esta iniciado.", service.DisplayName));
                }
            }
            catch
            {
                throw;
            }
        }
        public static void StopService(string serviceName, int timeoutMilliseconds = 10000)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                service.Refresh();
                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
                else
                {
                    throw new Exception(string.Format("{0} --> já esta parado.", service.DisplayName));
                }
            }
            catch
            {
                throw;
            }
        }
        public static void RestartService(string serviceName, int timeoutMilliseconds = 10000)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                service.Refresh();
                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    // conta o resto do timeout
                    int millisec2 = Environment.TickCount;
                    timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
                else
                {
                    service.Start();
                    throw new Exception(string.Format("{0} --> foi parado e a seguir iniciado", service.DisplayName));
                }
            }
            catch
            {
                throw;
            }
        }
        public static void ListService()
        {
            ServiceController[] scServices = ServiceController.GetServices();
            List<ServiceClientModel> model = new List<ServiceClientModel>();
            
            Console.WriteLine(String.Format("| {0} | {1} | {2} |", "Nome do Serviço".PadRight(70, ' '), "Status".PadRight(10, ' '), "Inicialização".PadRight(15, ' ')));
            Console.WriteLine("".PadRight(105, '-'));
            foreach (ServiceController scTemp in scServices)
            {
                Console.WriteLine(String.Format("| {0} | {1} | {2} |", scTemp.ServiceName.PadRight(70, ' '), scTemp.Status.ToString().PadRight(10, ' '), scTemp.StartType.ToString().PadRight(15, ' ')));
                model.Add(new ServiceClientModel {
                    Display_Name = scTemp.DisplayName,
                    Service_Name = scTemp.ServiceName,
                    Status = scTemp.Status.ToString(),
                    StartType = scTemp.StartType.ToString()
                });
            }
            Console.WriteLine("".PadRight(105, '-'));
            Console.WriteLine("\n");

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@"ConfigUser.json", JsonConvert.SerializeObject(model));
        }

        public static void ChangeStartMode(string serviceName, ServiceStartMode mode)
        {
            try
            {
                Console.WriteLine(String.Format("sc config \"{0}\" start= {1}", serviceName, mode.ToString().ToLower()));
                switch (mode)
                {
                    case ServiceStartMode.Manual:
                        runInCMD(string.Format("sc config \"{0}\" start= {1}", serviceName, "demand"));
                        break;
                    case ServiceStartMode.Automatic:
                        runInCMD(string.Format("sc config \"{0}\" start= {1}", serviceName, "auto"));
                        break;
                    default:
                        runInCMD(string.Format("sc config \"{0}\" start= {1}", serviceName, mode.ToString().ToLower()));
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error [{serviceName}]: {ex.Message}");
            }
        }

        public static bool runInCMD(string path, ProcessWindowStyle windowStyleMode = ProcessWindowStyle.Hidden)
        {
            int lineCount = 0;
            bool result = false;
            StringBuilder output = new StringBuilder();
            var process = new Process();
            process.StartInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
            process.StartInfo.Arguments = $@"/K {path}";
            process.StartInfo.WindowStyle = windowStyleMode;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                // Prepend line numbers to each line of the output.
                if (!String.IsNullOrEmpty(e.Data))
                {
                    lineCount++;
                    output.Append("\n[" + lineCount + "]: " + e.Data);
                }
            });
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                // Prepend line numbers to each line of the output.
                if (!String.IsNullOrEmpty(e.Data))
                {
                    lineCount++;
                    output.Append("\n[" + lineCount + "]: " + e.Data);
                }
            });

            result = process.Start();
            
            Console.WriteLine(output);
            process.Close();
            
            return result;
        }
    }
}
