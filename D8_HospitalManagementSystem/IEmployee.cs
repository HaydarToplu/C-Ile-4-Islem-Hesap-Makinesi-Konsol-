using System.Diagnostics;

namespace D8_HospitalManagementSystem;

public interface IEmployee
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

    public void HireEmployee(Hospital hospital ,string name, string surname, string sex, double salary);
    public void RankSystem(Hospital hospital);
}