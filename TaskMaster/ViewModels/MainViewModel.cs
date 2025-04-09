public class MainViewModel
{
    private readonly DatabaseService _databaseService;

    public MainViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task InitializeAsync()
    {
        await _databaseService.OpenConnectionAsync();
        // Exécutez des requêtes ou d'autres opérations sur la base de données
    }
}