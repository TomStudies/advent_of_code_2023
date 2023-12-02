// Read in the text from the file
string inputText = File.ReadAllText("./test_input");
string[] lines = inputText.Split('\n');

// For each line, split it based on the colon to get the game ID.
// Use the game ID as a key in a dictionary.
Dictionary<int, int[]> cubeCounts = new Dictionary<int, int[]>;
foreach (string line in lines)
{
  
}