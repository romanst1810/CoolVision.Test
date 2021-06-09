using System;
using System.Linq;
using static ConsoleApp1.Program;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

           

        }

        public void Print<T>(int number ,Node<T> node)
        {
            if (number == 0)
            {
                Console.WriteLine(node.Value.ToString());
            }

            if (number == 3)
            {

            }

            Console.WriteLine();
        }

        public class Node<T>
        {
            public Node<T> LeftNode { get; set; }
            public Node<T> RightNode { get; set; }
            public T Value { get; set; }
        

        public static string WriteNodes()
        {
           
        }



        //public int FirstRepeat(int[] array)
        //{
        //    var res= array.GroupBy(x => x).FirstOrDefault(x => x.Count() > 1);
        //    return res == null ? -1 : res.Key;
        //}
        //class Test
        //{
        //    public int SumLinkedList(Node h1, Node h2)
        //    {

        //        return ToInt32(h1) + ToInt32(h2);
        //    }


        //    public int ToInt32(Node node)
        //    {
        //        int res = node.Key;
        //        var nextNode = node.Next;
        //        while (nextNode != null)
        //        {
        //            res *= 10;
        //            res += nextNode.Key;
        //            nextNode = nextNode.Next;
        //        }

        //        return res;
        //    }
        //}

        //public class Node
        //{
        //    public int Key { get; set; }
        //    public Node Next { get; set; }
        //}


    }
