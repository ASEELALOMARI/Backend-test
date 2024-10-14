using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.src.DTO
{
    public class ReviewPrintDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}