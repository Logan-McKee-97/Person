namespace Person.Models.Persons
{
    public class Person
    {
        public Person(Guid id, string firstName, string lastName, string jobTitle)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
    }
}
