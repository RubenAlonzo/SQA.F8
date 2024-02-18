namespace SQA.F8.Core.Services
{
    using SQA.F8.Core.Entities;

    public interface IContactServise
    {
        IEnumerable<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}