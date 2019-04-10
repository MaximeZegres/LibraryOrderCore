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
    [ApiController]
    [Route("api/orders/{OrderItemId}/orderItems")]
    public class OrderItemsController : ControllerBase
    {
        private readonly ILibraryOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public OrderItemsController(ILibraryOrderRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        [HttpGet]
        public async Task<ActionResult<OrderItem[]>> Get(int id)
        {
            try
            {
                var orderItems = await _repository.GetOrderItemsAsync(id);
                return _mapper.Map<OrderItem[]>(orderItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get OrderItems");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderItem>> Get(int orderItemId, int id)
        {
            try
            {
                var orderItem = await _repository.GetOrderItemByIdAsync(orderItemId ,id);
                return _mapper.Map<OrderItem>(orderItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get OrderItem");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemModel>> Post(int id, OrderItemModel model)
        {
            try
            {
                var order = await _repository.GetOrderAsync(id);
                if (order == null)
                {
                    return BadRequest("Order does not exist");
                }

                var orderItem = _mapper.Map<OrderItem>(model);
                orderItem.Order = order;

                if(model.Book == null)
                {
                    return BadRequest("Book ID is required");
                }

                var book = await _repository.GetBookAsync(model.Book.BookId);
                if (book == null)
                {
                    return BadRequest("Book could not be found");
                }
                orderItem.Book = book;

                _repository.Add(orderItem);

                if(await _repository.SaveChangesAsync())
                {
                    var url = _linkGenerator.GetPathByAction(HttpContext, "Get", values: new { orderItem, id = order.Id });

                    return Created(url, _mapper.Map<OrderItemModel>(orderItem));
                }
                else
                {
                    return BadRequest("Failed to save new orderItem");
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to post OrderItem");
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<OrderItemModel>> Patch(int id, int orderItemId, OrderItemModel model)
        {
            try
            {
                var orderItem = await _repository.GetOrderItemByIdAsync(id, orderItemId);
                if (orderItem == null)
                {
                    return NotFound("Could not find the orderItem");
                }

                _mapper.Map(model, orderItem);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<OrderItemModel>(orderItem);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get OrderItem");
            }

            return BadRequest("Could not find the orderItem");
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, int orderItemId)
        {
            try
            {
                var orderItem = await _repository.GetOrderItemByIdAsync(id, orderItemId);
                if (orderItem == null)
                {
                    return NotFound("Failed to find the orderItem to delete");
                }

                _repository.Delete(orderItem);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed to delete orderItem");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get OrderItem");
            }
        }
    }
}