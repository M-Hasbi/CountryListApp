using Microsoft.AspNetCore.Mvc;
using Moq;
using NLayer.Core;
using NLayer.Web.Controllers;
using NLayer.Web.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NLayer.Test
{
    public class CountryBordersControllerTest
    {
        private readonly Mock<CountryBorderApiService> _countryBorderApiServiceMockRepo;
        private readonly Mock<CountryApiService> _countryApiServiceMockRepo;
        private readonly CountryBordersController _controller;
        private List<CountryBorder> countryBorders;
        public CountryBordersControllerTest()
        {
            _countryBorderApiServiceMockRepo = new Mock<CountryBorderApiService>();
            _countryApiServiceMockRepo = new Mock<CountryApiService>();
            _controller = new CountryBordersController(_countryApiServiceMockRepo.Object, _countryBorderApiServiceMockRepo.Object);
            countryBorders = new List<CountryBorder>()
            {
            new CountryBorder{ Id = 1,
                CountryId = 1,
                Name1 = "USA",
                Name2 = "CAN",
                CreatedDate = DateTime.Now },
            new CountryBorder
                {
                    Id = 2,
                CountryId = 2,
                Name1 = "USA",
                Name2 = "MEX",
                CreatedDate = DateTime.Now
                },
            new CountryBorder
            {Id = 3,
                 CountryId = 3,
                 Name1 = "USA",
                 Name2 = "MEX",
                 Name3 = "BLZ",
                 CreatedDate = DateTime.Now
            }};
        }
        [Fact]
        public async Task GetCountryBordersWithCountryAsync_ActionExecutes_ReturnViewWithGetCountryBordersWithCountryAsync()
        {
            _countryBorderApiServiceMockRepo.Setup(repo => repo.GetCountryBordersWithCountryAsync());
           
            var result = await _controller. ();

            Assert.IsType<ViewResult>(result);
        }
    }
}
