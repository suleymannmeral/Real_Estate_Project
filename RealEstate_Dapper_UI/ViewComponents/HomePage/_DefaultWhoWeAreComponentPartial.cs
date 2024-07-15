﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial:ViewComponent 
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/WhoWeAre");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
           var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDtos>>(jsonData);
                if (value == null)
                {
                    throw new Exception("Hata Oluitu");
                }
                ViewBag.Title = value.Select(x=> x.Title).FirstOrDefault();
                ViewBag.SubTitle = value.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.Desc1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.Desc2 = value.Select(x => x.Description2).FirstOrDefault();


                return View();
                
            }

            return View();
        }
    }
}
