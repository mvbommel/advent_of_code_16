// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day2.txt");
List<char> code = new List<char>();
List<Key> keypad= new List<Key>();
for(int i =1; i <14; i++)
{
    switch (i)
    {
        case 1:
            keypad.Add(new Key('1', 3, 0));
            break;
        case 2:
            keypad.Add(new Key('2', 2, 1));
            break;
        case 3:
            keypad.Add(new Key('3', 3, 1));
            break;
        case 4:
            keypad.Add(new Key('4', 4, 1));
            break;
        case 5:
            keypad.Add(new Key('5', 1, 2));
            break;
        case 6:
            keypad.Add(new Key('6', 2, 2));
            break;
        case 7:
            keypad.Add(new Key('7', 3, 2));
            break;
        case 8:
            keypad.Add(new Key('8', 4, 2));
            break;
        case 9:
            keypad.Add(new Key('9', 5, 2));
            break;
        case 10:
            keypad.Add(new Key('A', 2, 3));
            break;
        case 11:
            keypad.Add(new Key('B', 3, 3));
            break;
        case 12:
            keypad.Add(new Key('C', 4, 3));
            break;
        case 13:
            keypad.Add(new Key('D', 3, 4));
            break;
    }
}

Key current = new Key('5', 1, 2);

foreach(string line in file)
{
    char[] chars = line.ToCharArray();
    foreach(char c in chars) {
        switch (c)
        {
            case 'U':
                if(current.y - 1 >= 0 && current.x ==3)
                {
                    current = keypad.Find(x => x.x == current.x && x.y == current.y - 1);
                }
                else if(current.y - 1 >= 1 && (current.x == 2 || current.x == 4))
                {
                    current = keypad.Find(x => x.x == current.x && x.y == current.y - 1);
                }
                break;
            case 'D':
                if (current.y + 1 <= 4 && current.x == 3)
                {
                    current = keypad.Find(x => x.x == current.x && x.y == current.y + 1);
                }
                else if(current.y + 1 <= 3 && (current.x == 2 || current.x == 4))
                {
                    current = keypad.Find(x => x.x == current.x && x.y == current.y + 1);
                }
                break;
            case 'L':
                if (current.x - 1 > 0 && current.y == 2)
                {
                    current = keypad.Find(x => x.x == current.x -1 && x.y == current.y);
                }
                else if(current.x - 1 > 1 && (current.y == 1 || current.y == 3))
                {
                    current = keypad.Find(x => x.x == current.x - 1 && x.y == current.y);
                }
                break;
            case 'R':
                if (current.x + 1 <= 5 && current.y == 2)
                {
                    current = keypad.Find(x => x.x == current.x + 1 && x.y == current.y);
                }
                else if (current.x + 1 <= 4 && (current.y == 1 || current.y == 3))
                {
                    current = keypad.Find(x => x.x == current.x + 1 && x.y == current.y);
                }
                break;
        }
    }
    code.Add(current.value);
}

Console.WriteLine(new string(code.ToArray()));

class Key
{
    public char value { get; set; }
    public int x { get; set; }
    public int y { get; set; }

    public Key(char value, int x, int y)
    {
        this.value = value;
        this.x = x;
        this.y = y;
    }
}