// See https://aka.ms/new-console-template for more information

void stepmethod(int move, bool positive, point current, bool X, List<point> points)
{
   for(int i = 0; i < move; i++)
    {
        if (positive)
        {
            if (X)
            {
                current.X++;
                pointLoop(points, current);
            }
            else
            {
                current.Y++;
                pointLoop(points, current);
            }
        }
        else
        {
            if (X)
            {
                current.X--;
                pointLoop(points, current);
            }
            else
            {
                current.Y--;
                pointLoop(points, current);
            }
        }
    }
}

void pointLoop(List<point> points, point current)
{
    foreach (point point in points)
    {
        if (current.X == point.X && current.Y == point.Y)
        {
            Console.WriteLine("point x: " + current.X + " point y " + current.Y);
            Console.WriteLine("twice " +( Math.Abs(current.X) + Math.Abs(current.Y)));
            return;
        }
    }
    points.Add(new point(current.X, current.Y, current.heading));
}

string file = File.ReadAllText(@"..\..\..\..\..\..\txt\day1.txt");
//string file = "R8, R4, R4, R8";
string[] parts = file.Split(", ");
List<point> points = new List<point>();  
point current = new point(0, 0, "north");

foreach (string part in parts)
{
    int move = Int32.Parse(part.Substring(1, part.Length - 1));
    switch (current.heading)
    {
        case "north":
            if (part[0] == 'L')
            {
                stepmethod(move, false, current, true, points);
                //current.X -= move;
                current.heading = "west";
            }
            else if (part[0] == 'R')
            {
                stepmethod(move, true, current, true, points);
                //current.X += move;
                current.heading = "east";
            }
            break;
        case "east":
            if (part[0] == 'L')
            {
                stepmethod(move, true, current, false, points);
                //current.Y += move;
                current.heading = "north";
            }
            else if (part[0] == 'R')
            {
                stepmethod(move, false, current, false, points);
                //current.Y -= move;
                current.heading = "south";
            }
            break;
        case "south":
            if (part[0] == 'L')
            {
                stepmethod(move, true, current, true, points);
                //current.X += move;
                current.heading = "east";
            }
            else if (part[0] == 'R')
            {
                stepmethod(move, false, current, true, points);
                //current.X -= move;
                current.heading = "west";
            }
            break;
        case "west":
            if (part[0] == 'L')
            {
                stepmethod(move, false, current, false, points);
                //current.Y -= move;
                current.heading = "south";
            }
            else if (part[0] == 'R')
            {
                stepmethod(move, true, current, false, points);
                //current.Y += move;
                current.heading = "north";
            }

            break;
    }
    //Console.WriteLine("point x: " + current.X + " point y " + current.Y);
    //foreach (point point in points)
    //{
    //    if (current.X == point.X && current.Y == point.Y)
    //    {
    //        Console.WriteLine("Math.Abs(current.X) + Math.Abs(current.Y));
    //        return;
    //    }
    //}
    //points.Add(new point(current.X, current.Y, current.heading));
    
}
Console.WriteLine("endpoint " + (Math.Abs(current.X) + Math.Abs(current.Y)));

class point
{
    public int X { get; set; }
    public int Y { get; set; }
    public string heading { get; set; }

    public point(int x, int y, string heading)
    {
        this.X = x;
        this.Y = y;
        this.heading = heading;
    }
}

