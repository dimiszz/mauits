using MauiTs.Repository.Entities;
using MauiTs.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiTs.Repository.Repos;

public class AtividadeRepository(TsContext ts) : IRepository<Atividade, long>
{
    public async Task<bool> Add(Atividade entity)
    {
        try
        {
            await ts.Atividades.AddAsync(entity);
            await ts.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao adicionar nova atividade: {ex.Message}", ex);
        }
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            await ts.Atividades
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            await ts.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao deletar atividade: {ex.Message}", ex);
        }
    }

    public async Task<IEnumerable<Atividade>> GetAll()
    {
        try
        {
            return await ts.Atividades.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao deletar atividade: {ex.Message}", ex);
        }
    }

    public async Task<bool> Update(Atividade entity)
    {
        try
        {
            ts.Atividades.Update(entity);
            await ts.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao atualizar atividade: {ex.Message}", ex);
        }
    }
}
