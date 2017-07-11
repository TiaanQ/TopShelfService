using System;
using Topshelf;
using TopShelfService.Models;
using Topshelf.HostConfigurators;

namespace TopShelfService
{
    class Program
    {
        static TopShelfDetails tsd = null;

        static void Main(string[] args)
        {
            ConsoleKey key;

            do
            {
                Console.WriteLine();
                Console.WriteLine("##################################################");
                Console.WriteLine("#### Console To Windows Service With Topshelf ####");
                Console.WriteLine("##################################################");
                Console.WriteLine("####   1. Create a new service                ####");
                Console.WriteLine("####   2. Start a service                     ####");
                Console.WriteLine("####   3. Stop a service                      ####");
                Console.WriteLine("####   4. Check a service                     ####");
                Console.WriteLine("####   5. Remove a service                    ####");
                Console.WriteLine();

                key = Console.ReadKey().Key;

                #region Switch Key
                switch (key)
                {
                    case ConsoleKey.D1:
                        CreateNewService();
                        break;
                    case ConsoleKey.NumPad1:
                        CreateNewService();
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.NumPad2:
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.NumPad3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.NumPad4:
                        break;
                    case ConsoleKey.D5:
                        break;
                    case ConsoleKey.NumPad5:
                        break;
                    default:
                        break;
                }
                #endregion Switch Key

            } while (key != ConsoleKey.Q);
        }

