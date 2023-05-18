using Entities;

namespace Repositories
{
    public interface IRatingReposiory
    {
        Task<Rating> AddRating(Rating newRating);
    }
}