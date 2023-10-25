namespace D8_HospitalManagementSystem;

public class Cleaner:IEmployee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Sex { get; set; }
    public string Job { get; set; }
    public int Rank { get; set; }
    public int MaxRank { get; set; } = 1;
    public double Salary { get; set; }
    public DateTime DateOfRec { get; set; }
    public DateTime? DateOfFired { get; set; }
    
    
    
    public void IncreaseRank()
    {
        if (Rank == MaxRank)
        {
            Console.WriteLine("Çalışan en üst rütbede ! ");
        }
        else
        {
            Rank++;
            UpdateRank();
        }
    }

    public void DecreaseRank()
    {
        Rank--;
        UpdateRank();
    }

    public void UpdateRank()
    {
        if (Rank == 1)
        {
            Job = Jobs.Cleaner.ToString();
        }
    }
}