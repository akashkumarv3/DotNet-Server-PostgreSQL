using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult > getAll()
        {
            var stocks=await _context.Stocks.ToListAsync();

            var stockList=stocks.Select( s => s.ToStockDto());

             return Ok(stockList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById( [FromRoute] int id)
        {
          var stock=await _context.Stocks.FindAsync(id);

          if(stock==null){
            return NotFound();
          }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateStockRequest createStockDto)
        {
                    var stockModel=createStockDto.ToStockFromCreateDto();
                    
                   await _context.Stocks.AddAsync(stockModel);
                  await _context.SaveChangesAsync();
                   return CreatedAtAction(nameof(getById),new{stockModel.Id},stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateStocRequestDto updateStockDto)
        {
            var stockModel =await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
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
             await _context.SaveChangesAsync();

              return  Ok(stockModel.ToStockDto());    
        }

        //delete the specific Stock details from db
         [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
                  if(stockModel==null){
                      return NotFound();
                  }
               

              //now delete the stockModel from db
               _context.Remove(stockModel);
              await _context.SaveChangesAsync();

              return Ok(new { Message = "Item successfully deleted." });
        }
    }
}