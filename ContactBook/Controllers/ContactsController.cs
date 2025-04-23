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

        public List<GetContactDto> FindByName(string firstName)
        {
            return _repository.FindByName(firstName);
        }

        public void Update(UpdateContactDto dto)
        {
            // check if contact with given id doesnt exit throw excption

            Contact contact = _repository.FindById(dto.Id);
            contact.FirstName = dto.FirstName;
            contact.LastName = dto.LastName;
            contact.Email = dto.Email;
            contact.Phone = dto.Phone;

            _repository.Update(contact);
        }
    }
}
