namespace FuncP
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public Person() { }

        public Person(string name, string surname, int age, int height)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Height = height;
        }

        public override string ToString()
        {
            return  "Name = " + Name +
                    " Surname = " + Surname +
                    " Age = " + Age +
                    " Height = " + Height;
        }

        public static bool AgeCompare(object a, object b)
        {
            return ((Person)a).Age > ((Person)b).Age;
        }
    }

}
