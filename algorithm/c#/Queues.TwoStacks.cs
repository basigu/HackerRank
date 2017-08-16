using System;
using System.Collections.Generic;
using System.Linq;
/*
A queue is an abstract data type that maintains the order in which elements were added to it, allowing the oldest elements to be removed from the front and new elements to be added to the rear. This is called a First-In-First-Out (FIFO) data structure because the first element added to the queue (i.e., the one that has been waiting the longest) is always the first one to be removed.

A basic queue has the following operations:

Enqueue: add a new element to the end of the queue.
Dequeue: remove the element from the front of the queue and return it.
In this challenge, you must first implement a queue using two stacks. Then process  queries, where each query is one of the following  types:

1 x: Enqueue element  into the end of the queue.
2: Dequeue the element at the front of the queue.
3: Print the element at the front of the queue.
Input Format

The first line contains a single integer, , denoting the number of queries. 
Each line  of the  subsequent lines contains a single query in the form described in the problem statement above. All three queries start with an integer denoting the query , but only query  is followed by an additional space-separated value, , denoting the value to be enqueued.

Constraints

It is guaranteed that a valid answer always exists for each query of type .
Output Format

For each query of type , print the value of the element at the front of the queue on a new line.

Sample Input

10
1 42
2
1 14
3
1 28
3
1 60
1 78
2
2
Sample Output

14
14
 */
namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new QueueAsStacks<int>();
            int iterations = Convert.ToInt32(Console.ReadLine());
            for(var i = 0; i <iterations; i++){
                 var input = Console.ReadLine()
                            .Split(' ')
                            .Select(item => Convert.ToInt32(item));
                ProcessCommand(queue, input);
            }
        }

        private static void ProcessCommand(QueueAsStacks<int> queue, IEnumerable<int> input){
            switch(input.First()){
                case 1: 
                    queue.Enqueue(input.Last());
                    break;
                case 2:
                    queue.Dequeue();
                    break;
                case 3: 
                    Console.WriteLine(queue.Peek());
                    break;
            }
        }
    }

    public class QueueAsStacks<T>
    {
        private readonly Stack<T> _inBox;
        private readonly Stack<T> _outBox;
        public QueueAsStacks()
        {
            _inBox = new Stack<T>();
            _outBox = new Stack<T>();
        }

        public void Enqueue(T value)
        {
            _inBox.Push(value);
        }

        public T Dequeue()
        {
            PrepareStacks();
            return _outBox.Pop();
        }

        public T Peek()
        {
            PrepareStacks();
            return _outBox.Peek();
        }

        private void PrepareStacks()
        {
            if (_outBox.Count > 0) return;
            while (_inBox.Count > 0)
            {
                _outBox.Push(_inBox.Pop());
            }
        }
    }
}
