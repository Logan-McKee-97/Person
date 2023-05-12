namespace Person.Models.Persons
{
    public class CreatePersonDto
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string JobTitle { get; init; }

    }
}
