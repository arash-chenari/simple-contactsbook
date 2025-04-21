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
    }
}
