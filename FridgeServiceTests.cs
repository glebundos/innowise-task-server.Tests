using FakeItEasy;
using innowise_task_server.Data;
using innowise_task_server.Models;
using innowise_task_server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innowise_task_server.Tests
{
    public class FridgeServiceTests
    {
        [Fact]
        public async Task GetFridges_ReturnOK()
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<Fridge> fridges = new List<Fridge>()
            {
                new Fridge(),
                new Fridge(),
                new Fridge()
            };
            serverDbContextMock.Setup(x => x.Fridges).ReturnsDbSet(fridges);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridges();

            ///
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetFridges_ReturnCorrect()
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<Fridge> fridges = new List<Fridge>() 
            {
                new Fridge(),
                new Fridge(),
                new Fridge()
            };
            serverDbContextMock.Setup(x => x.Fridges).ReturnsDbSet(fridges);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridges();

            ///
            var result = actionResult as OkObjectResult;
            var returnedFridges = result.Value as List<Fridge>;
            Assert.Equal(fridges, returnedFridges);
        }

        [Theory]
        [InlineData("e71ae131-bccd-4c3f-a1a1-4708227d3278")]
        [InlineData("0016407d-230a-4867-a932-f3ed9afbc976")]
        [InlineData("33f5bf36-bf73-4fba-8a3e-7f0bfc792421")]
        public async Task GetFridgeById_ReturnsOK(Guid id)
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<Fridge> fridges = new List<Fridge>()
            {
                new Fridge{ ID = id},
                new Fridge{ ID = Guid.NewGuid()},
            };
            serverDbContextMock.Setup(x => x.Fridges).ReturnsDbSet(fridges);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridgeById(id);

            ///
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Theory]
        [InlineData("e71ae131-bccd-4c3f-a1a1-4708227d3278")]
        [InlineData("0016407d-230a-4867-a932-f3ed9afbc976")]
        [InlineData("33f5bf36-bf73-4fba-8a3e-7f0bfc792421")]
        public async Task GetFridgeById_ReturnsNotFound(Guid id)
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<Fridge> fridges = new List<Fridge>()
            {
                new Fridge{ ID = Guid.NewGuid()},
            };
            serverDbContextMock.Setup(x => x.Fridges).ReturnsDbSet(fridges);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridgeById(id);

            ///
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Theory]
        [InlineData("e71ae131-bccd-4c3f-a1a1-4708227d3278")]
        [InlineData("0016407d-230a-4867-a932-f3ed9afbc976")]
        [InlineData("33f5bf36-bf73-4fba-8a3e-7f0bfc792421")]
        public async Task GetFridgeById_ReturnsCorrect(Guid id)
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<Fridge> fridges = new List<Fridge>()
            {
                new Fridge{ ID = id},
                new Fridge{ ID = Guid.NewGuid()},
            };
            serverDbContextMock.Setup(x => x.Fridges).ReturnsDbSet(fridges);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridgeById(id);

            ///
            var result = actionResult as OkObjectResult;
            var actualFridge = result.Value as Fridge;
            Assert.Equal(fridges[0], actualFridge);
        }

        [Theory]
        [InlineData("e71ae131-bccd-4c3f-a1a1-4708227d3278")]
        [InlineData("0016407d-230a-4867-a932-f3ed9afbc976")]
        [InlineData("33f5bf36-bf73-4fba-8a3e-7f0bfc792421")]
        public async Task GetFridgeProductById_ReturnsOK(Guid id)
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<FridgeProduct> fridgeProducts = new List<FridgeProduct>()
            {
                new FridgeProduct{ ID = id},
                new FridgeProduct()
            };
            serverDbContextMock.Setup(x => x.FridgeProducts).ReturnsDbSet(fridgeProducts);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridgeProductById(id);

            ///
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Theory]
        [InlineData("e71ae131-bccd-4c3f-a1a1-4708227d3278")]
        [InlineData("0016407d-230a-4867-a932-f3ed9afbc976")]
        [InlineData("33f5bf36-bf73-4fba-8a3e-7f0bfc792421")]
        public async Task GetFridgeProductById_ReturnsNotFound(Guid id)
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<FridgeProduct> fridgeProducts = new List<FridgeProduct>()
            {
                new FridgeProduct{ ID = Guid.NewGuid() },
                new FridgeProduct()
            };
            serverDbContextMock.Setup(x => x.FridgeProducts).ReturnsDbSet(fridgeProducts);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridgeProductById(id);

            ///
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Theory]
        [InlineData("e71ae131-bccd-4c3f-a1a1-4708227d3278")]
        [InlineData("0016407d-230a-4867-a932-f3ed9afbc976")]
        [InlineData("33f5bf36-bf73-4fba-8a3e-7f0bfc792421")]
        public async Task GetFridgeProductById_ReturnsCorrect(Guid id)
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<FridgeProduct> fridgeProducts = new List<FridgeProduct>()
            {
                new FridgeProduct{ ID = id},
                new FridgeProduct()
            };
            serverDbContextMock.Setup(x => x.FridgeProducts).ReturnsDbSet(fridgeProducts);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridgeProductById(id);

            ///
            var result = actionResult as OkObjectResult;
            var returnedFridgeProduct = result.Value as FridgeProduct;
            Assert.Equal(fridgeProducts[0], returnedFridgeProduct);
        }

        [Theory]
        [InlineData("e71ae131-bccd-4c3f-a1a1-4708227d3278")]
        [InlineData("0016407d-230a-4867-a932-f3ed9afbc976")]
        [InlineData("33f5bf36-bf73-4fba-8a3e-7f0bfc792421")]
        public async Task GetFridgeProductsById_ReturnsOK(Guid id)
        {
            ///

            IList<FridgeProduct> expectedFridgeProducts = new List<FridgeProduct>()
            {
                new FridgeProduct(),
                new FridgeProduct(),
                new FridgeProduct()
            };

            IList<Fridge> fridges = new List<Fridge>()
            {
                new Fridge { ID = id, Products = expectedFridgeProducts },
                new Fridge(),
                new Fridge()
            };

            var serverDbContextMock = new Mock<ServerDbContext>();

            serverDbContextMock.Setup(x => x.Fridges).ReturnsDbSet(fridges);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridgeProductsById(id);

            ///
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Theory]
        [InlineData("e71ae131-bccd-4c3f-a1a1-4708227d3278")]
        [InlineData("0016407d-230a-4867-a932-f3ed9afbc976")]
        [InlineData("33f5bf36-bf73-4fba-8a3e-7f0bfc792421")]
        public async Task GetFridgeProductsById_ReturnsNotFound(Guid id)
        {
            ///
            IList<Fridge> fridges = new List<Fridge>()
            {
                new Fridge{ ID = id },
                new Fridge(),
                new Fridge()
            };

            var serverDbContextMock = new Mock<ServerDbContext>();

            serverDbContextMock.Setup(x => x.Fridges).ReturnsDbSet(fridges);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridgeProductsById(id);

            ///
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Theory]
        [InlineData("e71ae131-bccd-4c3f-a1a1-4708227d3278")]
        [InlineData("0016407d-230a-4867-a932-f3ed9afbc976")]
        [InlineData("33f5bf36-bf73-4fba-8a3e-7f0bfc792421")]
        public async Task GetFridgeProductsById_ReturnsCorrect(Guid id)
        {
            ///
            IList<FridgeProduct> expectedFridgeProducts = new List<FridgeProduct>()
            {
                new FridgeProduct(),
                new FridgeProduct(),
                new FridgeProduct()
            };

            IList<Fridge> fridges = new List<Fridge>()
            {
                new Fridge { ID = id, Products = expectedFridgeProducts },
                new Fridge(),
                new Fridge()
            };

            var serverDbContextMock = new Mock<ServerDbContext>();

            serverDbContextMock.Setup(x => x.Fridges).ReturnsDbSet(fridges);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetFridgeProductsById(id);

            ///
            var result = actionResult as OkObjectResult;
            var actualFridgeProducts = result.Value as List<FridgeProduct>;
            Assert.Equal(expectedFridgeProducts, actualFridgeProducts);
        }

        [Fact]
        public async Task GetModels_ReturnsOK()
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<FridgeModel> fridgeModels = new List<FridgeModel>()
            {
                new FridgeModel(),
                new FridgeModel(),
                new FridgeModel()
            };
            serverDbContextMock.Setup(x => x.FridgeModels).ReturnsDbSet(fridgeModels);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetModels();

            ///
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetModels_ReturnsCorrect()
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<FridgeModel> fridgeModels = new List<FridgeModel>()
            {
                new FridgeModel(),
                new FridgeModel(),
                new FridgeModel()
            };
            serverDbContextMock.Setup(x => x.FridgeModels).ReturnsDbSet(fridgeModels);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetModels();

            ///
            var result = actionResult as OkObjectResult;
            var returnedModels = result.Value as List<FridgeModel>;
            Assert.Equal(fridgeModels, returnedModels);
        }

        [Fact]
        public async Task GetProducts_ReturnsOK()
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<Product> products = new List<Product>()
            {
                new Product(),
                new Product(),
                new Product()
            };
            serverDbContextMock.Setup(x => x.Products).ReturnsDbSet(products);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetProducts();

            ///
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetProducts_ReturnsCorrect()
        {
            ///
            var serverDbContextMock = new Mock<ServerDbContext>();
            IList<Product> products = new List<Product>()
            {
                new Product(),
                new Product(),
                new Product()
            };
            serverDbContextMock.Setup(x => x.Products).ReturnsDbSet(products);
            var service = new FridgeService(serverDbContextMock.Object);

            ///
            var actionResult = await service.GetProducts();

            ///
            var result = actionResult as OkObjectResult;
            var returnedProducts = result.Value as List<Product>;
            Assert.Equal(products, returnedProducts);
        }

        [Fact]
        public async Task AddProduct_ReturnsCreatedAtAction()
        {
            ///
            var fridgeProductsMock = new Mock<DbSet<FridgeProduct>>();
            var product = new Product { Name = "Product", DefaultQuantity = 1};

            fridgeProductsMock.Setup(_ => _.AddAsync(It.IsAny<FridgeProduct>(), It.IsAny<CancellationToken>()))
                .Callback((FridgeProduct model, CancellationToken cancellationToken) => { })
                .Returns((FridgeProduct model, CancellationToken cancellationToken) => ValueTask.FromResult((EntityEntry<FridgeProduct>)null));
            var mockContext = new Mock<ServerDbContext>();
            mockContext.Setup(x => x.FridgeProducts).Returns(fridgeProductsMock.Object);
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));

            var service = new FridgeService(mockContext.Object);

            ///
            var actionResult = await service.AddProduct(product, Guid.NewGuid());

            ///
            Assert.IsType<CreatedAtActionResult>(actionResult);
        }

        [Fact]
        public async Task AddProduct_ReturnsCorrect()
        {
            ///
            var fridgeProductsMock = new Mock<DbSet<FridgeProduct>>();
            var product = new Product { Name = "Product", DefaultQuantity = 1 };

            fridgeProductsMock.Setup(_ => _.AddAsync(It.IsAny<FridgeProduct>(), It.IsAny<CancellationToken>()))
                .Callback((FridgeProduct model, CancellationToken cancellationToken) => { })
                .Returns((FridgeProduct model, CancellationToken cancellationToken) => ValueTask.FromResult((EntityEntry<FridgeProduct>)null));
            var mockContext = new Mock<ServerDbContext>();
            mockContext.Setup(x => x.FridgeProducts).Returns(fridgeProductsMock.Object);
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));

            var service = new FridgeService(mockContext.Object);

            ///
            var actionResult = await service.AddProduct(product, Guid.NewGuid());

            ///
            var result = actionResult as CreatedAtActionResult;
            var createdFridgeProduct = result.Value as FridgeProduct;
            Assert.Equal(product.ID, createdFridgeProduct.ProductID);
        }

        [Fact]
        public async Task AddFridge_ReturnsCreatedAtAction()
        {
            ///
            var fridgesMock = new Mock<DbSet<Fridge>>();
            var fridge = new Fridge { Name = "Fridge"};

            fridgesMock.Setup(_ => _.AddAsync(It.IsAny<Fridge>(), It.IsAny<CancellationToken>()))
                .Callback((Fridge model, CancellationToken cancellationToken) => {  })
                .Returns((Fridge model, CancellationToken cancellationToken) => ValueTask.FromResult((EntityEntry<Fridge>)null));
            var mockContext = new Mock<ServerDbContext>();
            mockContext.Setup(x => x.Fridges).Returns(fridgesMock.Object);
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));

            var service = new FridgeService(mockContext.Object);

            ///
            var actionResult = await service.AddFridge(fridge);

            ///
            Assert.IsType<CreatedAtActionResult>(actionResult);
        }

        [Fact]
        public async Task AddFridge_ReturnsCorrect()
        {
            ///
            var fridgesMock = new Mock<DbSet<Fridge>>();
            var fridge = new Fridge { Name = "Fridge" };

            fridgesMock.Setup(_ => _.AddAsync(It.IsAny<Fridge>(), It.IsAny<CancellationToken>()))
                .Callback((Fridge model, CancellationToken cancellationToken) => { })
                .Returns((Fridge model, CancellationToken cancellationToken) => ValueTask.FromResult((EntityEntry<Fridge>)null));
            var mockContext = new Mock<ServerDbContext>();
            mockContext.Setup(x => x.Fridges).Returns(fridgesMock.Object);
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));

            var service = new FridgeService(mockContext.Object);

            ///
            var actionResult = await service.AddFridge(fridge);

            ///
            var result = actionResult as CreatedAtActionResult;
            var createdFridge = result.Value as Fridge;
            Assert.Equal(fridge, createdFridge);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNoContent()
        {
            ///
            var fridgeProductsMock = new Mock<DbSet<FridgeProduct>>();
            var fridgeProduct = new FridgeProduct();

            fridgeProductsMock.Setup(x => x.FindAsync(It.IsAny<Guid>()))
                .ReturnsAsync(fridgeProduct);
            fridgeProductsMock.Setup(x => x.Remove(It.IsAny<FridgeProduct>())).Returns((EntityEntry<FridgeProduct>)null);
            var mockContext = new Mock<ServerDbContext>();
            mockContext.Setup(x => x.FridgeProducts).Returns(fridgeProductsMock.Object);
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));

            var service = new FridgeService(mockContext.Object);

            ///
            var actionResult = await service.DeleteProduct(fridgeProduct.ID);

            ///
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNotFound()
        {
            ///
            var fridgeProductsMock = new Mock<DbSet<FridgeProduct>>();
            var fridgeProduct = new FridgeProduct();

            fridgeProductsMock.Setup(x => x.FindAsync(It.IsAny<Guid>()))
                .ReturnsAsync((FridgeProduct)null);
            fridgeProductsMock.Setup(x => x.Remove(It.IsAny<FridgeProduct>())).Returns((EntityEntry<FridgeProduct>)null);
            var mockContext = new Mock<ServerDbContext>();
            mockContext.Setup(x => x.FridgeProducts).Returns(fridgeProductsMock.Object);
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));

            var service = new FridgeService(mockContext.Object);

            ///
            var actionResult = await service.DeleteProduct(fridgeProduct.ID);

            ///
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task DeleteFridge_ReturnsNoContent()
        {
            ///
            var fridgesMock = new Mock<DbSet<Fridge>>();
            var fridge = new Fridge();

            fridgesMock.Setup(x => x.FindAsync(It.IsAny<Guid>()))
                .ReturnsAsync(fridge);
            fridgesMock.Setup(x => x.Remove(It.IsAny<Fridge>())).Returns((EntityEntry<Fridge>)null);
            var mockContext = new Mock<ServerDbContext>();
            mockContext.Setup(x => x.Fridges).Returns(fridgesMock.Object);
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));

            var service = new FridgeService(mockContext.Object);

            ///
            var actionResult = await service.DeleteFridge(fridge.ID);

            ///
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task DeleteFridge_ReturnsNotFound()
        {
            ///
            var fridgesMock = new Mock<DbSet<Fridge>>();
            var fridge = new Fridge();

            fridgesMock.Setup(x => x.FindAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Fridge)null);
            fridgesMock.Setup(x => x.Remove(It.IsAny<Fridge>())).Returns((EntityEntry<Fridge>)null);
            var mockContext = new Mock<ServerDbContext>();
            mockContext.Setup(x => x.Fridges).Returns(fridgesMock.Object);
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));

            var service = new FridgeService(mockContext.Object);

            ///
            var actionResult = await service.DeleteFridge(fridge.ID);

            ///
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task Update_ReturnsNoContent()
        {
            var fridge = new Fridge();
            var mockContext = new Mock<ServerDbContext>();
            mockContext.Setup(x => x.SetModified(It.IsAny<object>()));
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));
            var service = new FridgeService(mockContext.Object);

            var actionResult = await service.Update(fridge);

            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task AddFridgeProducts_ReturnsOK()
        {
            var fridgeProductsMock = new Mock<DbSet<FridgeProduct>>();
            var fpList = new List<FridgeProduct>()
            {
                new FridgeProduct(),
                new FridgeProduct()
            }.AsQueryable();
            var mockContext = new Mock<ServerDbContext>();
            fridgeProductsMock.Setup(_ => _.AddAsync(It.IsAny<FridgeProduct>(), It.IsAny<CancellationToken>()))
                .Callback((FridgeProduct model, CancellationToken cancellationToken) => { })
                .Returns((FridgeProduct model, CancellationToken cancellationToken) => ValueTask.FromResult((EntityEntry<FridgeProduct>)null));
            fridgeProductsMock.As<IQueryable<FridgeProduct>>().Setup(m => m.Provider).Returns(fpList.Provider);
            fridgeProductsMock.As<IQueryable<FridgeProduct>>().Setup(m => m.Expression).Returns(fpList.Expression);
            fridgeProductsMock.As<IQueryable<FridgeProduct>>().Setup(m => m.ElementType).Returns(fpList.ElementType);
            fridgeProductsMock.As<IQueryable<FridgeProduct>>().Setup(m => m.GetEnumerator()).Returns(fpList.GetEnumerator());
            mockContext.Setup(x => x.FridgeProducts).Returns(fridgeProductsMock.Object);
            mockContext.Setup(x => x.SetModified(It.IsAny<object>()));
            mockContext.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(1));
            var service = new FridgeService(mockContext.Object);

            var actionResult = await service.AddFridgeProducts(fpList.ToList());

            Assert.IsType<OkObjectResult>(actionResult);
        }
    }
}
