using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using myfirstapi.Dtos.Comment;
using myfirstapi.Interfaces;
using myfirstapi.Mappers;
using myfirstapi.Models;

namespace myfirstapi.Controllers
{


    [Route("api/comment")]
    [ApiController]
    public class CommentController: ControllerBase
    {


        private readonly ICommentRepository _commentRepo;
         
        private readonly IStockRepository _stockRepo;

        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo=commentRepo;
            _stockRepo=stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var comments= await _commentRepo.GetAllSync();
           var commentsList=comments.Select(s=> s.ToCommentDto());

           return Ok(commentsList);
        }

        //getById
          [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
           var comment= await _commentRepo.GetById(id);
           if(comment==null){
               return NotFound();
           }
     var formagtedDTo=comment.ToCommentDto();
           return Ok(formagtedDTo);
        }

        //create new comments for existing Stock
        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
        {
              if(! await  _stockRepo.StockExists(stockId))
              {
                return BadRequest("Stock does not exist");
              }

              var commentModel=commentDto.ToCommentFromCreate(stockId);
              await _commentRepo.CreateAsync(commentModel);

              return  CreatedAtAction(nameof(GetById),new{id=commentModel.Id},commentModel.ToCommentDto());
        }
       
         //update existing comment 
         [HttpPut]
         [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id ,[FromBody] UpdateCommentRequestDto commentRequestDto)
        {
         
            var comment=await _commentRepo.UpdateAsync(id,commentRequestDto.ToCommentFromUpdate());
            
            if(comment==null)
            {
              return NotFound("Comment does not found");
            }
           
           return Ok(comment.ToCommentDto());
        }
        //Delete existing comment 
         [HttpDelete]
         [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
         
            var comment=await _commentRepo.DeleteAsync(id);
            
            if(comment==null)
            {
              return NotFound("Comment does not Exist");
            }
           
           return Ok("Comment is deleted ");
        }

        }
    }
