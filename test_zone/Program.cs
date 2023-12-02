// Read in the text from the file
string inputText = File.ReadAllText("./day_1_input");
string[] lines = inputText.Split('\n');
// Declare Some Stuff
int sum = 0;
char[] digits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
string[] numWords = ["zero", "one", "two", "three", "four", "five",
                     "six", "seven", "eight", "nine"];
// Scan each line.
foreach (string line in lines)
{
  // Create a digitized version of the line, replacing numeric
  // words with numerals from beginning to end.
  string digitizedLine = line;
  // Get the indexes of the first occurrence of each num word
  // in the string
  int[] indices = new int[10];
  for (int i = 0; i < 10; i++)
  {
    int firstIdx = digitizedLine.IndexOf(numWords[i]);
    indices[i] = firstIdx;
  }
  // Loop through the string, digitizing as you go
  while (indices.Distinct().ToArray().Length != 1)
  {
    string foundWord = "";
    int foundInt = 0;
    int least = int.MaxValue;
    for (int i = 0; i < 10; i++)
    {
      if (indices[i] < least && indices[i] != -1)
      {
        // The lowest index (that isnt -1) indicates the earliest
        // word to be replaced in the string
        least = indices[i];
        foundWord = numWords[i];
        foundInt = i;
      }
    }
    // Replace the earliest found word with its numeric counterpart up to the second to last character
    digitizedLine = digitizedLine.Replace(foundWord.Substring(0, foundWord.Length - 1), foundInt.ToString());
    for (int i = 0; i < 10; i++)
    {
      int firstIdx = digitizedLine.IndexOf(numWords[i]);
      indices[i] = firstIdx;
    }
  }

  // Create a reverse version of the line
  char[] individualChars = digitizedLine.ToCharArray();
  Array.Reverse(individualChars);
  string reverseLine = new string(individualChars);
  // Find the first index of any digit in the forwards/backwards lines
  int firstDigitIdx = digitizedLine.IndexOfAny(digits);
  int lastDigitIdx = reverseLine.IndexOfAny(digits);
  // Account for the no digit lines
  if (firstDigitIdx == -1 || lastDigitIdx == -1)
  {
    continue;
  } else
  {
    // Get the digits, convert to a 2 digit num, and sum
    int firstDigit = (int)char.GetNumericValue(digitizedLine, firstDigitIdx);
    int lastDigit = (int)char.GetNumericValue(reverseLine, lastDigitIdx);
    int twoDigit = (firstDigit * 10) + lastDigit;
    sum += twoDigit;
  }
}

Console.WriteLine(sum);