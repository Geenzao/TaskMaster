using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;

public class ProjetService
{
    private readonly TaskMasterContext _context;

    public ProjetService(TaskMasterContext context)
    {
        _context = context;
    }

    public async Task<List<Projet>> GetAllProjetsAsync()
    {
        return await _context.Projets.ToListAsync();
    }
}