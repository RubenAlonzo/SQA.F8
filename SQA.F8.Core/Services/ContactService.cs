namespace SQA.F8.Core.Services
{
    using SQA.F8.Core.Entities;
    using SQA.F8.Core.Repositories;
    using System;
    using System.Collections.Generic;

    public class ContactService : IContactServise
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public Contact? GetContactById(int id)
        {
            return _contactRepository.GetContactById(id);
        }

        public void AddContact(Contact contact)
        {
            _contactRepository.AddContact(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _contactRepository.UpdateContact(contact);
        }

        public void DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
        }
    }
}
