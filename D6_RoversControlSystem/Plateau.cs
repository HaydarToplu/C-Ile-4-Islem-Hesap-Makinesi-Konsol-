

using System;
using System.Collections.Generic;
using System.Linq;

namespace D6_RoversControlSystem;

public class Plateau
{
    public List<Rover> Rovers = new List<Rover>();
    private int X { get; init; }
    private int Y { get; init; }

    public Plateau(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool AddRover(int x, int y, char direction)
    {
        if (!IsInLimit(x, y))
        {
            Console.WriteLine("Map dışına taştınız ! ");
            return false;
        }

        if (!IsEmpty(x, y))
        {
            Console.WriteLine("Atama yapmaya calıstıgınız kordinat dolu !");
            return false;
        }
        
        Rovers.Add(new Rover(x,y, direction));
        return true;
    }

    public bool MoveRover(Rover rover, string commands)
    {
        foreach (char command in commands)
        {
            switch (command) 
            {
                case 'L':
                    rover.TurnLeft();
                    break;
                case 'R':
                    rover.TurnRight();
                    break;
                case 'M':
                    (int x, int y) = rover.Direction.ToCoordinate();
                    if (!IsEmpty(rover.X + x, rover.Y + y))
                    {
                        Console.Write("Rover sikisti !");
                        return false;
                    }
                    rover.MoveFwd();
                    break;
            }
        }
        
        return true;
    }
    
    public bool IsEmpty(int x, int y)
    {
        return !Rovers.Any(r => r.X == x && r.Y == y);
    }

    private bool IsInLimit(int x, int y)
    {
        return x >= 0 && x <= this.X && y > 0 && y <= this.Y;
    }
}
  