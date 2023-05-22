namespace Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(24, 10, 10);
            Time t2 = new Time(23, 10, 1);

            
            Console.WriteLine(t1 - t2);
            //Time t2 = new Time(12, 11, 12);

        }
    }
}