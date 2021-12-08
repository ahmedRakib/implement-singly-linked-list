using System;

namespace ImplementSinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var linkedList = new LinkedList();
            linkedList.InsertAtTheBeginning(1);
            linkedList.InsertAtTheBeginning(0);
            //linkedList.InsertAtTheEnd(5);
            //linkedList.InsertSorted(3);
            linkedList.InsertSorted(2);
            linkedList.InsertSorted(5);

            linkedList.InsertAtTheEnd(6);

            linkedList.InsertSorted(4);

            linkedList.DeleteANode(1);

            linkedList.PrintLinkedList();

            Console.ReadLine();

        }
    }

    class Node
    {
        public int Data { get; set; }

        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
        }

        public void PrintNodeVale()
        {
            Console.WriteLine("{ " + Data + " }");
        }
    }

    class LinkedList
    {
        public Node Head { get; set; }

        public void InsertAtTheBeginning(int data) 
        {
            var newNode = new Node(data);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                if(Head.Data > newNode.Data)
                {
                    newNode.Next = Head;
                    Head = newNode;
                }
                else
                {
                    Console.WriteLine("List contains smaller value. Cannot be inserted at the beginning");
                }
              
            }
        }

        public void InsertAtTheEnd(int data)
        {
            var newNode = new Node(data);
            var current = Head;
            bool biggerNodeExists = false;

            if(current == null)
            {
                Head = newNode;
            }
            else
            {
                while (current.Next != null)
                {
                    #region old solution
                    //if(current.Next == null)
                    //{
                    //    current.Next = newNode;
                    //    newNode.Next = null;
                    //    break;
                    //}
                    #endregion

                    if (current.Data > data)
                    {
                        //cannot add smaller value in the end in a sorted linked list
                        biggerNodeExists = true;
                        break;
                    }

                    //loop through untill current.next is null  (i,e current = last node)
                    current = current.Next;
                }

                if(!biggerNodeExists && current.Data < data)
                current.Next = newNode;
            }
        }

        public void InsertSorted(int data)
        {
            var newNode = new Node(data);
            var current = Head;

            if(current == null || current.Data > newNode.Data)
            {
                newNode.Next = current;
                Head = newNode;
            }
            else
            {
                while (current != null)
                {
                    if (current.Next == null)
                    {
                        current.Next = newNode;
                        break;
                    }
                    else if (current.Next.Data > newNode.Data)
                    {
                        newNode.Next = current.Next;
                        current.Next = newNode;
                        break;
                    }

                    current = current.Next;
                }

            }
        }

        public void DeleteANode(int data) 
        {
            var current = Head;
            if(current.Data == data)
            {
                if(current.Next == null)
                {
                    Head = null;
                }
                else
                {
                    Head = current.Next;
                }
                  
            }
            else
            {
                while (current.Next != null)
                {
                    if (current.Next.Data == data)
                    {
                        var temp = current.Next.Next;
                        current.Next = temp;
                        break;
                    }

                    current = current.Next;
                }
            }
        }

        public void PrintLinkedList()
        {
            var current = Head;
            while(current != null)
            {
                current.PrintNodeVale();
                current = current.Next;
            }
        }
    }
}
