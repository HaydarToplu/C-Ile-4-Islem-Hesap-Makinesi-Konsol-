

namespace D6_RoversControlSystem;

public record Plateau
{
    
    public int X { get; set; }
    public int Y { get; set; }

    public Plateau(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool PlateauCheck(int x, int y)
    {
        return x >= 0 && x <= this.X && y > 0 && y <= this.Y;
    }

}
  