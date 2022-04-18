using System;

namespace Task1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }
    
    public interface ILinkedList
    {
        int GetCount(); // возвращает кол-во элементов в списке
        void AddNode(int value); // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public sealed class LinkedList : ILinkedList
    {
        private int Count { get; set; }
        private Node StartNode { get; set; }
        
        public LinkedList(int value) => StartNode = new Node() {Value = value};

        public int GetCount() => Count;

        public void AddNode(int value)
        {
            var currentNode = StartNode;

            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }

            Node node = new Node()
            {
                Value = value,
                PrevNode = currentNode
            };

            currentNode.NextNode = node;
            
            Count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node()
            {
                Value = value,
                NextNode = node.NextNode,
                PrevNode = node
            };

            node.NextNode.PrevNode = newNode;
            node.NextNode = newNode;
            
            Count++;
        }

        public void RemoveNode(int index)
        {
            if (index == 0)
            {
                StartNode.NextNode.PrevNode = null;
                StartNode = StartNode.NextNode;
            }

            Node currentNode = StartNode;
            int currentIndex = 0;
            while (currentIndex < index)
            {
                currentNode = currentNode.NextNode;
                
                if (currentIndex + 1 == index)
                    RemoveNode(currentNode.NextNode);
                
                currentIndex++;
            }
        }

        public void RemoveNode(Node node)
        {
            node.NextNode.PrevNode = node.PrevNode;
            node.PrevNode.NextNode = node.NextNode;
        }

        public Node FindNode(int searchValue)
        {
            Node currentNode = StartNode;

            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;
                
                currentNode = currentNode.NextNode;
            }

            return null;
        }
    }
    
    class Task1
    {
        public static void Main()
        {
            LinkedList list = new LinkedList(5);
            
            list.AddNode(22);
            list.AddNode(1);
            list.AddNode(42);
            list.AddNode(934);
            list.AddNode(43);
            
            list.RemoveNode(5);
            
            Console.WriteLine(list.FindNode(22).NextNode.Value);
        }
    }
}