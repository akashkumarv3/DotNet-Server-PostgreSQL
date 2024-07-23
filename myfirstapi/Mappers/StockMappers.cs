using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfirstapi.Dtos.Stock;
using myfirstapi.Models;
using Npgsql.Replication;

namespace myfirstapi.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto( this Stock stockModel)
        {
          return new StockDto
          {
             Id=stockModel.Id,
             Symbol=stockModel.Symbol,
             CompanyName=stockModel.CompanyName,
             Purchase=stockModel.Purchase,
             LastDiv=stockModel.LastDiv,
             Indunstry=stockModel.Indunstry,
             MarketCap=stockModel.MarketCap

          };
        }
    }
}