using static System.Runtime.InteropServices.JavaScript.JSType;

//Console.WriteLine("Enter a value between 5 and 10");
//int number = 0;

//do
//{
//    string input = Console.ReadLine();

//    if (int.TryParse(input, out number))
//    {
//        if (number < 5 || number > 10) Console.WriteLine($"You entered {number}. Please enter a value between 5 and 10"); 
//    }
//    else
//    {
//        Console.WriteLine("Sorry, you entered an invalid number, please try again");
//    }

//} while (number < 5 || number > 10);

//Console.WriteLine($"Your input value {number} has been accepted.");

Console.WriteLine("Enter your role name (Administrator, Manager, or User)");

string input = "";
bool security = false;

while (!security)
{
    input = Console.ReadLine();

    string role = (!string.IsNullOrEmpty(input)) ? input.ToLower().Trim() : "";
    //string role = input.ToLower().Trim();

    if (role == "administrator") security = true;

    if (role == "manager") security = true;

    if (role == "user" ) security = true;

    if (!security) Console.WriteLine($"The role name that you entered, \"{input}\" is not valid. Enter your role name(Administrator, Manager, or User)");

}
Console.WriteLine($"Your input value ({input}) has been accepted.");

//string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

//int periodLocation = 0;

//foreach (var myString in myStrings)
//{
//    periodLocation = myString.IndexOf(".");
//    string text = myString;

//    while (periodLocation > 0)
//    {
//        Console.WriteLine(text.Substring(0, periodLocation).TrimStart());

//        text = text.Remove(0, periodLocation + 1);

//        periodLocation = text.IndexOf(".");
        
//    }

//    Console.WriteLine(text.TrimStart());
//}
