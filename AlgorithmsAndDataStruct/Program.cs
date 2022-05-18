using System;
using System.Linq;

namespace Lesson6
{
    class Lesson6
    {
        public static void Main()
        {
            // Создадим простой граф со "случайными" значениями.
            var startNode = new Node(4,
                new Node(1,
                    new Node(4),
                    new Node(4),
                    new Node(6),
                    new Node(1)
                    ),
                new Node(3, 
                    new Node(4),
                    new Node(7),
                    new Node(4),
                    new Node(2)
                    )
                );

            // проверим поиск в ширину
            Test.Do(new Node(7), BreadthFirstSearch(startNode, 7));
            Test.Do(new Node(2), BreadthFirstSearch(startNode, 2));
            Test.Do(null, BreadthFirstSearch(startNode, 99999));
            
            // проверим поиск в глубину
            Test.Do(new Node(7), DepthFirstSearch(startNode, 7));
            Test.Do(new Node(2), DepthFirstSearch(startNode, 2));
            Test.Do(null, DepthFirstSearch(startNode, 99999));
            
            Console.ReadLine();
        }

        /// <summary>
        /// Поиск в ширину
        /// </summary>
        /// <returns>Результат поиска</returns>
        private static Node? BreadthFirstSearch(Node startNode, int searchedValue)
        {
            var toCheckQueue = new Queue<Node?>();
            var checkedValues = new List<Node?>();
            
            toCheckQueue.Enqueue(startNode);
            
            while (toCheckQueue.Count > 0)
            {
                var currentNode = toCheckQueue.Dequeue();

                if (currentNode.Value == searchedValue)
                    return currentNode;

                checkedValues.Add(currentNode);
                
                foreach (var link in currentNode.Linked)
                {
                    if (!checkedValues.Contains(link))
                        toCheckQueue.Enqueue(link);
                }
            }
            
            // не найдено
            return null;
        }
        
        /// <summary>
        /// Поиск в глубину
        /// </summary>
        /// <returns>Результат поиска</returns>
        private static Node? DepthFirstSearch(Node startNode, int searchedValue)
        {
            var currentPath = new Stack<Node>();
            var checkedNodes = new List<Node>();
            
            currentPath.Push(startNode);
            
            while (currentPath.Count > 0)
            {
                var currentNode = currentPath.Peek();
                
                if (currentNode.Value == searchedValue)
                    return currentNode;
                
                checkedNodes.Add(currentNode);

                // Если мы в тупике т.к. у узла нет связей
                if (!currentNode.Linked.Any())
                {
                    currentPath.Pop();
                    continue;
                }
                
                // Если мы в тупике т.к. все связи узла проверены
                if (currentNode.Linked.All(x => checkedNodes.Contains(x)))
                {
                    currentPath.Pop();
                    continue;
                }
                
                // У элемента есть связи и некоторые из них ещё не были проверены
                // поэтому закинем один из его непроверенных элементов в стек
                currentPath.Push(
                    currentNode.Linked.Where(x => !checkedNodes.Contains(x)).ToArray()[0]
                    );
            }
            
            // не найдено
            return null;
        }
    }
}