// Day 1 Part 1

// Read in the text from the file
string inputText = File.ReadAllText("./day_1_input");
string[] lines = inputText.Split('\n');
// Declare Some Stuff
int sum = 0;
char[] digits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
// Scan each line.
foreach (string line in lines)
{
  // Create a reverse version of the line
  char[] individualChars = line.ToCharArray();
  Array.Reverse(individualChars);
  string reverseLine = new string(individualChars);
  // Find the first index of any digit in the forwards/backwards lines
  int firstDigitIdx = line.IndexOfAny(digits);
  int lastDigitIdx = reverseLine.IndexOfAny(digits);
  // Account for the no digit lines
  if (firstDigitIdx == -1 || lastDigitIdx == -1)
  {
    continue;
  } else
  {
    // Get the digits, convert to a 2 digit num, and sum
    int firstDigit = (int)char.GetNumericValue(line, firstDigitIdx);
    int lastDigit = (int)char.GetNumericValue(reverseLine, lastDigitIdx);
    int twoDigit = (firstDigit * 10) + lastDigit;
    sum += twoDigit;
  }
}

Console.WriteLine(sum);

// Day 1 Part 2