// See https://aka.ms/new-console-template for more information

using System;
using Lab1.Enums;
namespace Lab1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Animal animal1 = new Animal();
            Animal animal2 = new Animal("Cat", 3, 4, TypeOfAnimal.herbivorous, Habitat.Ground, Continent.Europe);
            Animal animal3 = new Animal("Monkey", 10, 4, TypeOfAnimal.herbivorous, Habitat.Ground, Continent.Africa);
            
            
            Console.WriteLine(animal1.GetSound());
            Console.WriteLine(animal1.Name);
            Console.WriteLine(animal2.Name);
            
            animal3.Age = 30;
            
            Console.WriteLine(animal3.GetSound());


            Figure triangle = new Figure(TypeOfFigure.Triangle, 4);
            Console.WriteLine(triangle.Square);
            Figure rectangle = new Figure(TypeOfFigure.Rectangle, 4);
            Console.WriteLine(rectangle.Square);
            Figure pentagon = new Figure(TypeOfFigure.Pentagon, 4);
            Console.WriteLine(pentagon.Square);
            Figure octagon = new Figure(TypeOfFigure.Octagon, 4);
            Console.WriteLine(octagon.Square);
            
            
        }
    }
}