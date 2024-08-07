using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfirstapi.Data;
using myfirstapi.Dtos.Stock;
using myfirstapi.Helpers;
using myfirstapi.Interfaces;
using myfirstapi.Mappers;
using myfirstapi.Models;
using myfirstapi.Repository;

namespace myfirstapi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {


        private readonly ApplicationDBContex _context;
        private readonly IStockRepository _stockrepo;
        public StockController(ApplicationDBContex contex, IStockRepository stockRepo)
        {
            _context = contex;
            _stockrepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> getAll([FromQuery] QueryObject query)
        {
            var stocks = await _stockrepo.GetAllAsync(query);

            var stockList = stocks.Select(s => s.ToStockDto());

            return Ok(stockList);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getById([FromRoute] int id)
        {
            var stock = await _stockrepo.getByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateStockRequest createStockDto)
        {
            //here we adding validation in contriller API for globalyy 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = createStockDto.ToStockFromCreateDto();
            await _stockrepo.CreateAsync(stockModel);

            return CreatedAtAction(nameof(getById), new { stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStocRequestDto updateStockDto)
        {

            //here we adding validation in contriller API for globalyy 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var stockModel = await _stockrepo.UpdateAsync(id, updateStockDto);
            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        //delete the specific Stock details from db
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockrepo.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(new { Message = "Stocks successfully deleted." });
        }
    }
}