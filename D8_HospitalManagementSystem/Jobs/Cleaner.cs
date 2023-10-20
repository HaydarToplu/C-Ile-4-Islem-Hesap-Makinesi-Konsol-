namespace D8_HospitalManagementSystem;

public class Cleaner:IEmployee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Sex { get; set; }
    public string Job { get; set; }
    public int Rank { get; set; }
    public int MaxRank { get; set; }
    public double Salary { get; set; }
    public DateTime DateOfRec { get; set; }
    public DateTime? DateOfFired { get; set; }
    public void HireEmployee(Hospital hospital , string name, string surname, string sex, double salary)
    {
        Id = Interlocked.Increment(ref Hospital.EmpGlobalId);
        Name = name;
        Surname = surname;
        Sex = sex;
        Rank = 1;
        MaxRank = 1;
        Job = Jobs.Cleaner.ToString();
        Salary = salary;
        DateOfRec = DateTime.Now;
        DateOfFired = default;
        hospital.TotalEmployees++;
    }
    public void RankSystem(Hospital hospital)
    {
        if (Rank == 1)
        {
            hospital.employee.Job = Jobs.Cleaner.ToString();
        }
    }
}