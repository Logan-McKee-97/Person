namespace Person.Models.Persons
{
    public class EditPersonDto : CreatePersonDto 
    {
        public required Guid Id { get; set; }
    }
}
