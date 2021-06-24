using System.Collections.Generic;
using System.Threading.Tasks;
using ContactWebApi.Interfaces;
using ContactWebApi.Models;

namespace ContactWebApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;
        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> Contacts => this._context.Contacts;

        public async Task<bool> Save( Contact entity)
        {
            await _context.Contacts.AddAsync(entity);
            await  _context.SaveChangesAsync();
            return true;
        }

        public bool DeleteById(int id)
        {
            _context.Remove(_context.Find<Contact>(id));
            _context.SaveChanges();
            return true;
        }

        public Contact GetByID(int id)
        {
            return this._context.Find<Contact>(id);
        }

        public IEnumerable<Contact> List()
        {
            return this._context.Contacts;
        }

        public void Update()
        {
            _context.SaveChanges();
        }



    }
}
