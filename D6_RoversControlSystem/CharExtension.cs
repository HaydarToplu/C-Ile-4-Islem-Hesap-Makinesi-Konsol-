using System;

namespace D6_RoversControlSystem;

public static class CharExtension
{
    public static (int, int) ToCoordinate(this char c)
    {
        switch (c)
        {
            case 'N':
                return (0, 1);
            case 'W':
                return (1, 0);
            case 'S':
                return (0, -1);
            case 'E':
                return (-1, 0);
        }
        
        throw new InvalidOperationException("Yanlış yön girdiniz");
    }
}