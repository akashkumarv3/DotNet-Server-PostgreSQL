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

        public static Stock ToStockFromCreateDto(this CreateStockRequest createStockDto)
        {
               return new Stock{
               Symbol=createStockDto.Symbol,
             CompanyName=createStockDto.CompanyName,
             Purchase=createStockDto.Purchase,
             LastDiv=createStockDto.LastDiv,
             Indunstry=createStockDto.Indunstry,
             MarketCap=createStockDto.MarketCap
               };
        }
    }
}