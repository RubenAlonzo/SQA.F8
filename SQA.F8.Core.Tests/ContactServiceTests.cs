namespace SQA.F8.Core.Tests
{
    using Moq;
    using NUnit.Framework;
    using SQA.F8.Core.Entities;
    using SQA.F8.Core.Repositories;
    using SQA.F8.Core.Services;

    [TestFixture]
    public class ContactServiceTests
    {
        [Test]
        public void GetAllContacts_ReturnsEmpty_WhenNoContacts()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            mockRepository.Setup(repo => repo.GetAllContacts()).Returns(new List<Contact>());

            var service = new ContactService(mockRepository.Object);

            // Act
            var contacts = service.GetAllContacts();

            // Assert
            Assert.That(contacts, Is.Empty);
        }

        [Test]
        public void Constructor_ThrowsException_WhenContactRepositoryIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ContactService(null));
        }

        [Test]
        public void AddContact_AddsContact_WhenValidContact()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            var service = new ContactService(mockRepository.Object);
            var contact = new Contact { Id = 1, Name = "John", Email = "john@example.com" };

            // Act
            service.AddContact(contact);

            // Assert
            mockRepository.Verify(repo => repo.AddContact(contact), Times.Once);
        }

        [Test]
        public void GetContactById_ReturnsContact_WhenContactExists()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            var service = new ContactService(mockRepository.Object);
            var expectedContact = new Contact { Id = 1, Name = "John", Email = "john@example.com" };
            mockRepository.Setup(repo => repo.GetContactById(1)).Returns(expectedContact);

            // Act
            var actualContact = service.GetContactById(1);

            // Assert
            Assert.That(actualContact, Is.Not.Null);
            Assert.That(expectedContact.Id, Is.EqualTo(actualContact.Id));
        }

        [Test]
        public void GetContactById_ReturnsNull_WhenContactDoesNotExist()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            var service = new ContactService(mockRepository.Object);
            mockRepository.Setup(repo => repo.GetContactById(1)).Returns((Contact)null);

            // Act
            var contact = service.GetContactById(1);

            // Assert
            Assert.That(contact, Is.Null);
        }

        [Test]
        public void UpdateContact_UpdatesContact_WhenContactExists()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            var service = new ContactService(mockRepository.Object);
            var existingContact = new Contact { Id = 1, Name = "John", Email = "john@example.com" };
            var updatedContact = new Contact { Id = 1, Name = "Jane", Email = "jane@example.com" };
            mockRepository.Setup(repo => repo.GetContactById(1)).Returns(existingContact);

            // Act
            service.UpdateContact(updatedContact);

            // Assert
            mockRepository.Verify(repo => repo.UpdateContact(updatedContact), Times.Once);
        }

        [Test]
        public void DeleteContact_DeletesContact_WhenContactExists()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            var service = new ContactService(mockRepository.Object);
            mockRepository.Setup(repo => repo.GetContactById(1)).Returns(new Contact { Id = 1, Name = "John", Email = "john@example.com" });

            // Act
            service.DeleteContact(1);

            // Assert
            mockRepository.Verify(repo => repo.DeleteContact(1), Times.Once);
        }

        [Test]
        public void DeleteContact_DoesNotThrowException_WhenContactDoesNotExist()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            var service = new ContactService(mockRepository.Object);
            mockRepository.Setup(repo => repo.GetContactById(1)).Returns((Contact)null);

            // Act & Assert
            Assert.DoesNotThrow(() => service.DeleteContact(1));
        }
    }
}
