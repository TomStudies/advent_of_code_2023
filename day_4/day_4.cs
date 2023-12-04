// Day 4 Part 1 Solution

// Read in the text from the file
string inputText = File.ReadAllText("./day_4_input");
string[] cards = inputText.Split("\n");

int sum = 0;

for (int i = 0; i < cards.Length; i++)
{
  cards[i] = cards[i].Substring(cards[i].IndexOf(":") + 1).Trim();
  string[] positions = cards[i].Split(" ");
  List<int> winningNums = new List<int>();
  List<int> numsWeHave = new List<int>();
  bool foundPipe = false;
  for (int j = 0; j < positions.Length; j++)
  {
    int value;
    if (foundPipe)
    {
      bool isNum = int.TryParse(positions[j].Trim(), out value);
      if (isNum)
      {
        numsWeHave.Add(value);
      }
    } 
    else
    {
      bool isNum = int.TryParse(positions[j].Trim(), out value);
      if (isNum)
      {
        winningNums.Add(value);
      }
      else if (positions[j] == "|")
      {
        foundPipe = true;
      }
    }
  }
  int pointsThisCard = 0;
  foreach (int numHad in numsWeHave)
  {
    if (winningNums.Contains(numHad))
    {
      if (pointsThisCard == 0)
      {
        pointsThisCard += 1;
      }
      else
      {
        pointsThisCard *= 2;
      }
    }
  }
  sum += pointsThisCard;
}

Console.WriteLine(sum);

// Day 4 Part 2 Solution

// Read in the text from the file
string inputText = File.ReadAllText("./day_4_input");
string[] cards = inputText.Split("\n");
int[] copyCounts = new int[cards.Length];

for (int i = 0; i < copyCounts.Length; i++)
{
  copyCounts[i] = 1;
}

int sum = 0;

for (int i = 0; i < cards.Length; i++)
{
  cards[i] = cards[i].Substring(cards[i].IndexOf(":") + 1).Trim();
  string[] positions = cards[i].Split(" ");
  List<int> winningNums = new List<int>();
  List<int> numsWeHave = new List<int>();
  bool foundPipe = false;
  for (int j = 0; j < positions.Length; j++)
  {
    int value;
    if (foundPipe)
    {
      bool isNum = int.TryParse(positions[j].Trim(), out value);
      if (isNum)
      {
        numsWeHave.Add(value);
      }
    } 
    else
    {
      bool isNum = int.TryParse(positions[j].Trim(), out value);
      if (isNum)
      {
        winningNums.Add(value);
      }
      else if (positions[j] == "|")
      {
        foundPipe = true;
      }
    }
  }
  int currentCard = i;
  foreach (int numHad in numsWeHave)
  {
    if (winningNums.Contains(numHad))
    {
      currentCard += 1;
      for(int j = 0; j < copyCounts[i]; j++)
      {
        copyCounts[currentCard] += 1;
      }
    }
  }
}

foreach (int copyCount in copyCounts)
{
  sum += copyCount;
}

Console.WriteLine(sum);