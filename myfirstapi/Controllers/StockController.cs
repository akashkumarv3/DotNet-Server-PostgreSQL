using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myfirstapi.Data;
using myfirstapi.Dtos.Stock;
using myfirstapi.Mappers;

namespace myfirstapi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController :ControllerBase
    {


         private readonly ApplicationDBContex  _context;
        public StockController(ApplicationDBContex contex)
        {
            _context=contex;
        }

       [HttpGet]
        public IActionResult getAll()
        {
            var stocks=_context.Stocks.ToList()
            .Select( s => s.ToStockDto());

             return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult getById( [FromRoute] int id)
        {
          var stock=_context.Stocks.Find(id);

          if(stock==null){
            return NotFound();
          }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequest createStockDto)
        {
                    var stockModel=createStockDto.ToStockFromCreateDto();
                    
                   _context.Stocks.Add(stockModel);
                   _context.SaveChanges();
                   return CreatedAtAction(nameof(getById),new{stockModel.Id},stockModel.ToStockDto());
        }
    }
}