namespace Person.PersonsService;
using Person.Models.Persons;

public class PersonService
{
    private readonly Dictionary<Guid, Person> _peopleDic;

    public PersonService()
    {
        Person seedPerson = new(Guid.NewGuid(), "test", "Person", "Tester");
        _peopleDic = new()
        {
            {seedPerson.Id, seedPerson }

            };
        }
    public bool Create(CreatePersonDto personDto)
    {
        Person person = new(Guid.NewGuid(), personDto.FirstName, personDto.LastName, personDto.JobTitle);
        return _peopleDic.TryAdd(person.Id, person);
    }

    public Person? GetPersonById(Guid id)
    {
        _peopleDic.TryGetValue(id, out Person? person);
        return person;
    }

    public Person[] GetAllPeople()
    {
        return _peopleDic.Values.ToArray();
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

        return true;
    }

    public bool Delete(Guid id)
    {
        return _peopleDic.Remove(id);
    }
}


