using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var featureList = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(featureList);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature
            {
                FirstTitle = createFeatureDto.FirstTitle,
                SecondTitle = createFeatureDto.SecondTitle,
                LastTitle = createFeatureDto.LastTitle,
                FirstDesc = createFeatureDto.FirstDesc,
                SecondDesc = createFeatureDto.SecondDesc,
                LastDesc = createFeatureDto.LastDesc,

            });
            return Ok("Öne Çıkan bilgisi başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var deleteToFeature = _featureService.TGetById(id);
            _featureService.TDelete(deleteToFeature);
            return Ok("Öne Çıkan bilgisi başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature
            {
                FeatureID = updateFeatureDto.FeatureID,
                FirstTitle = updateFeatureDto.FirstTitle,
                SecondTitle = updateFeatureDto.SecondTitle,
                LastTitle = updateFeatureDto.LastTitle,
                FirstDesc = updateFeatureDto.FirstDesc,
                SecondDesc = updateFeatureDto.SecondDesc,
                LastDesc = updateFeatureDto.LastDesc,
            });
            return Ok("Öne Çıkan bilgisi başarıyla güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var feature = _featureService.TGetById(id);
            return Ok(feature);
        }
    }
}
