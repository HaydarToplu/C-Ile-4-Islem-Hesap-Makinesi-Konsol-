namespace D3Company;

public interface ICompany
{
   public string Name { get; set; }
   public double Expense { get; set; }

   public Employee Employee { get; set; }
   
   public int TotalEmployees { get; set; }
   public int MaxEmployees { get; set; }
}