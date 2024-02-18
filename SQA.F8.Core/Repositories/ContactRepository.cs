namespace SQA.F8.Core.Repositories
{
    using SQA.F8.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts;

        public ContactRepository()
        {
            _contacts = new List<Contact>();
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact? GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            _contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            var existingContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.Name = contact.Name;
                existingContact.Email = contact.Email;
                existingContact.Phone = contact.Phone;
            }
        }

        public void DeleteContact(int id)
        {
            var contactToRemove = _contacts.FirstOrDefault(c => c.Id == id);
            if (contactToRemove != null)
            {
                _contacts.Remove(contactToRemove);
            }
        }
    }
}
