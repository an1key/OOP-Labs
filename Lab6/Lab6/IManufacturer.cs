using System;

namespace Lab6
{
    public interface IManufacturer
    {
        string Name { get; set; }
        Country Country { get; set; }
        int EmployeeCount { get; set; }
    }

    public enum Country
    {
        USA,
        China,
        Japan,
        Germany,
        Russia
    }
}