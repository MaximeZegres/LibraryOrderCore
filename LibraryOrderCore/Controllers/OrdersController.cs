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

        /// <summary>
        /// Get All Orders
        /// </summary>
        /// <param name="includeItems">A boolean to include the orderItems to the json result.</param>
        /// <returns>An order with the CustomerInformation (and orderItems + books) if the includeItems is specified in the URL</returns>

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


        /// <summary>
        /// Get order by orderNumber
        /// </summary>
        /// <param name="orderNumber">A string reference to get the content of the specific order with that orderNumber</param>
        /// <returns>An order with the CustomerInformation</returns>
        [HttpGet("{orderNumber}")]
        public async Task<ActionResult<OrderModel>> Get(string orderNumber)
        {
            try
            {
                var result = await _repository.GetOrderAsync(orderNumber);

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

       /// <summary>
       /// Post a complete new order containing the complete information about the order and customer without the orderItems information.
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       [HttpPost]
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

        /// <summary>
        /// Modify the order following the specific orderNumber specified in the parameter.
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete the order following the specific orderNumber specified in the parameter.
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
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