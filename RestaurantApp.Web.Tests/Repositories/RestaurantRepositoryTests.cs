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
            var repository = new RestaurantRepository();

            // Act
            repository.Create(restaurant);

            // Assert
            var restaurants = repository.GetAll();
            restaurants.Count().Should().Be(1);
        }

        [Fact]
        public void GetById_ShouldGetRestaurantById()
        {
            // Arrange
            var restaurant = new Restaurant() { Id = 1};
            var repository = new RestaurantRepository();
            repository.Create(restaurant);

            // Act
            var result = repository.GetById(1);

            // Assert
            result.Id.Should().Be(1);
        }
    }
}
