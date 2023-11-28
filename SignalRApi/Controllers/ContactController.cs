using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var contactList = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(contactList);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                FooterDescription = createContactDto.FooterDescription,
                Phone = createContactDto.Phone,

            });
            return Ok("İletişim Eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var deleteToContact = _contactService.TGetById(id);
            _contactService.TDelete(deleteToContact);
            return Ok("İletişim başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContactDto.ContactID,
                Location = updateContactDto.Location,
                Mail = updateContactDto.Mail,
                FooterDescription = updateContactDto.FooterDescription,
                Phone = updateContactDto.Phone,
            });
            return Ok("İletişim başarıyla güncellendi!");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var contact = _mapper.Map<ResultContactDto>(_contactService.TGetById(id));
            return Ok(contact);
        }


    }
}

