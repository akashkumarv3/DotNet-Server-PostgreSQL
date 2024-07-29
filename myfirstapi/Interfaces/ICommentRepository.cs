using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfirstapi.Models;

namespace myfirstapi.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> CreateAsync(Comment comment);
        Task<Comment?> DeleteAsync(int id);
        Task<List<Comment>> GetAllSync();
        Task<Comment?> GetById(int id);
        Task <Comment?> UpdateAsync(int id, Comment comment);
    }
}