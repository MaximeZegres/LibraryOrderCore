using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryOrderCore.Data;
using LibraryOrderCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}