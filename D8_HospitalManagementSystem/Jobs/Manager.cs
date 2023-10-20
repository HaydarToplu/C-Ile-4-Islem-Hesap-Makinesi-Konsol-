namespace D8_HospitalManagementSystem;

public class Manager : IEmployee
{
    public int Id { get; set; } // TODO: Guid (Guid.NewGuid() olarak yeni guid uretilebilir)
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Sex { get; set; }
    public string Job { get; set; }
    public int Rank { get; set; }
    public int MaxRank { get; set; }
    public double Salary { get; set; }
    public DateTime DateOfRec { get; set; }
    public DateTime? DateOfFired { get; set; }
    public void HireEmployee(string name, string surname, string sex, double salary)
    {
        Id = Interlocked.Increment(ref IEmployee.EmpGlobalId);
        Name = name;
        Surname = surname;
        Sex = sex;
        Job = Jobs.Manager.ToString();
        Rank = 1;
        MaxRank = 3;
        Salary = salary;
        DateOfRec = DateTime.Now;
        DateOfFired = default;
    }

    public void IncreaseRank()
    {
        Rank++;
        UpdateRank();
    }
    
    public void DecreaseRank()
    {
        Rank--;
        UpdateRank();
    }

    private void UpdateRank()
    {
        if (Rank == 1)
        {
            Job = Jobs.Manager.ToString();
        }
        else if (Rank == 2)
        {
            Job  = Jobs.DepartmentManager.ToString();
        }
        else if (Rank == 3)
        {
            Job = Jobs.GeneralManager.ToString();
        }
    }
}