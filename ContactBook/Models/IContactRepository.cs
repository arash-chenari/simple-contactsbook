namespace ContactBook.Models
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        Contact FindById(int id);
        List<GetContactDto> FindByName(string firstName);
        void Update(Contact contact);
    }
}
