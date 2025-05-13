namespace lib8;

using System;

public class MyClass
{
    // Поля
    public int PublicField;
    protected string ProtectedField;
    private double PrivateField;

    // Свойства
    public int PublicProperty { get; set; }
    protected string ProtectedProperty { get; set; }
    private double PrivateProperty { get; set; }

    // Конструкторы
    public MyClass() { }

    public MyClass(int publicField, string protectedField, double privateField)
    {
        PublicField = publicField;
        ProtectedField = protectedField;
        PrivateField = privateField;
    }

    // Методы
    public void PublicMethod()
    {
        Console.WriteLine("Public Method Called");
    }

    protected void ProtectedMethod()
    {
        Console.WriteLine("Protected Method Called");
    }

    private void PrivateMethod()
    {
        Console.WriteLine("Private Method Called");
    }
}