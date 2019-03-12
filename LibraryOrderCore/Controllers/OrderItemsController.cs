using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryOrderCore.Data;
using LibraryOrderCore.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOrderCore.Controllers
{
    [ApiController]
    [Route("api/orders/{id}/orderItems")]
    public class OrderItemsController : ControllerBase
    {
        private readonly ILibraryOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemsController(ILibraryOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<OrderItem[]>> Get()
        {

        }
    }
}