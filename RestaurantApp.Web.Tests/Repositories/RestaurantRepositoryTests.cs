using FluentAssertions;
using RestaurantApp.Web.Entities;
using RestaurantApp.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Web.Tests.Repositories
{
    public class RestaurantRepositoryTests
    {
        [Fact]
        public void Create_ShouldCreateRestaurant()
        {
            // Arrange
            var restaurant = new Restaurant();

            // Act
            RestaurantRepository.Create(restaurant);

            // Assert
            var restaurants = RestaurantRepository.GetAll();
            restaurants.Count().Should().Be(1);
        }

        [Fact]
        public void GetById_ShouldGetRestaurantById()
        {
            // Arrange
            var restaurant = new Restaurant() { Id = 1};
            RestaurantRepository.Create(restaurant);

            // Act
            var result = RestaurantRepository.GetById(1);

            // Assert
            result.Id.Should().Be(1);
        }
    }
}
