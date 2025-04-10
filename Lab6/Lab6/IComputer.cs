using System;
using System.Collections.Generic;

namespace Lab6;

public interface IComputer
{
    ProcessorType ProcessorType { get; set; }
    ManufacturerType Manufacturer { get; set; }
    OperatingSystemType OperatingSystem { get; set; }
    int ClockSpeed { get; set; }
    int RAMSize { get; set; }
    List<string> InstalledSoftware { get; set; }
    List<string> Users { get; set; }
}

// Перечисления для типов процессора, производителя и операционной системы
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

public enum OperatingSystemType
{
    Windows,
    macOS,
    Linux,
    ChromeOS
}