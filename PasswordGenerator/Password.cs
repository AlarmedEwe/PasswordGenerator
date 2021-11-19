using System.Text;
namespace PasswordGenerator;

public class Password
{
  public static void Generate(string[] asks)
  {
    // What's the size for your password?
    Console.WriteLine(asks[0]);
    int passwordLength = Convert.ToInt32(Console.ReadLine());

    // Do you wish a weak, medium or strength password?
    Console.WriteLine(asks[1]);
    string? passwordStrength = Console.ReadLine();

    // Your new password is:
    Console.Write(asks[2]);
    string newPassword = Generate(passwordLength, passwordStrength);
    Console.WriteLine(newPassword);
  }

  private static string Generate(int length, string? strength)
  {
    char[] upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZÇÁÂÃÉÊÍÓÔÕÚ".ToArray();
    char[] lowerChars = "abcdefghijklmnopqrstuvwxyzçáâãéêíóôõú".ToArray();
    char[] numbers = "0123456789".ToArray();
    char[] specialChars = ",.;:!?'/\\|[]{}()<>_-+*=@#$%&".ToArray();

    char[] chars = strength?.ToLowerInvariant() switch
    {
      "weak" => upperChars.Concat(lowerChars).ToArray(),
      "medium" => upperChars.Concat(lowerChars).Concat(numbers).ToArray(),
      "strength" => upperChars.Concat(lowerChars).Concat(numbers).Concat(specialChars).ToArray(),
      _ => upperChars.Concat(lowerChars).ToArray()
    };

    StringBuilder builder = new();
    Random random = new();

    for (int i = 0; i < length; i++)
    {
      builder.Append(chars[random.Next(0, chars.Length)]);
    }

    return $"{builder}";
  }
}