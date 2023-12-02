// Day 2 Part 1 Solution

using System.Text.RegularExpressions;

// Declare the amounts the elf wants to know about
const int reds = 12;
const int greens = 13;
const int blues = 14;

// Read in the text from the file
string inputText = File.ReadAllText("./day_2_input");
string[] lines = inputText.Split('\n');

// For each line, split it based on the colon to get the game ID.
// Use the game ID as a key in a dictionary.
// Use the counts (R, G, B) as an int array as the value
Dictionary<int, int[]> cubeCounts = new Dictionary<int, int[]>();
int sum = 0;
foreach (string line in lines)
{
  string[] colonSplit = line.Split(':');
  int gameID = Int32.Parse(Regex.Match(colonSplit[0], @"\d+").Value);

  string[] rounds = colonSplit[1].Split(';');
  int[] rgbVals = [0, 0, 0];
  foreach (string round in rounds)
  {
    string[] cubePiles = round.Split(',');
    foreach (string pile in cubePiles)
    {
      string removedSpace = pile.Substring(1);
      string[] countAndColor = removedSpace.Split(' ');
      int count = Int32.Parse(countAndColor[0]);
      switch (countAndColor[1])
      {
        case "red":
          if (count > rgbVals[0])
          {
            rgbVals[0] = count;
          }
          break;
        case "green":
          if (count > rgbVals[1])
          {
            rgbVals[1] = count;
          }
          break;
        case "blue":
          if (count > rgbVals[2])
          {
            rgbVals[2] = count;
          }
          break;
      }
    }
  }
  if (rgbVals[0] <= reds && rgbVals[1] <= greens && rgbVals[2] <= blues)
  {
    sum += gameID;
  }
}

Console.WriteLine(sum);

// Day 2 Part 2 Solution

using System.Text.RegularExpressions;

// Read in the text from the file
string inputText = File.ReadAllText("./day_2_input");
string[] lines = inputText.Split('\n');

// For each line, split it based on the colon to get the game ID.
// Use the game ID as a key in a dictionary.
// Use the counts (R, G, B) as an int array as the value
Dictionary<int, int[]> cubeCounts = new Dictionary<int, int[]>();
int sum = 0;
foreach (string line in lines)
{
  string[] colonSplit = line.Split(':');
  int gameID = Int32.Parse(Regex.Match(colonSplit[0], @"\d+").Value);

  string[] rounds = colonSplit[1].Split(';');
  int[] rgbVals = [0, 0, 0];
  foreach (string round in rounds)
  {
    string[] cubePiles = round.Split(',');
    foreach (string pile in cubePiles)
    {
      string removedChars = pile.Substring(1);
      // This next line right here was so annoying to deduce
      removedChars = removedChars.Replace("\n", "").Replace("\r", "");
      string[] countAndColor = removedChars.Split(' ');
      int count = Int32.Parse(countAndColor[0]);
      switch (countAndColor[1])
      {
        case "red":
          if (count > rgbVals[0])
          {
            rgbVals[0] = count;
          }
          break;
        case "green":
          if (count > rgbVals[1])
          {
            rgbVals[1] = count;
          }
          break;
        case "blue":
          if (count > rgbVals[2])
          {
            rgbVals[2] = count;
          }
          break;
      }
    }
  }
  sum += (rgbVals[0] * rgbVals[1] * rgbVals[2]);
}

Console.WriteLine(sum);