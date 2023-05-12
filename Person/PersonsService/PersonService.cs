namespace Person.PersonsService;

using Microsoft.EntityFrameworkCore;
using Person.Database;
using Person.Models.Persons;

public class PersonService
{
    private readonly ApplicationDbContext _context;

    public PersonService(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool Create(CreatePersonDto personDto)
    {
        Person person = new(Guid.NewGuid(), personDto.FirstName, personDto.LastName, personDto.JobTitle);
        _context.People.Add(person);
        int rowsAffected = _context.SaveChanges();
        return rowsAffected > 0;
    }

    public Person? GetPersonById(Guid id)
    {
        Person? person = _context.People.Where(p => p.Id == id).FirstOrDefault();
        return person;
    }

    public Person[] GetAllPeople()
    {
        return _context.People.ToArray();
    }

    public bool Edit(EditPersonDto personDto)
    {
        Person? person = GetPersonById(personDto.Id);
        if (person is null)
        {
            return false;
        }

        person.FirstName = personDto.FirstName;
        person.LastName = personDto.LastName;
        person.JobTitle = personDto.JobTitle;

        int rowsAffected = _context.SaveChanges();
        return rowsAffected > 0;
    }

    public bool Delete(Guid id)
    {
        int rowsAffected = _context.People.Where(p => p.Id == id).ExecuteDelete();
        return rowsAffected > 0;
    }
}


