namespace ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            var ll = new MyLinkedList<int>();
            ll.Add(10);
            ll.Add(20);
            ll.Add(30);
            ll.Add(40);
            ll.Add(50);
            ll.Remove(3);
            Console.WriteLine(ll.ToString());
            Console.WriteLine(ll.Count());
            Console.WriteLine(ll.Get(3));


            MyArrayList<double> genericList = new MyArrayList<double>();
            genericList.Add(1.111);
            genericList.Add(2.222);
            genericList.Add(3.333);
            genericList.Add(4.444);
            genericList.Add(5.555);
            genericList.Add(6.666);
            genericList.Add(7.777);
            genericList.Add(8.888);
            genericList.Add(9.999);

            genericList.Remove(4.444);
            //genericList.Insert2(2, 0.000);

       

            //genericList.Insert(3, 8);

            //int _count = genericList.Count() + 1;
            //Console.WriteLine("Before: " + genericList.Count());


            //for (int i = 0; i < _count; i++)
            //{
            //    Console.WriteLine(genericList.Get(i));
            //}
            //Console.WriteLine("After: " + genericList.Count());

            //genericList.Get(1);

            //genericList.Remove(5);

            //genericList.RemoveAt(0);

            //genericList.Count();

            //genericList.Clear();

        }
    }
}