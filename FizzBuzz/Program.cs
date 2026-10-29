const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

// Your work here
int firstOccurance = 0;
int lastOccurence = 0;
int lenght = 0;
const string spanStart = "<span>";
const string spanEnd = "</span>";
const string divStart = "<div>";
const string divEnd = "</div>";

firstOccurance = input.IndexOf(spanStart);
lastOccurence = input.IndexOf(spanEnd);

lenght = lastOccurence - (firstOccurance + spanStart.Length);

quantity = $"Quantity: " + input.Substring(firstOccurance + spanStart.Length, lenght);

firstOccurance = input.IndexOf(divStart);
lastOccurence =  input.IndexOf(divEnd);

output = input.Remove(lastOccurence, divEnd.Length);
output = "Output: " + output.Remove(firstOccurance, divStart.Length);

Console.WriteLine(quantity);
Console.WriteLine(output);