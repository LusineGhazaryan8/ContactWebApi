using System.Collections.Generic;
using System.Threading.Tasks;
using ContactWebApi.Models;
using ContactWebApi.Models.ViewModels;

namespace ContactWebApi.Services
{
  public   interface IContactService
    {
        IEnumerable<Contact> GetContacts();
        bool DeleteID(int id);
        Contact GetByID(int id);
        bool Update(Contact entity);
        Task<bool> Create(Contact entity);
    }
}
