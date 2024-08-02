using Core.Database.MongoDB.Interfaces;

namespace SkeletonAPI.Models
{
    public class User : IMongoDocument
    {
        public string _id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
