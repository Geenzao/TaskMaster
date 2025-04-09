using System.Collections.Generic;
using System.Threading.Tasks;

public class ProjetViewModel
{
    private readonly ProjetService _projetService;

    public ProjetViewModel(ProjetService projetService)
    {
        _projetService = projetService;
    }

    public List<Projet>? Projets { get; private set; }

    public async Task LoadProjetsAsync()
    {
        Projets = await _projetService.GetAllProjetsAsync();
    }
}