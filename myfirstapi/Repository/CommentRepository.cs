using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using myfirstapi.Data;
using myfirstapi.Interfaces;
using myfirstapi.Mappers;
using myfirstapi.Models;

namespace myfirstapi.Repository
{
    public class CommentRepository : ICommentRepository
    {

        private readonly ApplicationDBContex _context;

        public CommentRepository(ApplicationDBContex contex)
        {
            _context=contex;
        }
        public async Task<List<Comment>> GetAllSync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            var comment=await _context.Comments.FindAsync(id);

          if(comment==null){
            return null;
          }
            return comment;
        }
    }
}