using System.Collections.Generic;

namespace Katoa
{
    public static class LinkedListExtensions
    {
        public static LinkedListNode<T> Remove<T>(this LinkedListNode<T> node)
        {
            var next = node.Next;
            node.List.Remove(node);
            return next;
        }

        public static LinkedListNode<T> Rotate<T>(this LinkedListNode<T> node, int amount) 
        {
            if (amount > 0)
            {
                for (var n = 0; n < amount; n++)
                {
                    node = node == node.List.First ? node.List.Last : node.Previous;
                }
            }
            else
            {
                for (var n = 0; n < -amount; n++)
                {
                    node = node == node.List.Last ? node.List.First : node.Next;
                }
            }
            return node;
        }
    }
}