using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myfirstapi.Data;
using myfirstapi.Dtos.Stock;
using myfirstapi.Mappers;
using myfirstapi.Models;

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

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateStocRequestDto updateStockDto)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
                  if(stockModel==null){
                      return NotFound();
                  }
               stockModel.Symbol=updateStockDto.Symbol;
               stockModel.CompanyName=updateStockDto.CompanyName;
               stockModel.Purchase=updateStockDto.Purchase;
               stockModel.Indunstry=updateStockDto.Indunstry;
               stockModel.LastDiv=updateStockDto.LastDiv;
               stockModel.MarketCap=updateStockDto.MarketCap;

              //now save the stockModel chnages to db
              _context.SaveChanges();

              return  Ok(stockModel.ToStockDto());    
        }

        //delete the specific Stock details from db
         [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
                  if(stockModel==null){
                      return NotFound();
                  }
               

              //now delete the stockModel from db
              _context.Remove(stockModel);
              _context.SaveChanges();

              return Ok(new { Message = "Item successfully deleted." });
        }
    }
}