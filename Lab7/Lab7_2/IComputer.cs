using System;
using System.Collections.Generic;

namespace Lab7_2
{
    public interface IComputer
    {
        ProcessorType ProcessorType { get; set; }
        ManufacturerType Manufacturer { get; set; }
        OperatingSystem OperatingSystem { get; set; }
        int ClockSpeed { get; set; }
        int RAMSize { get; set; }
        List<string> InstalledSoftware { get; set; }
        List<string> Users { get; set; }

        // События
        event EventHandler<UserEventArgs> UserAdded;
        event EventHandler<ProcessorChangedEventArgs> ProcessorReplaced;
        event EventHandler<SoftwareEventArgs> SoftwareInstalled;
        event EventHandler<RAMChangedEventArgs> RAMReplaced;
    }

    // Аргументы для событий
    public class UserEventArgs : EventArgs
    {
        public string UserName { get; set; }
    }

    public class ProcessorChangedEventArgs : EventArgs
    {
        public ProcessorType OldProcessor { get; set; }
        public ProcessorType NewProcessor { get; set; }
    }

    public class SoftwareEventArgs : EventArgs
    {
        public string SoftwareName { get; set; }
    }

    public class RAMChangedEventArgs : EventArgs
    {
        public int OldRAMSize { get; set; }
        public int NewRAMSize { get; set; }
    }
    
    
    public enum ProcessorType
    {
        Intel,
        AMD,
        ARM
    }

    public enum ManufacturerType
    {
        Chuwi,
        HP,
        Lenovo,
        Apple,
        Microsoft
    }

    public enum OperatingSystem
    {
        Windows,
        macOS,
        Linux,
        ChromeOS
    }
}