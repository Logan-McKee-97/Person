using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Person.Models.Persons;
using Person.PersonsService;
namespace Person.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            Models.Persons.Person[] people = _personService.GetAllPeople();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonDto person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            bool success = _personService.Create(person);

            if (success)
            {
                TempData.Add("SuccessMessage", $"Person {person.FirstName} {person.LastName} was created");

                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(Guid id) {
            Models.Persons.Person? person = _personService.GetPersonById(id);

            if(person is null)
            {
                return NotFound();
            }

            EditPersonDto personDto = new()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                JobTitle = person.JobTitle,
            };

            return View(personDto);
        }

        [HttpPost]
        public IActionResult Edit(EditPersonDto editPersonDto)
        {
            if (!ModelState.IsValid)
            {
                View(editPersonDto);
            }
            bool success = _personService.Edit(editPersonDto);

            if (success)
            {
                TempData.Add("SuccessMessage", $"Person {editPersonDto.FirstName} {editPersonDto.LastName} was updated");
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Delete(Guid id)
        {
            bool success = _personService.Delete(id); 

            if (!success)
            {
                return NotFound();
            }

            TempData.Add("SuccessMessage", "A person was deleted");
            return RedirectToAction(nameof(Index));
        }
    }
}

