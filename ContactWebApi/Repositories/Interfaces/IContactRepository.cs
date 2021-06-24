using System.Collections.Generic;
using ContactWebApi.Interfaces.Repositories;
using ContactWebApi.Models;

namespace ContactWebApi.Interfaces
{
   public interface IContactRepository:IRepository<Contact>
    {
       
    }
}
