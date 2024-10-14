using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backendTest.src.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.src.Abstraction;
using test.src.DTO;
using test.src.MVC.Model;

namespace test.src.MVC.Services
{

    public class ReviewServices : IReviewServices
    {
        private readonly DatabaseContext _appDbContext;
        private readonly IMapper _mapper;

        public ReviewServices(DatabaseContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        // Get all reviews
        public async Task<List<ReviewPrintDto>?> GetReviewsServicesAsync()
        {
            var reviews = await _appDbContext.Reviews.ToListAsync();
            if (reviews == null)
            {
                return null;
            }
            var result = _mapper.Map<List<ReviewPrintDto>>(reviews);
            return result;
        }

        //Post a review
        public async Task<Review?> PostReviewServicesAsync(ReviewCreateDto review)
        {
            var newReview = _mapper.Map<Review>(review);
            await _appDbContext.Reviews.AddAsync(newReview);
            await _appDbContext.SaveChangesAsync();
            return newReview;
        }

        //Git review by id
        public async Task<ReviewPrintDto?> GetReviewByIdServicesAsync(Guid reviewId)
        {
            var review = await _appDbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);
            if (review == null)
            {
                return null;
            }
            var result = _mapper.Map<ReviewPrintDto>(review);
            return result;
        }

        //Delete the review by id
        public async Task<bool> DeleteReviewServicesAsync(Guid reviewId)
        {
            var reviewToDelete = await _appDbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);
            if (reviewToDelete != null)
            {
                _appDbContext.Reviews.Remove(reviewToDelete);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        //Update the review by id
        public async Task<ReviewPrintDto?> UpdateReviewServicesAsync(Guid reviewId, ReviewUpdateDto review)
        {
            var reviewToUpdate = await _appDbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);
            if (reviewToUpdate != null)
            {
                var updatedReview = _mapper.Map<ReviewUpdateDto, Review>(review, reviewToUpdate);
                await _appDbContext.SaveChangesAsync();
                var result = _mapper.Map<ReviewPrintDto>(updatedReview);
                return result;
            }
            return null;
        }

    }
}
