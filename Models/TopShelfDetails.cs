using System;
using TopShelfService.Interfaces;

namespace TopShelfService.Models
{
    class TopShelfDetails : ITopShelfDetails
    {
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string displayName = string.Empty;
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        private string instanceName = string.Empty;
        public string InstanceName
        {
            get { return instanceName; }
            set { instanceName = value; }
        }

        private int startMode = 0;
        public int StartMode
        {
            get { return startMode; }
            set { startMode = value; }
        }

        private bool serviceRecovery = false;
        public bool EnableServiceRecovery
        {
            get { return serviceRecovery; }
            set { serviceRecovery = value; }
        }

        private ServiceRecovery serviceRecoveryOptions = null;
        public ServiceRecovery ServiceRecoveryOptions
        {
            get { return serviceRecoveryOptions; }
            set { serviceRecoveryOptions = value; }
        }

        private int identity = 0;
        public int Identity
        {
            get { return identity; }
            set { identity = value; }
        }

        private bool builtInDependency = false;
        public bool BuiltInDependency
        {
            get { return builtInDependency; }
            set { builtInDependency = value; }
        }

        private int dependency = 0;
        public int Dependency
        {
            get { return dependency; }
            set { dependency = value; }
        }

        private bool anotherDependency = false;
        public bool AnotherDependency
        {
            get { return anotherDependency; }
            set { anotherDependency = value; }
        }

        private string anotherDependencyName = string.Empty;
        public string AnotherDependencyName
        {
            get { return anotherDependencyName; }
            set { anotherDependencyName = value; }
        }

        private bool enablePauseAndContinue = false;
        public bool EnablePauseAndContinue
        {
            get { return enablePauseAndContinue; }
            set { enablePauseAndContinue = value; }
        }

        private bool shutdown = false;
        public bool Shutdown
        {
            get { return shutdown; }
            set { shutdown = value; }
        }

        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = DateTime.Now; }
        }

        private DateTime stopTime;
        public DateTime StopTime
        {
            get { return stopTime; }
            set { stopTime = DateTime.Now; }
        }

        public TimeSpan CurrentRunTime
        {
            get { return DateTime.Now - StartTime; }
        }

        public TimeSpan TotalRunTime
        {
            get { return StopTime - StartTime; }
        }
    }
}
