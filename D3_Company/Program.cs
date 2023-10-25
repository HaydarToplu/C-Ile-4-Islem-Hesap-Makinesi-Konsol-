
using D3Company;
class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("Şirket adını girin : ");
        string cName = Console.ReadLine();
        Console.Write("Max Personel Sayisi : ");
        int MaxEmp = Convert.ToInt32(Console.ReadLine());
        
        Company Sirket = new Company(cName, MaxEmp);
        List<Employee> employees = new List<Employee>();
        char kontrol = 'D';
        
        Console.WriteLine($" {Sirket.Name} Sirketi Yönetimine Hosgeldiniz !");
        
        while (kontrol == 'D')
        {
            Console.WriteLine("1 - Çalışan Ekleme \n 2 - Çalışan Çıkarma \n 3 - Bilgileri Yazdir \n 4 - Çıkış ");
            Console.Write("Yapmak İstediğiniz İşlemi Seçin : ");
            int secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    if (Sirket.TotalEmployees < Sirket.MaxEmployees)
                    {
                        Console.Write("Çalışanın adını girin: ");
                        string Name = Console.ReadLine();
                        Console.Write("Çalışanın soyadını girin: ");
                        string Surname = Console.ReadLine();
                        Console.Write("Çalışanın ücretini girin: ");
                        double Salary = Convert.ToDouble(Console.ReadLine());
                        Sirket.Expense += Salary ;
                        Employee employee = new Employee(Name, Surname, Salary, Jobs.Manager);
                        employees.Add(employee);
                        
                        Sirket.TotalEmployees++;
                        Console.WriteLine("\n Calisan Eklendi !");

                        
                    }
                    else
                    {
                        Console.WriteLine("Şirket Çalışan Sayisi Maximumum Üzerinde ! ");

                    }
                    

                    
                    break;
                case 2:
                    EmployeePrint();
                    Console.Write("İşten Çıkarmak İstediğiniz Çalışanın İd'sini yazınız : ");
                    int firedid = Convert.ToInt32(Console.ReadLine());
                    foreach (Employee employee in employees)
                    {
                        int srcid = employee.Id;
                        if (srcid == firedid)
                        {
                            employee.Fired = true;
                            Sirket.Expense -= employee.Salary;
                            Sirket.TotalEmployees--;
                            Console.WriteLine("İşten Çıkarma Başarılı ! ");
                        }
                        else
                        {
                            Console.WriteLine("Aranan id bulunamadı !");
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine($"Şirket Adı : {Sirket.Name} \n " +
                                      $"Şirket Çalışan Sayisi : {Sirket.TotalEmployees} \n " +
                                      $"Şirket Giderleri :  {Sirket.Expense} \n" +
                                      $" ---------Çalışanlar------------ ");
                    EmployeePrint();

                    break;
                case 4:
                    kontrol = 'A';
                    break;
                
                default:
                    Console.WriteLine("Hatalı Tuşlama Yaptınız !");
                    break;
            }
            
            Console.Write("İşlemlerden Çıkmak için 'Ç' , Devam Etmek için 'D' yaziniz : ");
            kontrol = Convert.ToChar(Console.ReadLine().ToUpper());

        }
    
        void EmployeePrint()
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine(
                    $"Id : {employee.Id} , Adı : {employee.Name} , Soyadi: {employee.Surname} , İşi : {employee.Job} ,  Maaşı : {employee.Salary} , Kovuldu Mu : {employee.Fired} ");
            }
        }
    }
    
}




