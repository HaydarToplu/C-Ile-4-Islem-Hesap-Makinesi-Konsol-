namespace D3Company;

public class Company : ICompany
{
    public string Name { get; set; }
    public double Expense { get; set; }
    public Employee Employee { get; set; }
    public int MaxEmployees { get; set; }
    public int TotalEmployees { get; set; }

    public Company(string name, int maxEmployees)
    {
        Name = name;
        MaxEmployees = maxEmployees;
        TotalEmployees = 0;
    }
}