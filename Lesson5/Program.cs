namespace Lesson5
{
    internal class Program
    {
        static void Main()
        {
            Person p1 = new Person("Игорь", 200000);
            p1.IncreaseSalary(100000);

            int res = Calculator.Sum(2, 2);
            Console.WriteLine(res);

            Console.WriteLine(Randomizer.Randomize(0, 100));

            Vector2 v = new Vector2() { X = 2, Y = 2 };
            Vector2.Parameter = 10;
            Console.WriteLine (Vector2.ScalarMultiple(v, 3));

            Sheep s = new Sheep(new Vector2 { X = 0, Y = 0 });
            //s.Move(1);
            //s.Eat();

            Wolf wolf = new Wolf(new Vector2 { X = 0, Y = 0 }, 200);           
            //wolf.Move(0);
            //wolf.Eat();
            Animal a = new Wolf(new Vector2 { X = 0, Y = 0 }, 200);

            List<Animal> b = new List<Animal>();
            b.Add(s);
            b.Add(wolf);
            foreach (Animal animal in b)
            {
                animal.Eat();
            }
            /*
             * Определить абстрактный класс Персонажа (Character)
             * У него будут статы здоровье и атака. Определен метод Бой
             * Определить три наследника: боец, лучник и щитоносец
             * Боец - просто атака и защита. Во время боя он просто атакует противника
             * Лучник: у него есть свойство Уворот. Во время боя он может увернуться от противника
             * Щитоносец: есть броня, если его атакуют, он уменьшает атаку.
             */

            
        }
    }

    //public void Fight (Character c1)
    //{
    //    c1.TakeDamage(this.Attack);
    //    c1.Fight(this);
    //}

    //public void TakeDamage(int attack)
    //{       
    //     Health -= attack + armor;
    //}

    public abstract class Animal
    {
        public Vector2 Position { get; set; }
        public virtual int Health { get; set; }

        public Animal(Vector2 position) : this(position, 100)
        {

        }

        public Animal(Vector2 position, int health)
        {
            Position = position;
            Health = health;
        }

        public void Move(int direction)
        {
            if (direction == 0)
                Position.X += 1;
            else if (direction == 1)
                Position.Y -= 1;
            else if (direction == 2)
                Position.X -= 1;
            else
                Position.Y += 1;

            Console.WriteLine($"Находится в точке {Position.X}; {Position.Y}");
        }
        public abstract void Eat();       
    }
    public class Sheep : Animal
    {       

        public Sheep (Vector2 position):this(position, 100)
        {
            
        }

        public Sheep (Vector2 position, int health) : base(position, health)
        {
            Position = position;
            Health = health;
        }
        public override void Eat ()
        {
            Console.WriteLine("Овца съела траву");
        }
    }

    public class Wolf : Animal
    {
        private int _health;
        public override int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }
                
        public int Attack { get; set; }
        public Wolf(Vector2 position, int health) : base(position, health)
        {
            Attack = 10;
        }

        public override void Eat()
        {
            Console.WriteLine("Волк съел овцу");
        }
    }





    public class Vector2
    {
        public static int Parameter { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public static double ScalarMultiple (Vector2 v, double scalar)
        {
            return v.X*scalar + v.Y * scalar;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public Person(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public void IncreaseSalary (int step)
        {
            Salary += step;
        }
    }

    static class Calculator
    {
        public static int Sum (int n1, int n2)
        {
            return n1 + n2;
        }

        public static int Diff (int n1, int n2)
        {
            return n1 - n2;
        }           
    }

    static class Randomizer
    {
        private static Random _random = new Random();
        public static int Randomize (int left, int right)
        {
            return _random.Next(left, right);
        }
    }
}