namespace D3Company;

public class Employee
{
    public int Id { get; private set; } 
    public string Name { get; set; }
    public string Surname { get; set; }
    public Jobs Job { get; set; }
    public double Salary { get; set; }
    public bool Fired  { get; set; }

    public static int globalId;
    
    

    public Employee(string name, string surname,  double salary ,  Jobs job)
    {
        Id = Interlocked.Increment(ref globalId);
        Name = name;
        Surname = surname;
        Job = job;
        Salary = salary;
        Fired = this.Fired;
    }
}