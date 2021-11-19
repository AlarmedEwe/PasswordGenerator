using System.Text;
using PasswordGenerator.Models;

namespace PasswordGenerator.Controllers;

public class PasswordController
{
  private Ask Ask { get; set; } = new();
  private Strengthness Strength { get; set; } = new();

  public PasswordController(Translator translator)
  {
    Ask = translator.Ask;
    Strength = translator.Strength;
  }

  public void Generate()
  {
    // What's the size for your password?
    Console.WriteLine(Ask.PasswordLength);
    int passwordLength = Convert.ToInt32(Console.ReadLine());

    // Do you wish a weak, medium or strength password?
    Console.WriteLine(Ask.PasswordStrength);
    string? passwordStrength = Console.ReadLine();

    // Your new password is:
    Console.Write(Ask.Response);
    string newPassword = Generate(passwordLength, passwordStrength);
    Console.WriteLine(newPassword);
  }

  private string Generate(int length, string? strength)
  {
    strength = strength?.ToLowerInvariant();

    char[] upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZÇÁÂÃÉÊÍÓÔÕÚ".ToArray();
    char[] lowerChars = "abcdefghijklmnopqrstuvwxyzçáâãéêíóôõú".ToArray();
    char[] numbers = "0123456789".ToArray();
    char[] specialChars = ",.;:!?'/\\|[]{}()<>_-+*=@#$%&".ToArray();

    char[] chars;
    if (strength == Strength.Weak)
      chars = upperChars.Concat(lowerChars).ToArray();
    else if (strength == Strength.Medium)
      chars = upperChars.Concat(lowerChars).Concat(numbers).ToArray();
    else
      chars = upperChars.Concat(lowerChars).Concat(numbers).Concat(specialChars).ToArray();

    StringBuilder builder = new();
    Random random = new();

    for (int i = 0; i < length; i++)
    {
      builder.Append(chars[random.Next(0, chars.Length)]);
    }

    return $"{builder}";
  }
}