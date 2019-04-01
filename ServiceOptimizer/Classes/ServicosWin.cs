using System;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;

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
            
            Console.WriteLine(String.Format("{0} | {1}", "Nome do Serviço".PadRight(70, ' '), "Status".PadRight(10, ' ')));
            Console.WriteLine("".PadRight(80, '-'));
            foreach (ServiceController scTemp in scServices)
            {
                Console.WriteLine(String.Format("{0} | {1}", scTemp.ServiceName.PadRight(70, ' '), scTemp.Status.ToString().PadRight(10, ' ')));
            }
            Console.WriteLine("\n\n");
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
            catch
            {
                throw;
            }
        }

        public static bool runInCMD(string path, ProcessWindowStyle windowStyleMode = ProcessWindowStyle.Hidden)
        {
            var process = new Process();
            process.StartInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
            process.StartInfo.Arguments = $@"/K {path}";
            process.StartInfo.WindowStyle = windowStyleMode;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += (sender, data) =>
            {
                Console.WriteLine(data.Data);
            };
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += (sender, data) =>
            {
                Console.WriteLine(data.Data);
            };
            return process.Start();
        }
    }
}
