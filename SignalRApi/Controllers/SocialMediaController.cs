﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var socialMediaList = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(socialMediaList);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia
            {
                Icon=createSocialMediaDto.Icon,
                Title=createSocialMediaDto.Title,
                Url=createSocialMediaDto.Url,

            });
            return Ok("Sosyal Medya hesabı başarıyla eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var deleteToSocialMedia = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(deleteToSocialMedia);
            return Ok("Sosyal Medya hesabı başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia
            {
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,

            });
            return Ok("Sosyal Medya hesabı başarıyla güncellendi!");
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var socialMedia = _socialMediaService.TGetById(id);
            return Ok(socialMedia);
        }
    }
}
