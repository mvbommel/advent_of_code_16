// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Text;

string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day4.txt");
List<string> actualRooms = new List<string>();
//string[] file = new string[] { "aaaaa-bbb-z-y-x-123[abxyz]", "a-b-c-d-e-f-g-h-987[abcde]", "not-a-real-room-404[oarel]", "totally-real-room-200[decoy]" };
long count = 0;
foreach (string line in file)
{
    string[] parts = line.Split('[');
    string controlGroup = parts[1].Remove(parts[1].Length - 1, 1);
    string code = Regex.Match(parts[0], @"^[^0-9]*").Value;
    //List<char> orderedList = parts[0].GroupBy(x => x).OrderBy(x => x.Count()).Select(x=> x.First()).ToList();
    SortedDictionary<char, int> map = new SortedDictionary<char, int>();
    foreach(char c in code)
    {
        if (map.ContainsKey(c))
        {
            map[c]++;
        }
        else
        {
            map.Add(c, 1);
        }
    }
    var ordered= from entry in map orderby entry.Value descending select entry;
    Dictionary<char, int> orderdMap = ordered.ToDictionary(pair => pair.Key, pair => pair.Value);
    orderdMap.Remove('-');

    string checksum = "";
    for(int i = 0; i < 5; i++)
    {
        KeyValuePair<char, int> temp = orderdMap.ElementAt(i);
        checksum += temp.Key;
    }
    if(checksum == controlGroup)
    {
        string[] subsets = parts[0].Split('-');
        int id = Int32.Parse(subsets[subsets.Length - 1]);
        count += id;
        StringBuilder actualName = new StringBuilder(code.Length);
        foreach (char c in code) {
            actualName.Append(decrypt(id, c));
        }
        Console.WriteLine(actualName +" " + id);
    }
}
foreach(string room in actualRooms)
{
    Console.WriteLine(room);
}
Console.WriteLine(count);

char decrypt(int count, char c)
{
    if (c != '-')
    {
        while (count > 0)
        {
            if (c < 'z')
            {
                c++;
            }
            else
            {
                c = 'a';
            }
            count--;
        }
    }
    else
    {
        c = ' ';
    }

    return c;
}