using PasswordGenerator.Models;
using System.Text.Json;

namespace PasswordGenerator.Controllers;

public class TranslationController
{
  private string Path { get; } = AppDomain.CurrentDomain.BaseDirectory + "/Languages";

  public Translator Get()
  {
    string language = AskForLanguage();
    Console.Clear();
    return Parse(language);
  }

  private string AskForLanguage()
  {
    Console.WriteLine("+---------------------+");
    Console.WriteLine("|-- Select language --|");
    Console.WriteLine("|- en                -|");
    Console.WriteLine("|- pt-br             -|");
    Console.WriteLine("+---------------------+");

    string? language = Console.ReadLine();

    return language ?? "";
  }

  private Translator Parse(string language)
  {
    string json = language switch
    {
      "pt-br" => File.ReadAllText($"{Path}/pt-br.json"),
      "en" => File.ReadAllText($"{Path}/en.json"),
      _ => File.ReadAllText($"{Path}/en.json")
    };

    return JsonSerializer.Deserialize<Translator>(json) ?? new();
  }
}