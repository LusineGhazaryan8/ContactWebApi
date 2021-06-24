using ContactWebApi.Interfaces;
using ContactWebApi.Models;
using ContactWebApi.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository repository;

        public ContactService(IContactRepository repository)
        {
            this.repository = repository;
        }

        public  async Task<bool> Create(Contact entity)
        {
           return await repository.Save(entity);
        }

        public bool DeleteID(int id)
        {
            var contact = repository.GetByID(id);
            if (contact != null)
            {
                repository.DeleteById(id);
                return true;
            }
            else
                return false;
        }

        public Contact GetByID(int id)
        {
            return repository.GetByID(id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            var contacts = repository.List();
            return contacts;
        }

        public bool Update(Contact model)
        {
            var contact = repository.GetByID(model.ContactId);

            if (contact != null)
            {
                contact.FirstName = model.FirstName;
                contact.LastName = model.LastName;
                contact.Adress = model.Adress;
                contact.Email = model.Email;
                contact.PhoneNumber = model.PhoneNumber;
                repository.Update();
                return true;
            }
            else
                return false;
        }
    }
}
