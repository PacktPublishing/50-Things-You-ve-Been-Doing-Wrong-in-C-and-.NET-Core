using System;

namespace Virtual
{

    public abstract class Car 
    {
        protected int speed;
        public abstract void Run();
        public virtual void Accelerate() 
            => this.speed += 10;
        public void Stop() 
            => Console.WriteLine("Stopping the car");
    }

    public class Toyota : Car
    {
        public override void Run()
            => Console.WriteLine($"Toyota running at speed:{this.speed}" );
        
    }

  
    public class Ferrari : Car
    {
        public override sealed void Run()
            => Console.WriteLine($"Ferrari running at speed:{this.speed}");

        public override void Accelerate()
            => this.speed += 50;
        

        public new void Stop()
            => Console.WriteLine("Stopping ferrari");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car toyota = new Toyota();
            toyota.Accelerate();
            toyota.Run();

            Car ferrari = new Ferrari();
            ferrari.Accelerate();

            ferrari.Run();
            ferrari.Stop();
            Ferrari realFerrari = (Ferrari)ferrari;
            realFerrari.Stop();
        }
    }
}
