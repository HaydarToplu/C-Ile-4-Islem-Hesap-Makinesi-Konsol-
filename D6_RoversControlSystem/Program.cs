// See https://aka.ms/new-console-template for more information

using D6_RoversControlSystem;

List<Rover> rovers = new List<Rover>();


int mapX, mapY;
Console.Write("Plato boyutunu arada bir boşluk bırakarak girin örnek 5 5 : ");
string[] boyutlar = Console.ReadLine().Split(' ');
mapX= int.Parse(boyutlar[0]);
mapY = int.Parse(boyutlar[1]);

Plateau plateau = new Plateau(mapX, mapY);

while (true)
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
            ShowRovers();
            break;
        case 2:
            DeployRover();
            break;
        case 3:
            MoveRover();
            break;
        case 4:
            Environment.Exit(0);
            break;
    }

    void ShowRovers()
    {
        foreach (Rover rover in rovers)
        {
            Console.WriteLine($"İd {rover.Id} Konum {rover}");
        }
    }

    void DeployRover()
    {
        Console.WriteLine("Gezginin konum ve yön bilgisini bir boşluklu girin  örnek '2 3 E' ");
        string[] deployedRover = Console.ReadLine().Split(' ');
        if (deployedRover.Length != 3 || !int.TryParse(deployedRover[0], out int x) ||
            !int.TryParse(deployedRover[1], out int y))
        {
            Console.WriteLine("Hatalı Giriş Yaptınız ! ");
            return;
        }

        // deployedrover[2] diyince almadı [2][0] da aldı
        char direction = char.ToUpper(deployedRover[2][0]);

        if (direction != 'N' && direction != 'S' && direction != 'W' && direction != 'E')
        {
            Console.WriteLine("Yanlış yön girdiniz !");
            return;
        }

        if (!plateau.PlateauCheck(x, y))
        {
            Console.WriteLine("Map dışına taştınız ! ");
            return;
        }

        if (!IsEmpty(x,y))
        {
            Console.WriteLine("Atama yapmaya calıstıgınız kordinat dolu !");
            return;
        }
        
        Rover newRover = new Rover(x, y, direction);
        rovers.Add(newRover);
        Console.WriteLine("Başarıyla yerleştirildi.");
        

    }

    void MoveRover()
    {
        ShowRovers();
        Console.Write("Hareket ettirmek istediğiniz gezginin idsini girin : ");
        int choosenrv = int.Parse(Console.ReadLine());
        
        //LİNQ DENEDİM YAPAMADIM
        
        foreach (Rover rover in rovers)
        {
            if (choosenrv == rover.Id)
            {   
                // TEMP OLUŞTURMADAN NASIL CHECK EDEBİLİRİM ? 
                // İşlem sonunda temp nesnesini silme ?
                
                Rover temprover = new Rover(rover.X ,rover.Y,rover.Direction);
                Console.Write("Komutlari girin örnek LWMMS : ");
                string commands = Console.ReadLine();
                temprover.Move(commands);
                
                if (IsEmpty(temprover.X , temprover.Y))
                {
                    rover.Move(commands);
                    Console.WriteLine("Başarıyla hareket etti");
                    return;
                }
                else
                {
                    Console.WriteLine("Gitmeye ilerlemeye calıştığınız kordinat dolu ! ");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Geçersiz id girdiniz !");
            }
        }
    }

    bool  IsEmpty(int x, int y)
    {
        return  !rovers.Any(r =>  r.X == x && r.Y == y);
    }
}