        private static void CreateNewService()
        {
            #region Service Details
            tsd = new TopShelfDetails();

            Console.WriteLine();
            Console.WriteLine("#### Please enter a Service Name:             ####");
            tsd.Name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("#### Please enter a Description:              ####");
            tsd.Description = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("#### Please enter a Display Name:             ####");
            tsd.DisplayName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("#### Please enter an Instance Name:           ####");
            tsd.InstanceName = Console.ReadLine();
            #endregion Service Details

            #region Start Mode
            Console.WriteLine();
            Console.WriteLine("#### Please select a start mode:              ####");
            Console.WriteLine("####   1. Automatically                       ####");
            Console.WriteLine("####   2. Automatically Delayed               ####");
            Console.WriteLine("####   3. Manually                            ####");

            ConsoleKey startMode = Console.ReadKey().Key;
            switch (startMode)
            {
                case ConsoleKey.D1:
                    tsd.StartMode = 1;
                    break;
                case ConsoleKey.NumPad1:
                    tsd.StartMode = 1;
                    break;
                case ConsoleKey.D2:
                    tsd.StartMode = 2;
                    break;
                case ConsoleKey.NumPad2:
                    tsd.StartMode = 2;
                    break;
                case ConsoleKey.D3:
                    tsd.StartMode = 3;
                    break;
                case ConsoleKey.NumPad3:
                    tsd.StartMode = 3;
                    break;
            }
            #endregion Start Mode

            #region Service Recovery
            Console.WriteLine();
            Console.WriteLine("#### Enable service recovery mode?            ####");
            Console.WriteLine("####   1. Yes                                 ####");
            Console.WriteLine("####   2. No                                  ####");

            ConsoleKey serviceRecovery = Console.ReadKey().Key;
            switch (serviceRecovery)
            {
                case ConsoleKey.D1:
                    tsd.EnableServiceRecovery = true;
                    break;
                case ConsoleKey.NumPad1:
                    tsd.EnableServiceRecovery = true;
                    break;
                case ConsoleKey.D2:
                    tsd.EnableServiceRecovery = false;
                    break;
                case ConsoleKey.NumPad2:
                    tsd.EnableServiceRecovery = false;
                    break;
                default:
                    break;
            }

            if (tsd.EnableServiceRecovery)
            {
                ServiceRecovery sc = new ServiceRecovery();

                Console.WriteLine();
                Console.WriteLine("#### Restart Service Delay:                   ####");
                sc.RestartServiceDelay = ConvertToInt(Console.ReadLine());
                Console.WriteLine("#### Run Program Delay:                       ####");
                sc.RunProgramDelay = ConvertToInt(Console.ReadLine());
                Console.WriteLine("#### Run Program Name:                        ####");
                sc.RunProgramName = Console.ReadLine();
                Console.WriteLine("#### Reset Period:                            ####");
                sc.ResetPeriod = ConvertToInt(Console.ReadLine());

                tsd.ServiceRecoveryOptions = sc;
            }
            #endregion Service Recovery

            #region Identity
            Console.WriteLine();
            Console.WriteLine("#### Please select an identity mode:          ####");
            Console.WriteLine("####   1. Run As                              ####");
            Console.WriteLine("####   2. Run As Prompt                       ####");
            Console.WriteLine("####   3. Run As Network Service              ####");
            Console.WriteLine("####   4. Run As Local System                 ####");
            Console.WriteLine("####   5. Run As Local Service                ####");

            ConsoleKey identity = Console.ReadKey().Key;
            switch (identity)
            {
                case ConsoleKey.D1:
                    tsd.Identity = 1;
                    break;
                case ConsoleKey.NumPad1:
                    tsd.Identity = 1;
                    break;
                case ConsoleKey.D2:
                    tsd.Identity = 2;
                    break;
                case ConsoleKey.NumPad2:
                    tsd.Identity = 2;
                    break;
                case ConsoleKey.D3:
                    tsd.Identity = 3;
                    break;
                case ConsoleKey.NumPad3:
                    tsd.Identity = 3;
                    break;
                case ConsoleKey.D4:
                    tsd.Identity = 4;
                    break;
                case ConsoleKey.NumPad4:
                    tsd.Identity = 4;
                    break;
                case ConsoleKey.D5:
                    tsd.Identity = 5;
                    break;
                case ConsoleKey.NumPad5:
                    tsd.Identity = 5;
                    break;
            }
            #endregion Identity

            #region Another Dependency
            Console.WriteLine();
            Console.WriteLine("#### Does this service depend on another service? ");
            Console.WriteLine("####   1. Yes                                 ####");
            Console.WriteLine("####   2. No                                  ####");

            ConsoleKey anotherDepend = Console.ReadKey().Key;
            switch (anotherDepend)
            {
                case ConsoleKey.D1:
                    tsd.AnotherDependency = true;
                    break;
                case ConsoleKey.NumPad1:
                    tsd.AnotherDependency = true;
                    break;
                case ConsoleKey.D2:
                    tsd.AnotherDependency = false;
                    break;
                case ConsoleKey.NumPad2:
                    tsd.AnotherDependency = false;
                    break;
            }

            if (tsd.AnotherDependency)
            {
                Console.WriteLine();
                Console.WriteLine("#### Please enter the name of the service:    ####");
                tsd.AnotherDependencyName = Console.ReadLine();
            }
            #endregion Another Dependency

            #region Built In Dependency
            Console.WriteLine();
            Console.WriteLine("#### Does this service depend on a built-in service?");
            Console.WriteLine("####   1. Yes                                 ####");
            Console.WriteLine("####   2. No                                  ####");

            ConsoleKey depend = Console.ReadKey().Key;
            switch (depend)
            {
                case ConsoleKey.D1:
                    tsd.BuiltInDependency = true;
                    break;
                case ConsoleKey.NumPad1:
                    tsd.BuiltInDependency = true;
                    break;
                case ConsoleKey.D2:
                    tsd.BuiltInDependency = false;
                    break;
                case ConsoleKey.NumPad2:
                    tsd.BuiltInDependency = false;
                    break;
            }

            if (tsd.BuiltInDependency)
            {
                Console.WriteLine();
                Console.WriteLine("#### Please select a built-in dependency:     ####");
                Console.WriteLine("####   1. EventLog                            ####");
                Console.WriteLine("####   2. IIS                                 ####");
                Console.WriteLine("####   3. MSMQ                                ####");
                Console.WriteLine("####   4. MSSQL                               ####");

                ConsoleKey dependency = Console.ReadKey().Key;
                switch (dependency)
                {
                    case ConsoleKey.D1:
                        tsd.Dependency = 1;
                        break;
                    case ConsoleKey.NumPad1:
                        tsd.Dependency = 1;
                        break;
                    case ConsoleKey.D2:
                        tsd.Dependency = 2;
                        break;
                    case ConsoleKey.NumPad2:
                        tsd.Dependency = 2;
                        break;
                    case ConsoleKey.D3:
                        tsd.Dependency = 3;
                        break;
                    case ConsoleKey.NumPad3:
                        tsd.Dependency = 3;
                        break;
                    case ConsoleKey.D4:
                        tsd.Dependency = 4;
                        break;
                    case ConsoleKey.NumPad4:
                        tsd.Dependency = 4;
                        break;
                }
            }
            #endregion Built In Dependency

            #region Pause And Continue
            Console.WriteLine();
            Console.WriteLine("#### Enable Pause And Continue?               ####");
            Console.WriteLine("####   1. Yes                                 ####");
            Console.WriteLine("####   2. No                                  ####");

            ConsoleKey pauseContinue = Console.ReadKey().Key;
            switch (pauseContinue)
            {
                case ConsoleKey.D1:
                    tsd.EnablePauseAndContinue = true;
                    break;
                case ConsoleKey.NumPad1:
                    tsd.EnablePauseAndContinue = true;
                    break;
                case ConsoleKey.D2:
                    tsd.EnablePauseAndContinue = false;
                    break;
                case ConsoleKey.NumPad2:
                    tsd.EnablePauseAndContinue = false;
                    break;
            }
            #endregion Pause And Continue

            #region Shutdown
            Console.WriteLine();
            Console.WriteLine("#### Enable Shutdown?                         ####");
            Console.WriteLine("####   1. Yes                                 ####");
            Console.WriteLine("####   2. No                                  ####");

            ConsoleKey shutdown = Console.ReadKey().Key;
            switch (shutdown)
            {
                case ConsoleKey.D1:
                    tsd.Shutdown = true;
                    break;
                case ConsoleKey.NumPad1:
                    tsd.Shutdown = true;
                    break;
                case ConsoleKey.D2:
                    tsd.Shutdown = false;
                    break;
                case ConsoleKey.NumPad2:
                    tsd.Shutdown = false;
                    break;
            }
            #endregion Shutdown

            CreateStartService();
        }

