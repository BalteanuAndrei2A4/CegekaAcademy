using CarDealership.Data;
using CarDealership.Data.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WebCarDealership.Controllers;
using WebCarDealership.Requests;
using Xunit;

namespace OrderControllerTests
{
    public class OrderControllerTests
    {
        private readonly Mock<IRepository> repoMock;
        private readonly OrderController controllerSut;

        public OrderControllerTests()
        {
            repoMock = new Mock<IRepository>();
            controllerSut = new OrderController(repoMock.Object);
        }
        [Fact]
        public async Task GivenAValidRequestModel_WhenCallingPost_ThenGettingAnyResponse()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Andrei Model"
            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().NotBeNull();
        }

        
        [Fact]
        public async Task GivenAValidRequestModel_WhenCallingPost_ThenGettingOkResponse()
        {
            ////Arange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Andrei model",
                AvailableStock = 12
            };

            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                CustomerId = 1,
                Quantity =1
            };

            //Act
            var result = await controllerSut.Post(requestModel);


            //Asert

            result.Should().BeOfType<OkObjectResult>();

        }


        [Fact]
        public async Task GivenAnInvalidRequestModel_WhenCallingPost_ThenGettingBadRequest()
        {
            //////Arange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Andrei model"
            };

            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
               
            };

            //Act
            var result = await controllerSut.Post(requestModel);


            //Asert

            result.Should().BeOfType<BadRequestObjectResult>();
        }
        
        
        [Fact]
        public async Task GivenAnInvalidCarOfferId_WhenCallingPost_ThenGetNotFound()
        {
            //Arrange
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync((CarOffer)null);
            var requestModel = new OrderRequestModel();

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            
            result.As<NotFoundObjectResult>().Value.Should().Be("car offer not found");
        }
        [Fact]
        public async Task GivenAnInvalidQuantity_WhenCallingPost_ThenGettingBadRequestNotEnoughCars()
        {
            ////Arange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Andrei model",
                AvailableStock = 99
            };

            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                CustomerId = 1,
                Quantity = 1000,
            };

            //Act
            var result = await controllerSut.Post(requestModel);


            //Asert
            result.As<BadRequestObjectResult>().Value.Should().Be("Not enough cars of this model are available in stock!");
        }
    }
}