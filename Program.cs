using PasswordGenerator.Controllers;

TranslationController translator = new();

PasswordController password = new(translator.Get());
password.Generate();

Console.WriteLine("\nPressione [ENTER] para sair...");
Console.ReadLine();