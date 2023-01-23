// See https://aka.ms/new-console-template for more information
string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day3.txt");
int count = 0;
int falseCount = 0;
Console.WriteLine(file.Length);
int[][] lines = new int[file.Length][];
for (int i =0; i < file.Length; i++)
{
    string[] sides = file[i].Split("  ", StringSplitOptions.RemoveEmptyEntries);
    int[] intSides = new int[sides.Length];
    for(int j = 0; j < 3; j++)
    {
        intSides[j] = Int32.Parse(sides[j]);
    }
    lines[i] = intSides;
}
for(int i = 0; i < lines.Length; i+= 3)
{
    if (lines[i][0] + lines[i +1][0] > lines[i + 2][0] && lines[i][0] + lines[i + 2][0] > lines[i + 1][0] && lines[i + 1][0] + lines[i + 2][0] > lines[i][0])
    {
        count++;
    }
    if (lines[i][1] + lines[i + 1][1] > lines[i + 2][1] && lines[i][1] + lines[i + 2][1] > lines[i + 1][1] && lines[i + 1][1] + lines[i + 2][1] > lines[i][1])
    {
        count++;
    }
    if (lines[i][2] + lines[i + 1][2] > lines[i + 2][2] && lines[i][2] + lines[i + 2][2] > lines[i + 1][2] && lines[i + 1][2] + lines[i + 2][2] > lines[i][2])
    {
        count++;
    }

}

Console.WriteLine(count);