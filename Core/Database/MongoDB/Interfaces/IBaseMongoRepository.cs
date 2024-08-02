using MongoDB.Driver;
using System.Linq.Expressions;

namespace Core.Database.MongoDB.Interfaces;

public interface IBaseMongoRepository<TDocument>
{
    Task InsertAsync(TDocument entity, CancellationToken cancellationToken);
    Task<TDocument> GetAsync(string id, CancellationToken cancellationToken);
    Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken);
    Task<TDocument> UpdateAsync(TDocument entity, CancellationToken cancellationToken);
    Task<TDocument> UpdateAsync(TDocument entity, FilterDefinition<TDocument> documentIdentifierFilterDefinition, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(FilterDefinition<TDocument> filterDefinition, CancellationToken cancellationToken);
}
