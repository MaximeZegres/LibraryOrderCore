using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryOrderCore.Data;
using LibraryOrderCore.Data.Entities;
using LibraryOrderCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LibraryOrderCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILibraryOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public OrdersController(ILibraryOrderRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        // Get all orders
        [HttpGet]
        public async Task<ActionResult<OrderModel[]>> Get(bool includeItems = false)
        {
            try
            {
                var results = await _repository.GetAllOrdersAsync(includeItems);

                return _mapper.Map<OrderModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // Get by id
        [HttpGet("{orderNumber}")]
        public async Task<ActionResult<OrderModel>> Get(string orderNumber, bool includeItems = false)
        {
            try
            {
                var result = await _repository.GetOrderAsync(orderNumber, includeItems);

                if (result == null)
                {
                    return NotFound();
                }

                return _mapper.Map<OrderModel>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

       // Post
        public async Task<ActionResult<OrderModel>> Post(OrderModel model)
        {
            try
            {
                var existingOrder = await _repository.GetOrderAsync(model.OrderNumber);
                if (existingOrder != null)
                {
                    return BadRequest("Order in Use");
                }

                var location = _linkGenerator.GetPathByAction("Get", "Orders", new { orderNumber = model.OrderNumber });

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current orderNumber");
                }

                // create new order
                var order = _mapper.Map<Order>(model);
                _repository.Add(order);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/orders/{order.OrderNumber}", _mapper.Map<OrderModel>(order));
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        // Put
        [HttpPut("{orderNumber}")]
        public async Task<ActionResult<OrderModel>> Put(string orderNumber, OrderModel model)
        {
            try
            {
                var oldOrder = await _repository.GetOrderAsync(orderNumber);
                if (oldOrder == null)
                {
                    return NotFound("Could not find order with orderNumber of {orderNumber}");
                }

                _mapper.Map(model, oldOrder);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<OrderModel>(oldOrder);
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }


        [HttpDelete("{orderNumber}")]
        public async Task<IActionResult> Delete(string orderNumber)
        {
            try
            {
                var oldOrder = await _repository.GetOrderAsync(orderNumber);
                if (oldOrder == null)
                {
                    return NotFound();
                }

                _repository.Delete(oldOrder);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete order");
        }

    }
}