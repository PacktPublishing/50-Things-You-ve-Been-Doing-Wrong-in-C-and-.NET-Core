using System;
using Microsoft.Extensions.DependencyInjection;

namespace NotJustTesting
{
    class Electricity {}
    class Ram
    {
        public Ram(Electricity electricity){}

    }
    class MainBoard
    {
        public MainBoard(Electricity electricity){}
    }

    class Case 
    {
        public Case(Electricity electricity, Ram ram, MainBoard board ){}

    }
   
    class Peripherals
    {
    }
    class Computer
    {
        public Computer(Peripherals peripherals, Case c){}
    }
    class Program
    {
        static void Main(string[] args)
        {

            var electricity = new Electricity();
            var computer  = 
                new Computer(
                    new Peripherals(), 
                    new Case(electricity, new Ram(electricity), 
                    new MainBoard(electricity)));

            var services = new ServiceCollection();
            services.AddTransient<Computer>();
            services.AddTransient<Peripherals>();
            services.AddTransient<Case>();
            services.AddTransient<Ram>();
            services.AddSingleton<Electricity>();
            services.AddTransient<MainBoard>();
            
            var globalProvider = services.BuildServiceProvider();
            var computer2 = globalProvider.GetService<Computer>();
        }
    }
}
