using System;
using System.Runtime.CompilerServices;
using Lab1.Enums;

namespace Lab1
{
    public class Animal
    {
        private string _name;
        private int _age;
        private int _numberOfLegs;
        private TypeOfAnimal _type_of_animal;
        private Habitat _habitat;
        private Continent _continent;

        public string Name
        {
            get => _name;
        }

        public int Age
        {
            set => _age = value;
        }

        public Animal()
        {
            this._name = "Booba";
            this._age = 0;
            this._numberOfLegs = 0;
            this._type_of_animal = TypeOfAnimal.predator;
            this._habitat = Habitat.Ground;
            this._continent = Continent.Europe;
        }

        public Animal(string name, int age, int numberOfLegs, TypeOfAnimal typeOfAnimal, Habitat habitat, Continent continent)
        {
            this._name = name;
            this._age = age;
            this._numberOfLegs = numberOfLegs;
            this._type_of_animal = typeOfAnimal;
            this._habitat = habitat;
            this._continent = continent;
        }

        public static bool operator == (Animal animal1, Animal animal2)
        {
            if (animal1._type_of_animal == animal2._type_of_animal)
            {
                return true;
            }
            return false;
        }
        public static bool operator != (Animal animal1, Animal animal2)
        {
            if (animal1._type_of_animal != animal2._type_of_animal)
            {
                return true;
            }
            return false;
        }

        public string GetSound()
        {
            return "Arrgh!";
        }

        public bool CanFly()
        {
            return (_habitat == Habitat.Air);
        }

        public bool CanSwim()
        {
            return (_habitat == Habitat.Water);
        }

        public bool ExistTail()
        {
            return (_type_of_animal == TypeOfAnimal.predator);
        }
        
    }
};

