using System;
namespace Employees {   
interface IEmployee
{
    //Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Methods
    public string Fullname();
    public double Pay();
}
class Employee : IEmployee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee()
    {
        Id = 0;
        FirstName = string.Empty;
        LastName = string.Empty;
    }
    public Employee(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public string Fullname()
    {
        return FirstName + " " + LastName;
    }
    public virtual double Pay()
    {
        double salary;
        Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
        salary = double.Parse(Console.ReadLine());
        return salary;
    }
    sealed class Executive : Employee
    {
        public double Rate { get; set; }
        public int Hours { get; set; }

        public Executive() : base()
        {
            Rate = 0;
            Hours = 0;
        }
        public Executive(int id, string firstName, string lastName, double rate, int hours)
            : base(id, firstName, lastName)
        {
            Rate = rate;
            Hours = hours;
        }
        public override double Pay()
        {
            if (Hours > 40)
                return 40 * Rate + (1.5 * ((Hours - 40) * Rate));
            else
                return Rate * Hours;
        }
    }
        static void Main(string[] args)
        {
            Employee hazel = new Employee(6, "Hazel", "Basil");
            hazel.Pay();

            Executive Gus = new Executive(12, "Gus", "Bold", 20, 10);
            Console.WriteLine(Gus.Fullname());
            Console.WriteLine(Gus.Pay());

            Executive zoey = new Executive();
            zoey.Id = 1;
            zoey.FirstName = "Zoey";
            zoey.LastName = "Grix";
            zoey.Rate = 15;
            zoey.Hours = 30;
            Console.WriteLine(zoey.Fullname());
            Console.WriteLine(zoey.Pay());
        }
}
}