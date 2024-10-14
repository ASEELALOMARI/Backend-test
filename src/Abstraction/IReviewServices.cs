using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.src.DTO;
using test.src.MVC.Model;

namespace test.src.Abstraction
{
    public interface IReviewServices
    {
        Task<List<ReviewPrintDto>?> GetReviewsServicesAsync();
        Task<Review?> PostReviewServicesAsync(ReviewCreateDto review);
        Task<ReviewPrintDto?> GetReviewByIdServicesAsync(Guid reviewId);
        Task<bool> DeleteReviewServicesAsync(Guid reviewId);
        Task<ReviewPrintDto?> UpdateReviewServicesAsync(Guid reviewId, ReviewUpdateDto review);
    }
}