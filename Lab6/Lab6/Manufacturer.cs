using System;

namespace Lab6
{
    public class Manufacturer : IManufacturer
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public int EmployeeCount { get; set; }

        // Конструктор по умолчанию
        public Manufacturer()
        {
            Name = "Default Manufacturer";
            Country = Country.USA;
            EmployeeCount = 1000;
        }

        // Конструктор с параметрами
        public Manufacturer(string name, Country country, int employeeCount)
        {
            Name = name;
            Country = country;
            EmployeeCount = employeeCount;
        }
    }
}