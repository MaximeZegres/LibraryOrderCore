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

        public OrdersController(ILibraryOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> Get(int id)
        {
            try
            {
                var result = await _repository.GetOrderAsync(id);

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
                var existingOrder = await _repository.GetOrderAsync(model.Id);
                if (existingOrder != null)
                {
                    return BadRequest("Order in Use");
                }

                // create new order
                var order = _mapper.Map<Order>(model);
                _repository.Add(order);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/orders/{order.Id}", _mapper.Map<OrderModel>(order));
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        // Put
        [HttpPatch("{id}")]
        public async Task<ActionResult<OrderModel>> Patch(int id, OrderModel model)
        {
            try
            {
                var oldOrder = await _repository.GetOrderAsync(model.Id);
                if (oldOrder == null)
                {
                    return NotFound("Could not find order with id of {id}");
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


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var oldOrder = await _repository.GetOrderAsync(id);
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