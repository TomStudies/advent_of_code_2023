using System.Text.RegularExpressions;

// Read in the text from the file
string inputText = File.ReadAllText("./day_3_input");
string[] lines = inputText.Split("\n");

int sum = 0;

for(int y = 0; y < lines.Length; y++)
{
  string partNum = "";
  for(int x = 0; x < lines[y].Length; x++)
  {
    
    if(Regex.Match(lines[y][x].ToString(), @"\d").Success)
    {
      partNum += lines[y][x];
    }
    else
    {
      if(partNum != "")
      {
        bool foundFlag = false;
        for(int checkY = y - 1; checkY <= y + 1; checkY++)
        {
          if (foundFlag)
          {
            break;
          }
          if (checkY < 0 || checkY >= lines.Length)
          {
            continue;
          }
          for(int checkX = x; checkX >= (x - partNum.Length) - 1; checkX--)
          {
            if (checkX < 0 || checkX >= lines[y].Length)
            {
              continue;
            }
            if(Regex.Match(lines[checkY][checkX].ToString(), @"[^\d\.\r]").Success)
            {
              Console.WriteLine($"Found {lines[checkY][checkX]} at [{checkY}, {checkX}] for {partNum}");
              sum += Int32.Parse(partNum);
              foundFlag = true;
              break;
            }
          }
        }     
        partNum = "";
      }
    }
  }
}

Console.WriteLine(sum);