using System;
using System.Collections;
using System.Collections.Generic;

namespace Lb_7.Classes;

public class CustomLinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public T Value;
        public Node Next;
        public Node Prev;

        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    private Node head;
    private Node tail;
    private int count;

    public CustomLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void AddFirst(T value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
        count++;
    }

    public void AddLast(T value)
    {
        Node newNode = new Node(value);
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        count++;
    }

    public void Clear()
    {
        head = tail = null;
        count = 0;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    public Node Find(T value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Value.Equals(value))
                return current;
            current = current.Next;
        }
        return null;
    }

    public Node FindLast(T value)
    {
        Node current = tail;
        while (current != null)
        {
            if (current.Value.Equals(value))
                return current;
            current = current.Prev;
        }
        return null;
    }

    public bool Remove(T value)
    {
        Node nodeToRemove = Find(value);
        if (nodeToRemove == null)
            return false;

        if (nodeToRemove == head)
            RemoveFirst();
        else if (nodeToRemove == tail)
            RemoveLast();
        else
        {
            nodeToRemove.Prev.Next = nodeToRemove.Next;
            nodeToRemove.Next.Prev = nodeToRemove.Prev;
            count--;
        }
        return true;
    }

    public void RemoveFirst()
    {
        if (head == null)
            throw new InvalidOperationException("List is empty");

        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            head = head.Next;
            head.Prev = null;
        }
        count--;
    }

    public void RemoveLast()
    {
        if (tail == null)
            throw new InvalidOperationException("List is empty");

        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => count;
    public void PrintList()
    {
        Node current = head;
        if (current == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }
        
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}
