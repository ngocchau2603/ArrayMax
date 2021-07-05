using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayMax
{
    class Program
    {
        public class Employee
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string DoanhSo { get; set; }

        }
        public Dictionary<string, string> loiChao = new Dictionary<string, string>
        {
            {"10","Tuyệt vời\n(5%)"},
            {"9","Tuyệt vời\n(5%)"},
            {"8","Tuyệt vời\n(5%)"},
            {"7","Rất tốt\n(3.5%))"},
            {"6","Tốt\n(2%)))"},
            {"5","Có cố gắng\n(0.5%)))"},
            {"4","Kém \n(-0.5%)))"},
            {"3","Rất kém \n(-0.5%)))"},
            {"2","Rất kém \n(-1%)))"},
            {"1","Rất kém \n(-1%)))"},
            {"0","Rất kém \n(-1%)))"},

        };
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(employees);
            }
        }
        private static bool MainMenu(List<Employee> employees)
        {
            var program = new Program();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Nhap thong tin nhan vien");
            Console.WriteLine("2) Nhan vien doanh so cao nhat");
            Console.WriteLine("3) Tong so nhan vien doanh so > 2000");
            Console.WriteLine("4) Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    program.AddInfo(employees);
                    return true;
                case "2":
                    program.FindMax(employees);
                    return true;
                case "3":
                    program.CountGreaterThan2000(employees);
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
        private void FindMax(List<Employee> employees)
        {
            var maxDoanhSo = employees.Max(x => x.DoanhSo);
            var maxEmployee = employees.Where(x => x.DoanhSo == maxDoanhSo).FirstOrDefault();
            Console.WriteLine($"Nhan vien doanh so cao nhat: {maxEmployee.Name} tuoi: {maxEmployee.Age} doanh so: {maxEmployee.DoanhSo}");
        }
        private void CountGreaterThan2000(List<Employee> employees)
        {
            var count = employees.Where(x => Convert.ToInt32(x.DoanhSo) * 1000 > 2000).Count();
            Console.WriteLine($"Nhan tong nhan vien muc doanh so > 2000: " + count);
        }
        private void AddInfo(List<Employee> employees)
        {
            Employee e = new Employee();
            Console.WriteLine("Nhap ten");
            e.Name = Console.ReadLine();
            Console.WriteLine("Nhap tuoi");
            e.Age = Console.ReadLine();
            Console.WriteLine("Nhap doanh so");
            e.DoanhSo = Console.ReadLine();
            if (loiChao.ContainsKey(e.DoanhSo))
            {
                var loiChaoCur = loiChao[e.DoanhSo.ToString()];
                Console.WriteLine(loiChaoCur);
            }
            else
            {
                Console.WriteLine("Nhập sai");
            }
            employees.Add(e);
        }
    }
}
