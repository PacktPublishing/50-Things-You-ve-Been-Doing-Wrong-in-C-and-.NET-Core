using System;

namespace Equality
{
    class Entity1
    {
        public Entity1(int id)
        {
            this.Id = id;
        }
        public int Id { get; }
        public  override  int GetHashCode() => this.Id;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            return obj is Entity1 e1 && e1.Id == this.Id;
        }
    }

     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
