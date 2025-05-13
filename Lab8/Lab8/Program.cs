using System;
using System.Reflection;

namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Загрузка библиотеки
            Assembly assembly = Assembly.LoadFrom("../../../../lib8/bin/Debug/net8.0/lib8.dll");

            // Получение типа
            Type myClassType = assembly.GetType("lib8.MyClass");

            Console.WriteLine("Информация о классе:");
            Console.WriteLine($"Имя класса: {myClassType.Name}");

            // Вывод полей
            Console.WriteLine("\nПоля:");
            foreach (FieldInfo field in myClassType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($"{field.FieldType.Name} {field.Name}");
            }

            // Вывод свойств
            Console.WriteLine("\nСвойства:");
            foreach (PropertyInfo property in myClassType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($"{property.PropertyType.Name} {property.Name}");
            }

            // Вывод методов
            Console.WriteLine("\nМетоды:");
            foreach (MethodInfo method in myClassType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine($"{method.ReturnType.Name} {method.Name}");
            }

            // Создание экземпляра класса через конструктор без параметров
            object instance = Activator.CreateInstance(myClassType);

            // Установка значений полей и свойств
            FieldInfo publicField = myClassType.GetField("PublicField", BindingFlags.Public | BindingFlags.Instance);
            publicField.SetValue(instance, 42);

            PropertyInfo publicProperty = myClassType.GetProperty("PublicProperty", BindingFlags.Public | BindingFlags.Instance);
            publicProperty.SetValue(instance, 100);

            // Чтение значений полей и свойств
            Console.WriteLine("\nЗначения полей и свойств:");
            Console.WriteLine($"PublicField: {publicField.GetValue(instance)}");
            Console.WriteLine($"PublicProperty: {publicProperty.GetValue(instance)}");

            // Вызов методов
            MethodInfo publicMethod = myClassType.GetMethod("PublicMethod", BindingFlags.Public | BindingFlags.Instance);
            publicMethod.Invoke(instance, null);

            // Вызов защищенного метода через рефлексию
            MethodInfo protectedMethod = myClassType.GetMethod("ProtectedMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            protectedMethod.Invoke(instance, null);

            // Вызов приватного метода через рефлексию
            MethodInfo privateMethod = myClassType.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethod.Invoke(instance, null);

            // Вызов конструктора с параметрами
            ConstructorInfo constructor = myClassType.GetConstructor(new[] { typeof(int), typeof(string), typeof(double) });
            object instanceWithParams = constructor.Invoke(new object[] { 1, "Test", 3.14 });

            // Чтение значений полей после вызова конструктора
            Console.WriteLine("\nЗначения полей после вызова конструктора:");
            Console.WriteLine($"PublicField: {publicField.GetValue(instanceWithParams)}");
        }
    }
}