namespace YouShallNotPass
{
    class Owner
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsJuridic { get; set; }
        public Owner(string name, string surname, bool isJuridic)
        {
            Name = name;
            Surname = surname;
            IsJuridic = isJuridic;
        }
    }
}