        private static void CreateStartService()
        {
            try
            {
                HostFactory.New(x =>
                {
                    if (!String.IsNullOrEmpty(tsd.Name))
                        x.SetServiceName(tsd.Name);
                    if (!String.IsNullOrEmpty(tsd.Description))
                        x.SetDescription(tsd.Description);
                    if (!String.IsNullOrEmpty(tsd.DisplayName))
                        x.SetDisplayName(tsd.DisplayName);
                    if (!String.IsNullOrEmpty(tsd.InstanceName))
                        x.SetInstanceName(tsd.InstanceName);

                    #region Start Modes
                    switch (tsd.StartMode)
                    {
                        case 1:
                            x.StartAutomatically();
                            break;
                        case 2:
                            x.StartAutomaticallyDelayed();
                            break;
                        case 3:
                            x.StartManually();
                            break;
                        default:
                            break;
                    }
                    #endregion Start Modes

                    #region Service Recovery
                    if (tsd.EnableServiceRecovery)
                    {
                        x.EnableServiceRecovery(rc =>
                        {
                            rc.RestartService(tsd.ServiceRecoveryOptions.RestartServiceDelay);
                            rc.RunProgram(tsd.ServiceRecoveryOptions.RunProgramDelay, tsd.ServiceRecoveryOptions.RunProgramName);
                            rc.SetResetPeriod(tsd.ServiceRecoveryOptions.ResetPeriod);
                        });
                    }
                    #endregion Service Recovery

                    #region Service Identity
                    string username = string.Empty;
                    string password = string.Empty;
                    switch (tsd.Identity)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.WriteLine("#### Please enter a username:                 ####");
                            username = Console.ReadLine();
                            Console.WriteLine("#### Please enter a password:                 ####");
                            password = Console.ReadLine();
                            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
                                x.RunAs(username, password);
                            break;
                        case 2:
                            x.RunAsPrompt();
                            break;
                        case 3:
                            x.RunAsNetworkService();
                            break;
                        case 4:
                            x.RunAsLocalSystem();
                            break;
                        case 5:
                            x.RunAsLocalService();
                            break;
                    }
                    #endregion Service Identity

                    #region Another Dependency
                    if (tsd.AnotherDependency && !String.IsNullOrEmpty(tsd.AnotherDependencyName))
                        x.DependsOn(tsd.AnotherDependencyName);
                    #endregion Another Dependency

                    #region Built In Dependency
                    if (tsd.BuiltInDependency)
                    {
                        switch (tsd.Dependency)
                        {
                            case 1:
                                x.DependsOnEventLog();
                                break;
                            case 2:
                                x.DependsOnIis();
                                break;
                            case 3:
                                x.DependsOnMsmq();
                                break;
                            case 4:
                                x.DependsOnMsSql();
                                break;
                        }
                    }
                    #endregion Built In Dependency

                    #region Pause And Continue
                    if (tsd.EnablePauseAndContinue)
                        x.EnablePauseAndContinue();
                    #endregion Pause And Continue

                    #region Shutdown
                    if (tsd.Shutdown)
                        x.EnableShutdown();
                    #endregion Shutdown
                });
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }

        private static void StartService()
        {
        }

        private static void Init()
        {
        }

        private static int ConvertToInt(string input)
        {
            Int32 value = 0;
            Int32.TryParse(input, out value);
            return value;
        }

        private static void WriteError(string error)
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            Console.WriteLine();
            Console.WriteLine("############## " + now + " ###############");
            Console.WriteLine("##################################################");
            Console.WriteLine("###################### Error #####################");
            Console.WriteLine("##################################################");
            Console.WriteLine(error);
            Console.WriteLine();
            Console.WriteLine("##################################################");
        }
    }
}