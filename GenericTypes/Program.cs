using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strArray = { "First", "Second", "Third" };
            Console.WriteLine("This array has {0} items\n", strArray.Length);

            foreach(string s in strArray)
            {
                Console.WriteLine("Item: {0}", s);
            }
            Array.Reverse(strArray);

            foreach(string s in strArray)
            {
                Console.WriteLine("Reverse Item: {0}", s);
            }

            Console.WriteLine("\n==============\n");

            ArrayList srtArrayList = new ArrayList();
            srtArrayList.AddRange(new string[] { "First", "Second", "Third" });
            Console.WriteLine("srtArrayList has {0} items", srtArrayList.Count);

            srtArrayList.Add("Fourth");
            Console.WriteLine("srtArrayList has {0} items", srtArrayList.Count);

            foreach(string s in srtArrayList)
            {
                Console.WriteLine("ArrayList item: {0}", s);
            }

            Console.WriteLine("\n==============\n");
            UseGenericList(); Console.WriteLine();
            UseGenericStack(); Console.WriteLine();
            UseGenericQueue(); Console.WriteLine();
            UseSortedSet(); Console.WriteLine();
         

            Console.ReadLine();
        }

        static void UseGenericList()
        {
            List<Person> people = new List<Person>()
            {
                new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 },
                new Person { FirstName = "Bart", LastName = "Simpson", Age = 8 },
            };
            Console.WriteLine("Items in list: {0}",people.Count);
            foreach(Person p in people)
            {
                Console.WriteLine("Person: {0}", p);
            }

            Console.WriteLine("Inserting new Person.");
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            Console.WriteLine("Items in list: {0}", people.Count);

            Person[] arrayOfPeople = people.ToArray();
            for(int i = 0; i < arrayOfPeople.Length; i++)
            {
                Console.WriteLine("First Names: {0}",arrayOfPeople[i].FirstName);
            }

        }

        static void UseGenericStack()
        {
            Stack<Person> peopleStack = new Stack<Person>();

            peopleStack.Push(new Person { FirstName = "Bart", LastName = "Simpson", Age = 8 });
            peopleStack.Push(new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            peopleStack.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            //Read element n the top, pop it and then read next
            Console.WriteLine("First person is: {0}", peopleStack.Peek());
            Console.WriteLine("Pop person is: {0}", peopleStack.Pop());

            Console.WriteLine("First person is: {0}", peopleStack.Peek());
            Console.WriteLine("Pop person is: {0}", peopleStack.Pop());

            Console.WriteLine("First person is: {0}", peopleStack.Peek());
            Console.WriteLine("Pop person is: {0}", peopleStack.Pop());

            try
            {
                Console.WriteLine("First person is: {0}", peopleStack.Peek());
                Console.WriteLine("Pop person is: {0}", peopleStack.Pop());
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        static void UseGenericQueue()
        {
            Queue<Person> queuePeople = new Queue<Person>();
            queuePeople.Enqueue(new Person { FirstName = "Bart", LastName = "Simpson", Age = 8 });
            queuePeople.Enqueue(new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            queuePeople.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            Console.WriteLine("{0} is first in line", queuePeople.Peek().FirstName);

            GetCoffe(queuePeople.Dequeue());
            GetCoffe(queuePeople.Dequeue());
            GetCoffe(queuePeople.Dequeue());

            try
            {
                GetCoffe(queuePeople.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

        }

        static void UseSortedSet()
        {
            SortedSet<Person> peopleSet = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 },
                new Person { FirstName = "Bart", LastName = "Simpson", Age = 8 },
            };

            foreach(Person p in peopleSet)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();

            peopleSet.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            peopleSet.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });

            foreach(Person p in peopleSet)
            {
                Console.WriteLine(p);
            }


        }

        private static void UseDictionary()
        {
            Dictionary<string, Person> peopleDictionary = new Dictionary<string, Person>();

        }


        static void GetCoffe(Person p)
        {
            Console.WriteLine("{0} got coffe", p.FirstName);
        }
    }
}
