using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfirstapi.Models;

namespace myfirstapi.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
    }
}