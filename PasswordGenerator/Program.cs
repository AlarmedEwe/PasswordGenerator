string path = AppDomain.CurrentDomain.BaseDirectory + "/Languages";

Console.WriteLine("+---------------------+");
Console.WriteLine("|-- Select language --|");
Console.WriteLine("|- en                -|");
Console.WriteLine("|- pt-br             -|");
Console.WriteLine("+---------------------+");

string language = Console.ReadLine();

string json = language switch
{
  "pt-br" => File.ReadAllText($"{path}/pt-br.json"),
  "en" => File.ReadAllText($"{path}/en.json"),
  _ => File.ReadAllText($"{path}/en.json")
};

Console.Clear();