using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfirstapi.Data;
using myfirstapi.Interfaces;
using myfirstapi.Models;

namespace myfirstapi.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContex _context;

        public StockRepository(ApplicationDBContex contex)
        {
            _context=contex;
        }
        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }
    }
}