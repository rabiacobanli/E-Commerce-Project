using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly ICustomerReadRepository _customerReadRepository;


        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository, ICustomerReadRepository customerReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
            _customerReadRepository = customerReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            Order order= await _orderReadRepository.GetByIdAsync("5b2e5a59-afc0-49c8-802f-b706712abe9a");
            order.Address = "New York";
            await _orderWriteRepository.SaveAsync();
            #region Order&Customer Added
            //var customerId=Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Rabia" });
            //await _orderWriteRepository.AddAsync(new() { Description="bla bla bla",Address="İstanbul",CustomerId=customerId });
            //await _orderWriteRepository.AddAsync(new() { Description="bla bla bla 2",Address="İzmir",CustomerId=customerId });
            //await _orderWriteRepository.SaveAsync();
            #endregion
            #region Product Added
            await _productWriteRepository.AddAsync(new() { Name = "C Product", Price = 1.500F, Stock = 10, CreatedDate = DateTime.UtcNow });
            await _productWriteRepository.SaveAsync();
            #endregion
            #region FirstCode
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new(){Id=Guid.NewGuid(),Name="Product 1",Price=100,CreatedDate=DateTime.UtcNow,Stock=10},
            //    new(){Id=Guid.NewGuid(),Name="Product 2",Price=200,CreatedDate=DateTime.UtcNow,Stock=20},
            //    new(){Id=Guid.NewGuid(),Name="Product 3",Price=300,CreatedDate=DateTime.UtcNow,Stock=130},
            //});
            //await _productWriteRepository.SaveAsync();
            Product p = await _productReadRepository.GetByIdAsync("24505fb9-eb01-43cd-a462-885b1bd65c99",false);
            p.Name = "Mehmet";
            await _productWriteRepository.SaveAsync();
            #endregion
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product= await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}

    }
}
