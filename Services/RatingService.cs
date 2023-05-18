using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;


namespace Services
{
    public class RatingService : IRatingService
    {

        IRatingReposiory _ratingReposiory;
        public RatingService(IRatingReposiory ratingReposiory)
        {
            _ratingReposiory = ratingReposiory;
        }

        public async Task<Rating> AddRating(Rating newRating)
        {
            return await _ratingReposiory.AddRating(newRating);
        }


    }
}
