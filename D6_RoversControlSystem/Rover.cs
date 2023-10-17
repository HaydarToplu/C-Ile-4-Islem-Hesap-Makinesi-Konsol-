using System.Threading;

namespace D6_RoversControlSystem;

public class Rover
{
    public int Id { get; set;}
    public int X { get; set; }
    public int  Y{ get; set; }
    public char Direction { get; set; }
    
    public static int GlobalId;
    
    public Rover(int roverx, int rovery,  char direction)
    {
        Id = Interlocked.Increment(ref GlobalId);
        X = roverx;
        Y = rovery;
        Direction = direction;
    }

    public void TurnLeft()
    {
        switch (Direction)
        {
            case 'N':
                Direction = 'W';
                break;
            case 'W':
                Direction = 'S';
                break;
            case 'S':
                Direction = 'E';
                break;
            case 'E':
                Direction = 'N';
                break;
        }
    }
    
    public void TurnRight()
    {
        switch (Direction)
        {
            case 'N':
                Direction = 'E';
                break;
            case 'W':
                Direction = 'N';
                break;
            case 'S':
                Direction = 'W';
                break;
            case 'E':
                Direction = 'S';
                break;
        }
    }
    
    public void MoveFwd()
    {
        var (x, y) = Direction.ToCoordinate();
        X += x;
        Y += y;
    }
    
    public override string ToString()
    {
        return $"{X} {Y} {Direction}";
    }
}
