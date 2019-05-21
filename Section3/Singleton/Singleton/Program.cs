using System;

namespace Singleton
{
    public sealed class Singleton1
    {
        static Singleton1 instance;

        private Singleton1(){}

        public static Singleton1 Instance
        {
            get => instance = instance ?? new Singleton1();
        }
    }
    
    public sealed class Singleton2
    {
        static Singleton2 instance;
        static readonly object locker = new object();

        private Singleton2(){}

        public static Singleton2 Instance
        {
            get 
            {
                lock(locker)
                {
                    instance = instance ?? new Singleton2();
                    return instance;
                }
            }
        }
    }
    public sealed class Singleton3
    {
        static Singleton3 instance;
        static readonly object locker = new object();

        private Singleton3(){}

        public static Singleton3 Instance
        {
            get 
            {
                if(instance == null)
                {
                    lock(locker)
                    {
                        instance = new Singleton3();
                    }
                }
                return instance; 
            }
        }
    }
    public sealed class SingletonLazy
    {
        static Lazy<SingletonLazy> lazy =  new Lazy<SingletonLazy>(() => new SingletonLazy());
        static readonly object locker = new object();

        private SingletonLazy(){}

        public static SingletonLazy Instance => lazy.Value;
        
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
