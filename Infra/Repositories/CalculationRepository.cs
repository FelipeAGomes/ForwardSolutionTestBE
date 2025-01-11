using System.Text.Json;
using System.Text.Json.Serialization;
using Forward_Solutions_Test_BE.Domain.Entities;
using Forward_Solutions_Test_BE.Domain.Interfaces;

public class CalculationRepository : ICalculationRepository
{
    private readonly string _filePath = "calculations.json";

    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() } // Converte enums para strings
    };

    public async Task SaveAsync(Calculation calculation)
    {
        var calculations = new List<Calculation>();

        if (File.Exists(_filePath))
        {
            var existingData = await File.ReadAllTextAsync(_filePath);
            calculations = JsonSerializer.Deserialize<List<Calculation>>(existingData, _jsonOptions) ?? new List<Calculation>();
        }

        calculations.Add(calculation);

        var json = JsonSerializer.Serialize(calculations, _jsonOptions);
        await File.WriteAllTextAsync(_filePath, json);
    }

    public async Task<List<Calculation>> GetAllAsync()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Calculation>();
        }

        var jsonData = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Calculation>>(jsonData) ?? new List<Calculation>();
    }

}
