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
    }
}