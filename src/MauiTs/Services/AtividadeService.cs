using MauiTs.Repository.Entities;
using MauiTs.Repository.Repos;

namespace MauiTs.Services;

public interface IAtividadeService
{
    Task<bool> Add(Atividade entity);
    Task<bool> Update(Atividade entity);
    Task<bool> Delete(long id);
    Task<IEnumerable<Atividade>> GetAll();
    Task<Atividade> Get(long id);
}
public class AtividadeService(AtividadeRepository repo) : IAtividadeService
{
    public async Task<bool> Add(Atividade entity)
    {
        await repo.Add(entity);
        return true;
    }

    public async Task<bool> Delete(long id)
    {
        await repo.Delete(id);
        return true;
    }

    public async Task<Atividade> Get(long id)
    {
        return await repo.Get(id);
    }

    public async Task<IEnumerable<Atividade>> GetAll()
    {
        return await repo.GetAll();
    }

    public async Task<bool> Update(Atividade entity)
    {
        await repo.Update(entity);
        return true;
    }
}
