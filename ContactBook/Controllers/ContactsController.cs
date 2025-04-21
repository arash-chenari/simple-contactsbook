using ContactBook.Models;

namespace ContactBook.Controllers
{
    public class ContactsController
    {
        private readonly IContactRepository _repository;
        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        public void Add(AddContactDto dto)
        {
            // check phone is correct
            // check email is correct

            var model = new Contact
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
            };

            _repository.Add(model);
        }
    }
}
