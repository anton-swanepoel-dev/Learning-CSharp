int x = 0;

string message = "The quick brown fox jumps over the lazy dog.";

char[] charMessage = message.ToCharArray();

Array.Reverse(charMessage);

foreach (char i in charMessage)
{
    if (i == 'o')
    {
        x++;
    }
}

string new_message = new String(charMessage);

Console.WriteLine(new_message);
Console.WriteLine($"'o' appears {x} times.");