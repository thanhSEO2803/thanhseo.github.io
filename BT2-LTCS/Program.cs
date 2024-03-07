using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BT2_LTCS
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Vehicle(int id, string name, string manufacture, int year, decimal price)
        {
            Id = id;
            Name = name;
            Manufacture = manufacture;
            Year = year;
            Price = price;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Tên xe: {Name}, Hang: {Manufacture}, Nam san xuat: {Year}, Giá: {Price}";
        }
    }
        public class Car : Vehicle
        {
            public int NumberOfSeats { get; set; }
            public Car(int id, string name, string manufacture, int year, decimal price, int numberofseats) : base(id, name, manufacture, year, price)
            {
                NumberOfSeats = numberofseats;
            }
            public override string ToString()
            {
                return base.ToString() + $", So cho ngoi: {NumberOfSeats}";
            }

        }

        public class Truck : Vehicle
        {
            public double PayloadCapacity { get; set; }
            public string Company { get; set; }

        public Truck(int id, string name, string manufacture, int year,decimal price, double payloadCapacity,string company) : base(id, name, manufacture, year, price)
            {
                PayloadCapacity = payloadCapacity;
                Company = company;
            }
            public override string ToString()
            {
                return base.ToString() + $", Tai trong: {PayloadCapacity}";
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<Car> cars = new List<Car>()
                {
                new Car(1, "Toyota Veloz", "Toyota",1989, 500000,5),
                new Car(2, "Honda cerato", "Honda",2000, 200000,5),
                new Car(3, "Toyota Camry", "Toyota",2021, 100000,5),
                new Car(4, "Ford Titanium", "Ford" ,2020, 700000,4),
                new Car(5, "Honda city", "Honda",1990, 800000,4),
                };
                
                Console.WriteLine("DANH SÁCH CAR");
                foreach(var car in cars)
                {
                Console.WriteLine(car);
                }
                // Hiển thị xe có giá trong khoảng 100.000 đến 250.000
                Console.WriteLine("\n*** a) Xe có giá tu 100.000 đen 250.000:");
                foreach (var car in cars.Where(c => c.Price >= 100000 && c.Price <= 250000))
                {
                    Console.WriteLine(car);
                }

                // Hiển thị xe có năm sản xuất sau 1990
                Console.WriteLine("\n*** b) Xe có nam san xuat sau 1990:");
                foreach (var car in cars.Where(c => c.Year > 1990))
                {
                    Console.WriteLine(car);
                }
                // Gom xe theo hãng sản xuất
                var carsByManu = cars.GroupBy(c => c.Manufacture);

                // Tính tổng giá trị theo nhóm
                Console.WriteLine("\n c) Gia tri theo hang");
                foreach (var group in carsByManu)
                {
                    Console.WriteLine($"Theo Hang: {group.Key}");
                    var totalValue = group.Sum(c => c.Price);
                    Console.WriteLine($"Tong gia tri: {totalValue}");
                }


            // Tạo danh sách Truck
            List<Truck> trucks = new List<Truck>()
            {
                new Truck(1,"F-150","Honda", 2023, 350000, 8,"Honda Motor Kawasaki"),
                new Truck(2, "Silverado","Chevrolet", 2022, 400000,10.5, "General Motors"),
                new Truck(3, "Saka","Thaco", 2021, 250000,7.8, "Stellantis"),
                new Truck(4, "Tundra","Toyota", 2020, 300000,5, "Toyota Motor Corporation"),
            };

            // Hiển thị danh sách Truck
            Console.WriteLine("Danh Sách Truck");
            foreach (Truck truck in trucks)
            {
                Console.WriteLine(truck.ToString());
            }

            // Sắp xếp danh sách Truck theo năm sản xuất mới nhất
            trucks.Sort((x, y) => y.Year.CompareTo(x.Year));

            // Hiển thị danh sách Truck theo thứ tự năm sản xuất mới nhất
            Console.WriteLine("\n*** a)Danh sách Truck theo thu tu nam san xuat moi nhat:");
            foreach (Truck truck in trucks)
            {
                Console.WriteLine(truck.ToString());
            }

            // Hiển thị tên công ty chủ quản của Truck
            Console.WriteLine("\n*** b)Tên công ty chu quan cua Truck:");
            foreach (Truck truck in trucks)
            {
                Console.WriteLine("ID:"+truck.Id+", "+"Cong ty:"+truck.Company);
            }
            Console.ReadLine();
        }
    }
}
