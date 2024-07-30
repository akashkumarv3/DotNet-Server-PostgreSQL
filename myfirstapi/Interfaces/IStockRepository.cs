using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfirstapi.Dtos.Stock;
using myfirstapi.Helpers;
using myfirstapi.Models;

namespace myfirstapi.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);

        Task<Stock?> getByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id,UpdateStocRequestDto updateStocDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int? stockId);
    }
}