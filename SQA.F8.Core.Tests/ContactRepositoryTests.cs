namespace SQA.F8.Core.Tests
{
    using NUnit.Framework;
    using SQA.F8.Core.Entities;
    using SQA.F8.Core.Repositories;

    [TestFixture]
    public class ContactRepositoryTests
    {
        [Test]
        public void GetAllContacts_ReturnsEmpty_WhenNoContacts()
        {
            // Arrange
            var repository = new ContactRepository();

            // Act
            var contacts = repository.GetAllContacts();

            // Assert
            Assert.That(contacts, Is.Empty);
        }

        [Test]
        public void AddContact_AddsContact_WhenValidContact()
        {
            // Arrange
            var repository = new ContactRepository();
            var contact = new Contact { Id = 1, Name = "John", Email = "john@example.com" };

            // Act
            repository.AddContact(contact);
            var addedContact = repository.GetContactById(1);

            // Assert
            Assert.That(addedContact, Is.Not.Null);
            Assert.That(contact.Id, Is.EqualTo(addedContact.Id));
        }



        [Test]
        public void GetContactById_ReturnsNull_WhenContactNotFound()
        {
            // Arrange
            var repository = new ContactRepository();

            // Act
            var contact = repository.GetContactById(1);

            // Assert
            Assert.That(contact, Is.Null);
        }

        [Test]
        public void UpdateContact_UpdatesContact_WhenContactExists()
        {
            // Arrange
            var repository = new ContactRepository();
            var initialContact = new Contact { Id = 1, Name = "John", Email = "john@example.com" };
            repository.AddContact(initialContact);

            // Act
            var updatedContact = new Contact { Id = 1, Name = "Jane", Email = "jane@example.com" };
            repository.UpdateContact(updatedContact);
            var retrievedContact = repository.GetContactById(1);

            // Assert
            Assert.That(retrievedContact, Is.Not.Null);
            Assert.That(updatedContact.Name, Is.EqualTo(retrievedContact.Name));
            Assert.That(updatedContact.Email, Is.EqualTo(retrievedContact.Email));
        }

        [Test]
        public void DeleteContact_RemovesContact_WhenContactExists()
        {
            // Arrange
            var repository = new ContactRepository();
            var contact = new Contact { Id = 1, Name = "John", Email = "john@example.com" };
            repository.AddContact(contact);

            // Act
            repository.DeleteContact(1);
            var deletedContact = repository.GetContactById(1);

            // Assert
            Assert.That(deletedContact, Is.Null);
        }

        [Test]
        public void DeleteContact_DoesNotThrowException_WhenContactDoesNotExist()
        {
            // Arrange
            var repository = new ContactRepository();

            // Act & Assert
            Assert.DoesNotThrow(() => repository.DeleteContact(1));
        }

        [Test]
        public void AddContact_ThrowsException_WhenContactIsNull()
        {
            // Arrange
            var repository = new ContactRepository();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repository.AddContact(null));
        }

        [Test]
        public void UpdateContact_ThrowsException_WhenContactIsNull()
        {
            // Arrange
            var repository = new ContactRepository();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repository.UpdateContact(null));
        }
    }
}
