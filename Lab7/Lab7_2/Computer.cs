using System;
using System.Collections.Generic;

namespace Lab7_2
{
    public class Computer : IComputer
    {
        public ProcessorType ProcessorType { get; set; }
        public ManufacturerType Manufacturer { get; set; }
        public OperatingSystem OperatingSystem { get; set; }
        public int ClockSpeed { get; set; }
        public int RAMSize { get; set; }
        public List<string> InstalledSoftware { get; set; }
        public List<string> Users { get; set; }

        // События
        public event EventHandler<UserEventArgs> UserAdded;
        public event EventHandler<ProcessorChangedEventArgs> ProcessorReplaced;
        public event EventHandler<SoftwareEventArgs> SoftwareInstalled;
        public event EventHandler<RAMChangedEventArgs> RAMReplaced;

        // Конструктор по умолчанию
        public Computer()
        {
            ProcessorType = ProcessorType.Intel;
            Manufacturer = ManufacturerType.Chuwi;
            OperatingSystem = OperatingSystem.Windows;
            ClockSpeed = 3000;
            RAMSize = 8;
            InstalledSoftware = new List<string>();
            Users = new List<string>();
        }

        // Метод для добавления нового пользователя
        public void AddUser(string userName)
        {
            Users.Add(userName);
            OnUserAdded(new UserEventArgs { UserName = userName });
        }

        // Метод для замены процессора
        public void ReplaceProcessor(ProcessorType newProcessor)
        {
            ProcessorType oldProcessor = ProcessorType;
            ProcessorType = newProcessor;
            OnProcessorReplaced(new ProcessorChangedEventArgs
            {
                OldProcessor = oldProcessor,
                NewProcessor = newProcessor
            });
        }

        // Метод для установки нового ПО
        public void InstallSoftware(string softwareName)
        {
            InstalledSoftware.Add(softwareName);
            OnSoftwareInstalled(new SoftwareEventArgs { SoftwareName = softwareName });
        }

        // Метод для замены ОЗУ
        public void ReplaceRAM(int newRAMSize)
        {
            int oldRAMSize = RAMSize;
            RAMSize = newRAMSize;
            OnRAMReplaced(new RAMChangedEventArgs
            {
                OldRAMSize = oldRAMSize,
                NewRAMSize = newRAMSize
            });
        }

        // Защищенные методы для вызова событий
        protected virtual void OnUserAdded(UserEventArgs e)
        {
            UserAdded?.Invoke(this, e);
        }

        protected virtual void OnProcessorReplaced(ProcessorChangedEventArgs e)
        {
            ProcessorReplaced?.Invoke(this, e);
        }

        protected virtual void OnSoftwareInstalled(SoftwareEventArgs e)
        {
            SoftwareInstalled?.Invoke(this, e);
        }

        protected virtual void OnRAMReplaced(RAMChangedEventArgs e)
        {
            RAMReplaced?.Invoke(this, e);
        }
    }
}