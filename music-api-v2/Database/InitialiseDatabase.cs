namespace  music_api_v2.Database;

using Npgsql;

public abstract class InitialiseDatabase
{
    private static Dictionary<string, string?> GetEnvVariables()
    {
        var root = Directory.GetCurrentDirectory();
        var dotenvPath = Path.Combine(root, "Utils/.env");
        Console.WriteLine(dotenvPath);
        DotNetEnv.Env.Load(dotenvPath);

        var envVars = new Dictionary<string, string?>
        {
            ["HOST"] = Environment.GetEnvironmentVariable("HOST"),
            ["DATABASE"] = Environment.GetEnvironmentVariable("DATABASE"),
            ["USERNAME"] = Environment.GetEnvironmentVariable("USERNAME"),
            ["PASSWORD"] = Environment.GetEnvironmentVariable("PASSWORD") 
        };

        return envVars;
    }

    public NpgsqlConnection GetIndividualConnection()
    {
        Console.WriteLine("Setting the connection string");

        var envVars = GetEnvVariables();

        var connectionString =
            $"Host={envVars["HOST"]};database={envVars["DATABASE"]};Username={envVars["USERNAME"]};Password={envVars["PASSWORD"]};";

        return new NpgsqlConnection(connectionString);
    }
}