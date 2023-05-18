using Entities;

namespace Repositories
{
    public class RatingReposiory : IRatingReposiory
    {
        ShopDbContext _shopDbContext;

        public RatingReposiory(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<Rating> AddRating(Rating newRating)
        {


            await _shopDbContext.Rating.AddAsync(newRating);
            await _shopDbContext.SaveChangesAsync();
            return newRating;
        }
    }
} 
