using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstapi.Dtos.Stock
{
    public class UpdateStocRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol can not be over 10 charecters ")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Company Name can not be over 10 charecters ")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Industry Name can not be over 10 charecters ")]
        public string Indunstry { get; set; } = string.Empty;
        [Required]
        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}