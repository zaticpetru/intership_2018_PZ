using System;
using System.Collections;
using System.Collections.Generic;

namespace LINQ_Examples
{
    class Person : IComparable
    {
        private bool isParent;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthContury { get; set; }
        public int PostCode { get; set; }
        public int Age { get; set; }
        public Ocupation tOcupation { get; set; }

        public List<string> Childrens;

        public bool Parent() { return isParent; }
        public Person(string name, string surname, 
                      string birthCountry, int postCode,
                      Ocupation ocupation, int age)
        {
            Name = name;
            Surname = surname;
            BirthContury = birthCountry;
            PostCode = postCode;
            tOcupation = ocupation;
            Age = age;
            isParent = false;
        }

        public Person(string name, string surname,
                      string birthContury, int postCode,
                      Ocupation ocupation, int age,
                      List<string> childrens)
        {
            Name = name;
            Surname = surname;
            BirthContury = birthContury;
            PostCode = postCode;
            tOcupation = ocupation;
            Age = age;
            Childrens = childrens;
            isParent = true;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + BirthContury + "\n" +
                   "Post Code = " + PostCode +
                   "\nAge = " + Age +
                   "\nOcupation = " + tOcupation.ToString();
        }

        public override int GetHashCode()
        {
            var hashCode = 1579553855;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BirthContury);
            hashCode = hashCode * -1521134295 + PostCode.GetHashCode();
           // hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + tOcupation.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   BirthContury == person.BirthContury &&
                   PostCode == person.PostCode &&
                   //Age == person.Age &&
                   tOcupation == person.tOcupation;
        }

        public int CompareTo(object obj)
        {
            var person = obj as Person;
            bool test = person != null &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   BirthContury == person.BirthContury &&
                   PostCode == person.PostCode &&
                   //Age == person.Age &&
                   tOcupation == person.tOcupation;
            if (test) return 0;
            else if (Age > person.Age) return 1;
            else return -1;
        }
    }
}
