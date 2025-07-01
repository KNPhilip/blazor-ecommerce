namespace Domain;

public static class Configuration
{
    public static string Get(string name)
    {
        name = name.Replace(":", "__");
        return Environment.GetEnvironmentVariable(name)
            ?? throw new ArgumentNullException($"Could not read \"{name}\" in appsettings.");
    }

    public static string GetConnectionString(string name)
    {
        return Environment.GetEnvironmentVariable($"ConnectionStrings__{name}")
            ?? throw new ArgumentNullException($"Could not read \"{name}\" in appsettings.");
    }
}
