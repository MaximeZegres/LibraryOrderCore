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
    [Route("api/Orders/{orderNumber}/orderItems")]
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
        public async Task<ActionResult<OrderItem[]>> Get(string orderNumber)
        {
            try
            {
                var orderItems = await _repository.GetOrderItemsByOrderNumberAsync(orderNumber);
                return _mapper.Map<OrderItem[]>(orderItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get OrderItems");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderItem>> Get(string orderNumber, int id)
        {
            try
            {
                var orderItem = await _repository.GetOrderItemByOrderNumberAsync(orderNumber ,id);
                return _mapper.Map<OrderItem>(orderItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get OrderItem");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemModel>> Post(string orderNumber, OrderItemModel model)
        {
            try
            {
                var order = await _repository.GetOrderAsync(orderNumber);
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
                    var url = _linkGenerator.GetPathByAction(HttpContext, "Get", values: new { orderNumber, id = orderItem.OrderItemId });

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
        public async Task<ActionResult<OrderItemModel>> Patch(string orderNumber, int id, OrderItemModel model)
        {
            try
            {
                var orderItem = await _repository.GetOrderItemByOrderNumberAsync(orderNumber, id);
                if (orderItem == null)
                {
                    return NotFound("Could not find the orderItem");
                }

                _mapper.Map(model, orderItem);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<OrderItemModel>(orderItem);
                }
                else
                {
                    return BadRequest("Failed to update database");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get OrderItem");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(string orderNumber, int id)
        {
            try
            {
                var orderItem = await _repository.GetOrderItemByOrderNumberAsync(orderNumber, id);
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