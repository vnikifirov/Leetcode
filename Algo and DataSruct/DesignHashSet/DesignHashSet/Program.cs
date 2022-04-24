using System;
using System.Collections.Generic;

namespace DesignHashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var myHashMap = new MyHashMap();
            myHashMap.Put(1, 1); // The map is now [[1,1]]

            var firstValue = myHashMap.Get(1);    // return 2, The map is now [[1,1], [2,2]]
            Console.WriteLine($"Should be 1: {firstValue == 1}");

            myHashMap.Put(2, 2); // The map is now [[1,1], [2,2]]

            var secondValue = myHashMap.Get(2);    // return 2, The map is now [[1,1], [2,2]]
            Console.WriteLine($"Should be 2: {secondValue == 2}");

            myHashMap.Put(2, 1); // The map is now [[1,1], [2,1]] (i.e., update the existing value)

            var ovewrited = myHashMap.Get(2);    // return 1, The map is now [[1,1], [2,1]]
            Console.WriteLine($"Should be 1: {ovewrited == 1}");
        }
    }

    /**
     * Your MyHashSet object will be instantiated and called as such:
     * MyHashSet obj = new MyHashSet();
     * obj.Add(key);
     * obj.Remove(key);
     * bool param_3 = obj.Contains(key);
     */
    public class MyHashSet
    {
        /// <summary>
        /// Size of Hash Table is 10^4
        /// </summary>
        private const int _size = 10_000;

        private record Slot(int Key)
        {
            public Slot Next { get; set; } 
        }

        private Slot[] Slots;

        public MyHashSet() => Slots = new Slot[_size];

        public void Add(int key)
        {
            var hashKey = key.GetHashCode() % _size;
            if (Slots[hashKey] is null)
                Slots[hashKey] = new Slot(key);
            else
            {
                var slot = Slots[hashKey];

                // Singly LinkedList
                while (slot.Next is not null)
                {
                    if (slot.Key == key)
                        return;               

                    slot = slot.Next;
                }

                if (slot.Key != key)
                    slot.Next = new Slot(key);
            }
        }

        public void Remove(int key)
        {
            var hashKey = key.GetHashCode() % _size;
            if (Slots[hashKey] is not null)
            {
                var slot = Slots[hashKey];

                if (slot.Key == key)
                {
                    Slots[hashKey] = slot.Next;
                    return;
                }

                // Singly LinkedList
                while (slot.Next is not null)
                {
                    if (slot.Next.Key == key)
                    {
                        // Node1(Curr) => Node2 = Node1(Curr) => Node2 => Node3
                        slot.Next = slot.Next.Next;
                        return;
                    }

                    slot = slot.Next;
                }
            }
        }

        public bool Contains(int key)
        {
            var hashKey = key.GetHashCode() % _size;
            var slot = Slots[hashKey];

            // Singly LinkedList
            while (slot is not null)
            {
                if (slot.Key == key)
                    return true;

                slot = slot.Next;
            }

            return false;
        }
    }

    public class MyHashMap
    {
        /// <summary>
        /// Size of Hash Table is 10^4
        /// </summary>
        private const int _size = 10_000;

        /// <summary>
        /// Node of Hash Map
        /// </summary>
        private record Slot(int Key, int Value)
        {
            public int Value { get; set; } = Value;
            /// <summary>
            /// Next node of Hash Map
            /// </summary>
            public Slot Next { get; set; }
        }

        /// <summary>
        /// Nodes of Hash Map
        /// </summary>
        private Slot[] Slots;

        /// <summary>
        /// CTOR of Hash Map
        /// </summary>
        public MyHashMap() => Slots = new Slot[_size];

        public void Put(int key, int value)
        {
            var hashKey = key.GetHashCode() % _size;
            if (Slots[hashKey] is null)
                Slots[hashKey] = new Slot(key, value);
            else
            {
                var slot = Slots[hashKey];

                // Singly LinkedList
                while (slot.Next is not null)
                {
                    if (slot.Key == key)
                    {
                        Slots[hashKey].Value = value;
                        return;
                    }

                    slot = slot.Next;
                }

                if (slot.Key != key)
                    slot.Next = new Slot(key, value);
                else
                    Slots[hashKey].Value = value;
            }
        }

        public int Get(int key)
        {
            // hash div_remainder shift or sasear cipher (cryptography)
            var hashKey = key.GetHashCode() % _size;
            var slot = Slots[hashKey];

            // Singly LinkedList
            while (slot is not null)
            {
                if (slot.Key == key)
                    return slot.Value;

                slot = slot.Next;
            }

            return -1;
        }

        public void Remove(int key)
        {
            // Shift or Casear cipher (Cryptography)
            var hashKey = key.GetHashCode() % _size;
            if (Slots[hashKey] is not null)
            {
                var slot = Slots[hashKey];

                if (slot.Key == key)
                {
                    Slots[hashKey] = slot.Next;
                    return;
                }

                // Singly LinkedList
                while (slot.Next is not null)
                {
                    if (slot.Next.Key == key)
                    {
                        // Node1(Curr) => Node2 = Node1(Curr) => Node2 => Node3
                        slot.Next = slot.Next.Next;
                        return;
                    }

                    slot = slot.Next;
                }
            }
        }
    }

    /**
     * Your MyHashMap object will be instantiated and called as such:
     * MyHashMap obj = new MyHashMap();
     * obj.Put(key,value);
     * int param_2 = obj.Get(key);
     * obj.Remove(key);
     */
}
