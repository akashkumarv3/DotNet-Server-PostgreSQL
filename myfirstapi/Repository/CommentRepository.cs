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

        public async Task<Comment> CreateAsync( Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
           var commentModel= await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

           if(commentModel==null)
           {
             return null;
           }

           _context.Comments.Remove(commentModel);
           await _context.SaveChangesAsync();
           return commentModel;
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

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment= await _context.Comments.FindAsync(id);

            if(existingComment==null)
            {
              return null;
            }

            existingComment.Content=commentModel.Content;
            existingComment.Title=commentModel.Title;

            await _context.SaveChangesAsync();

            return existingComment;
        }
    }
}