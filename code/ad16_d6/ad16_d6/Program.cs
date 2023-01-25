// See https://aka.ms/new-console-template for more information
using System.Text;

string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day6.txt");
StringBuilder sb = new StringBuilder(file[0].Length);
for(int i = 0; i < file[0].Length; i++)
{
    Dictionary<char, int> charRepetition = new Dictionary<char, int>();
    foreach(string line in file)
    {
        char[] chars= line.ToCharArray();
        if (charRepetition.ContainsKey(chars[i])){
            charRepetition[chars[i]]++;
        }
        else
        {
            charRepetition.Add(chars[i], 1);
        }
    }
    char mostRepeated = charRepetition.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;
    sb.Append(mostRepeated);
}
Console.WriteLine(sb.ToString());