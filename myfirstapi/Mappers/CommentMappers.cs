using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfirstapi.Dtos.Comment;
using myfirstapi.Models;

namespace myfirstapi.Mappers
{
    public static class CommentMappers
    {
         public static CommentDto ToCommentDto( this Comment commnetModel)
        {
          return new CommentDto
          {
             Id=commnetModel.Id,
             Content=commnetModel.Content,
             CreatedOn=commnetModel.CreatedOn,
             Title=commnetModel.Title,
             StockId=commnetModel.StockId
          };
        }

    }
}