using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo=commentRepo;
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
    }
}