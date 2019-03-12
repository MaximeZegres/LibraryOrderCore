using AutoMapper;
using LibraryOrderCore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Controllers
{
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly ILibraryOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemsController(ILibraryOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
