namespace Monitor_Ex
{
    class Program
    {
        static int num = 0;
        static object _lock = new object();

        static void Thread_1()
        {
            for (int i = 0; i < 100000; ++i)
            {
                Monitor.Enter(_lock);
                num++;
                Monitor.Exit(_lock);
            }
        }
        static void Thread_2()
        {
            for (int i = 0; i < 100000; ++i)
            {
                Monitor.Enter(_lock);
                num--;
                Monitor.Exit(_lock);
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Thread_1);
            Thread t2 = new Thread(Thread_2);

            t1.Start();
            t2.Start();

            t1.Join();  
            t2.Join();
            Console.WriteLine(num);
        }
    }
}
