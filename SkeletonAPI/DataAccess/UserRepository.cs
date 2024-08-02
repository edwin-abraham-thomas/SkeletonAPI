using Core.Database.MongoDB;
using Microsoft.Extensions.Options;
using SkeletonAPI.Models;

namespace SkeletonAPI.DataAccess;

public class UserRepository : BaseMongoRepository<User>
{
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(IOptions<MongoConfig> mongoConfig, ILogger<UserRepository> logger) : base(mongoConfig)
    {
        _logger = logger;
    }
}
