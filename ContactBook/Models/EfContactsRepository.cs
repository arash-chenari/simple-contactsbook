using Microsoft.EntityFrameworkCore;

namespace ContactBook.Models
{
    public class EfContactsRepository : IContactRepository
    {
        private ApplicationDbContext _context;

        public EfContactsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Contact contact)
        {
           _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public Contact FindById(int id)
        {
            var contact = _context.Contacts.Find(id);
            return contact;
        }

        public List<GetContactDto> FindByName(string firstName)
        {
            var contact = _context.Contacts
                .Where(_ => _.FirstName == firstName)
                .Select(_ => new GetContactDto
                {
                    FirstName = _.FirstName,
                    LastName = _.LastName,
                    PhoneNumber = _.Phone,
                    Email = _.Email,
                    Id = _.Id
                }).ToList();

            return contact;
        }

        public void Update(Contact contact)
        {
            _context.SaveChanges();
        }
    }
}
