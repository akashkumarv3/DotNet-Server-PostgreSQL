using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using myfirstapi.Data;
using myfirstapi.Dtos.Stock;
using myfirstapi.Interfaces;
using myfirstapi.Mappers;
using myfirstapi.Models;

namespace myfirstapi.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContex _context;

        public StockRepository(ApplicationDBContex contex)
        {
            _context = contex;
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
           var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
                  if(stockModel==null){
                      return null;
                  }
               

              //now delete the stockModel from db
               _context.Remove(stockModel);
              await _context.SaveChangesAsync();
                return stockModel;
        }

        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> getByIdAsync(int id)
        {
            var stock=await _context.Stocks.FindAsync(id);

          if(stock==null){
            return null;
          }
          return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStocRequestDto updateStocDto)
        {
            var stockModel =await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
                  if(stockModel==null){
                      return null;
                  }
               stockModel.Symbol=updateStocDto.Symbol;
               stockModel.CompanyName=updateStocDto.CompanyName;
               stockModel.Purchase=updateStocDto.Purchase;
               stockModel.Indunstry=updateStocDto.Indunstry;
               stockModel.LastDiv=updateStocDto.LastDiv;
               stockModel.MarketCap=updateStocDto.MarketCap;

              //now save the stockModel chnages to db
             await _context.SaveChangesAsync();

             return stockModel;
        }
    }
}