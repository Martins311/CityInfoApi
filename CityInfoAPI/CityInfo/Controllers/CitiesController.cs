using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.API;
using CityInfo.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{   
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInforepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInforepository = cityInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetCities()
        {
           
            var cityEntities = _cityInforepository.GetCities();

            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);

            return Ok(results);
        }


        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInforepository.GetCity(id, includePointsOfInterest);

            if(city == null)
            {
                return NotFound();
            }
            if (includePointsOfInterest)
            {
                var cityResult = Mapper.Map<CityDto>(city);
                return Ok(cityResult);

            }
            var CityWithoutPointsOfInterestResult = Mapper.Map<CityWithoutPointsOfInterestDto>(city);
            return Ok(CityWithoutPointsOfInterestResult);

            
        }
    }
}