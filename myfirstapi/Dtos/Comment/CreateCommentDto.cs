using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstapi.Dtos.Comment
{
    public class CreateCommentDto
    {

        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 charecters")]
        [MaxLength(280, ErrorMessage = "Title can not be over 280 charecters ")]
        public string Title { get; set; } = string.Empty;


        [Required]
        [MinLength(5, ErrorMessage = "Content must be 5 charecters")]
        [MaxLength(280, ErrorMessage = "Content can not be over 280 charecters ")]
        public string Content { get; set; } = string.Empty;
    }
}