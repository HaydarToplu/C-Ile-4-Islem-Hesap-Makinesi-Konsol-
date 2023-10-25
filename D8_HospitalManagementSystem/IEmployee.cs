using System.Diagnostics;

namespace D8_HospitalManagementSystem;

public interface IEmployee
{
    public static int EmpGlobalId = 0;
    
    public static int PatientGlobalId = 0;
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
    
    public void IncreaseRank();
    public void DecreaseRank();
}