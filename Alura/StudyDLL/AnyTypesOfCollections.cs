using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudyDLL
{
    public enum CollectionType
    {
        Array = 1,
        List = 2,
        HashSet = 3,
        ArrayList = 4,
        SortedList = 5,
        Stack = 6,
        Queue = 7,
        Query = 8
    }

    internal class AnyTypesOfCollections
    {
        public CollectionType Type { private get; set; }
        public int Size { private get; set; }

        private Random rnd = new Random();

        public IEnumerable<int> Generate()
        {
            if (Type == CollectionType.Array)
                return Random().ToArray();

            if (Type == CollectionType.List || Type == CollectionType.Query)
                return Random();

            if (Type == CollectionType.HashSet)
                return Random().ToHashSet();

            if (Type == CollectionType.Stack)
                return Random(new Stack<int>());

            if (Type == CollectionType.Queue)
                return Random(new Queue<int>());

            if (Type == CollectionType.ArrayList)
                return GenerateList(Random(new ArrayList()));

            if (Type == CollectionType.SortedList)
                return GenerateList(Random(new SortedList()));

            return null;
        }

        public IEnumerable<int> Random()
        {
            List<int> array = new List<int>();

            for (int i = 0; i < Size; i++)
                array.Add(rnd.Next());

            return array;
        }
        public ArrayList Random(ArrayList array)
        {
            for (int i = 0; i < Size; i++)
                array.Add(rnd.Next());

            return array;
        }
        public SortedList Random(SortedList array)
        {
            for (int i = 0; i < Size; i++)
                array.Add(i, rnd.Next());

            return array;
        }
        public IEnumerable<int> Random(Stack<int> array)
        {

            for (int i = 0; i < Size; i++)
                array.Push(rnd.Next());

            return array;
        }
        public IEnumerable<int> Random(Queue<int> array)
        {
            for (int i = 0; i < Size; i++)
                array.Enqueue(rnd.Next());

            return array;
        }

        public IEnumerable<int> GenerateList(SortedList array)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < Size; i++)
                list.Add((int)array[i]);

            return list;
        }

        public IEnumerable<int> GenerateList(ArrayList array)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < Size; i++)
                list.Add((int)array[i]);

            return list;
        }

    }
}
