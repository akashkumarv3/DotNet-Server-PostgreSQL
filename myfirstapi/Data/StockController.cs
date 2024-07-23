using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace myfirstapi.Data
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
            var stocks=_context.Stocks.ToList();

             return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult getById( [FromRoute] int id)
        {
          var stock=_context.Stocks.Find(id);

          if(stock==null){
            return NotFound();
          }

          return Ok(stock);
        }
    }
}