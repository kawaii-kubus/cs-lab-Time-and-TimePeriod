namespace Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(24, 0, 0);
            Time t2 = new Time(11, 0, 0);

            TimePeriod tP1 = new TimePeriod(124,0,0);
            TimePeriod tP2 = new TimePeriod(1,0,0);


            Console.WriteLine(t1 - t2);

        }
    }
}