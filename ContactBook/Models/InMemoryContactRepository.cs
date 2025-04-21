namespace ContactBook.Models
{
    public class InMemoryContactRepository : IContactRepository
    {
        private static List<Contact> _contacts = new List<Contact>();
        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }
    }
}
