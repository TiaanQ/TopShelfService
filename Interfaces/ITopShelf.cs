using System;
using TopShelfService.Models;

namespace TopShelfService.Interfaces
{
    interface ITopShelfDetails
    {
        string Name { get; set; }
        string Description { get; set; }
        string DisplayName { get; set; }
        string InstanceName { get; set; }
        int StartMode { get; set; }
        bool EnableServiceRecovery { get; set; }
        ServiceRecovery ServiceRecoveryOptions { get; set; }
        int Identity { get; set; }
        bool BuiltInDependency { get; set; }
        int Dependency { get; set; }
        bool AnotherDependency { get; set; }
        string AnotherDependencyName { get; set; }
        bool EnablePauseAndContinue { get; set; }
        bool Shutdown { get; set; }
        DateTime StartTime { get; set; }
        DateTime StopTime { get; set; }
        TimeSpan CurrentRunTime { get; }
        TimeSpan TotalRunTime { get; }
    }
}