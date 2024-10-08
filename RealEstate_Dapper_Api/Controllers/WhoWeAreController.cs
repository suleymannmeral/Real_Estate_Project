﻿using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class WhoWeAreController : ControllerBase
    {

        private readonly IWhoWeAreRepository _whoweareRepository;

        public WhoWeAreController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoweareRepository = whoWeAreRepository;
        }

        [HttpGet]

        public async Task<IActionResult> WhoWeAreList()
        {
            var values = await _whoweareRepository.GetAllWhoWeAreAsync();
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto whoWeAreDto)
        {
            await _whoweareRepository.CreateWhoWeAre(whoWeAreDto);
            return Ok("Detail Başarılı Bİr Şekilde Eklend");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAre(int id)
        {
           await _whoweareRepository.DeleteWhoWeAre(id);
            return Ok("Detail Başarılı Bİr Şekilde Silindi");
        }
        [HttpPut]

        public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto whoWeAreDto)
        {
           await _whoweareRepository.UpdateWhoWeAre(whoWeAreDto);
            return Ok("Güncelleme Başarılı");

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetWhoWeAre(int id)
        {
            var values = await _whoweareRepository.GetWhoWeAre(id);
            return Ok(values);
        }
    }
}
