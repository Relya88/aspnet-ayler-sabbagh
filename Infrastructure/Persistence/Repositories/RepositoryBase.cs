using Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Persistence.Repositories;
//basklass för repos med gemensamma crud logik (med hjälp av Hans videomaterial)
public abstract class RepositoryBase<TDomainModel, TId, TEntity, TDbContext>(TDbContext context) : IRepositoryBase<TDomainModel, TId>
    where TEntity : class
    where TDbContext : DbContext
{
    //databaskopplingen
    protected readonly TDbContext _context = context;

    //representerar tabellen i databas
    protected DbSet<TEntity> Set => _context.Set<TEntity>();

    //hämtar id 
    protected abstract TId GetId(TDomainModel model);
    //mapper för domanin+entity
    protected abstract TEntity ToEntity(TDomainModel model);
    //mapper för entity+domain
    protected abstract TDomainModel ToDomainModel(TEntity entity);
    //uppdaterar enity med nya värden
    protected abstract void ApplyPropertyUpdates(TEntity entity, TDomainModel model);


    //metoder som lägger till email, uppdaterar befinltig post, tar bort post, hämtar post baserat på id och hämtar alla poster
    public virtual async Task AddAsync(TDomainModel model, CancellationToken ct = default)
    {
        try
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var entity = ToEntity(model);
            await Set.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
        }
        catch
        {
            throw;
        }
    }

    public virtual async Task<bool> UpdateAsync(TDomainModel model, CancellationToken ct = default)
    {
        try
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var id = GetId(model);

            var entity = await Set.FindAsync([id], ct);
            if (entity is null)
                return false;

            ApplyPropertyUpdates(entity, model);
            await _context.SaveChangesAsync(ct);

            return true;
        }
        catch
        {
            throw;
        }
    }

    public virtual async Task<bool> RemoveAsync(TDomainModel model, CancellationToken ct = default)
    {
        try
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var id = GetId(model);

            var entity = await Set.FindAsync([id], ct);
            if (entity is null)
                return false;

            Set.Remove(entity);
            await _context.SaveChangesAsync(ct);

            return true;
        }
        catch
        {
            throw;
        }
    }

    public virtual async Task<TDomainModel?> GetByIdAsync(TId id, CancellationToken ct = default)
    {
        try
        {
            var entity = await Set.FindAsync([id], ct);
            return entity is null ? default : ToDomainModel(entity);
        }
        catch
        {
            throw;
        }
    }

    public virtual async Task<IReadOnlyList<TDomainModel>> GetAllAsync(CancellationToken ct = default)
    {
        try
        {
            var entities = await Set.AsNoTracking().ToListAsync(ct);
            return [.. entities.Select(ToDomainModel)];
        }
        catch
        {
            throw;
        }
    }
}