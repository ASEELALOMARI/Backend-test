using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.src.Abstraction;
using test.src.DTO;

namespace test.src.MVC.Controller
{
    [ApiController]
    [Route("api/v1/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;
        public ReviewController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            try
            {
                var reviews = await _reviewServices.GetReviewsServicesAsync();
                if (reviews == null || !reviews.Any())  // check if the list is null or empty)
                {
                    return NotFound("no reviews yet");
                }
                return Ok(reviews);
            }
            catch (Exception ex)
            {

                return Conflict(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewCreateDto review)
        {
            try
            {
                var newReview = await _reviewServices.PostReviewServicesAsync(review);
                return Created("Review has been Add", newReview);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById([FromRoute] Guid id)
        {
            try
            {
                var review = await _reviewServices.GetReviewByIdServicesAsync(id);
                if (review == null)
                {
                    return NotFound("review not found");
                }
                return Ok(review);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview([FromRoute] Guid id)
        {
            try
            {
                var review = await _reviewServices.DeleteReviewServicesAsync(id);
                if (review == false)
                {
                    return NotFound("review not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview([FromRoute] Guid id, [FromBody] ReviewUpdateDto review)
        {
            try
            {
                var updatedReview = await _reviewServices.UpdateReviewServicesAsync(id, review);
                if (updatedReview == null)
                {
                    return NotFound("review not found");
                }
                return Ok(updatedReview);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

    }
}