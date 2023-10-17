using System;

namespace D6_RoversControlSystem;

public class Menu
{
    public Plateau GetPlateau()
    {
        Console.Write("Plato boyutunu arada bir boşluk bırakarak girin örnek 5 5 : ");
        string[] boyutlar = Console.ReadLine().Split(' ');
        var mapX = int.Parse(boyutlar[0]);
        var mapY = int.Parse(boyutlar[1]);

        return new Plateau(mapX, mapY);
    }

    public void Do(Plateau plateau)
    {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. View deployed rovers");
        Console.WriteLine("2. Deploy rover");
        Console.WriteLine("3. Move rover");
        Console.WriteLine("4. Exit");

        int secim = int.Parse(Console.ReadLine());

        switch (secim)
        {
            case 1:
                ShowRovers(plateau);
                break;
            case 2:
                DeployRover(plateau);
                break;
            case 3:
                MoveRover(plateau);
                break;
            case 4:
                Environment.Exit(0);
                break;
        }
    }

    private void ShowRovers(Plateau plateau)
    {
        foreach (Rover rover in plateau.Rovers)
        {
            Console.WriteLine($"İd {rover.Id} Konum {rover}");
        }
    }

    private void DeployRover(Plateau plateau)
    {
        Console.WriteLine("Gezginin konum ve yön bilgisini bir boşluklu girin  örnek '2 3 E' ");
        string[] deployedRover = Console.ReadLine().Split(' ');
        
        if (deployedRover.Length != 3 || !int.TryParse(deployedRover[0], out int x) ||
            !int.TryParse(deployedRover[1], out int y))
        {
            throw new InvalidOperationException("Hatalı Giriş Yaptınız");
        }
        
        var direction = deployedRover[2].ToUpper();

        if (direction != "N" && direction != "S" && direction != "W" && direction != "E")
        {
            throw new InvalidOperationException("Yanlış yön girdiniz");
        }

        var isSuccess = plateau.AddRover(x, y, direction[0]);
        
        Console.WriteLine(isSuccess ? "Başarıyla yerleştirildi." : "Basarisiz.");
    }

    private void MoveRover(Plateau plateau)
    {
        ShowRovers(plateau);
        Console.Write("Hareket ettirmek istediğiniz gezginin idsini girin : ");
        int chosenId = int.Parse(Console.ReadLine());

        Rover? rover = plateau.Rovers.Find(rover => rover.Id == chosenId);
        
        if (rover == null)
        {
            Console.Write("Bu id ile bir rover bulunamadi");
            return;
        }

        Console.Write("Komutlari girin örnek LWMMS : ");
        string commands = Console.ReadLine();

        plateau.MoveRover(rover, commands);
    }
}