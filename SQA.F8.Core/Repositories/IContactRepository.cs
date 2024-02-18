namespace SQA.F8.Core.Repositories
{
    using SQA.F8.Core.Entities;
    using System.Collections.Generic;

    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}
