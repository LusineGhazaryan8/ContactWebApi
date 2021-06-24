using ContactWebApi.Models.ViewModels;
using ContactWebApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContactWebApi.Services;
using AutoMapper;

namespace ContactWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactService _service;
        public ContactController(IContactService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IEnumerable<ViewContacViewModel> GetContacts()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ViewContacViewModel>());
            var mapper = new Mapper(config);
            var contactsmaper = mapper.Map<IEnumerable<ViewContacViewModel>>(_service.GetContacts());
            return contactsmaper;
        }

        [HttpGet("{id}")]
        public ViewContacViewModel GetContactById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ViewContacViewModel>());
            var mapper = new Mapper(config);
            var contactsmaper = mapper.Map<ViewContacViewModel>(_service.GetByID(id));
            return contactsmaper;
        }

        [HttpPut("{id}")]
        public void EditContact(int id,[FromBody] EditContactViewModel model )
        {
            if (ModelState.IsValid)
            {
                if (id == model.ContactId)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<EditContactViewModel, Contact>());
                    var mapper = new Mapper(config);
                    Contact contact = mapper.Map<EditContactViewModel, Contact>(model);
                    _service.Update(contact);
                }
            }       
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteID(id);
        }

        [HttpPost]
        public void Create([FromBody] CreateContacViewModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateContacViewModel, Contact>());
            var mapper = new Mapper(config);
            var contac= mapper.Map<CreateContacViewModel,Contact>(model);
            _service.Create(contac);
        }

    }
}
