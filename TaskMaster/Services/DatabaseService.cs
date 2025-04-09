using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DatabaseService
{
    private readonly MySqlConnection _connection;

    public DatabaseService(MySqlConnection connection)
    {
        _connection = connection;
    }

    public async Task OpenConnectionAsync()
    {
        await _connection.OpenAsync();
    }

    public async Task CloseConnectionAsync()
    {
        await _connection.CloseAsync();
    }

    public async Task ExecuteQueryAsync(string query)
    {
        using (var command = new MySqlCommand(query, _connection))
        {
            await command.ExecuteNonQueryAsync();
        }
    }
}