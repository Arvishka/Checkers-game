using System;

internal interface Enumeration
{
    bool hasMoreElements();
    object nextElement();
}

internal class NoSuchElementException : Exception
{
}

internal class ListNode
{
    internal ListNode prev, next;
    internal object value;

    public ListNode(object elem, ListNode prevNode, ListNode nextNode)
    {
        value = elem;
        prev = prevNode;
        next = nextNode;
    }
}

internal class List
{
    private ListNode head;
    private ListNode tail;
    private int count;
    public List()
    {
        count = 0;
    }

    public void push_front(object elem)
    {
        ListNode node = new ListNode(elem, null, head);

        if (head != null)
            head.prev = node;
        else
            tail = node;

        head = node;
        count++;
    }

    public void push_back(object elem)
    {
        ListNode node = new ListNode(elem, tail, null);
        if (tail != null)
            tail.next = node;
        else
            head = node;
        tail = node;
        count++;
    }

    public object pop_front()
    {
        if (head == null)
            return null;
        ListNode node = head;
        head = head.next;
        if (head != null)
            head.prev = null;
        else
            tail = null;
        count--;
        return node.value;
    }

    public object pop_back()
    {
        if (tail == null)
            return null;
        ListNode node = tail;
        tail = tail.prev;
        if (tail != null)
            tail.next = null;
        else
            head = null;
        count--;
        return node.value;
    }

    public bool isEmpty()
    {
        return head == null;
    }

    public int length()
    {
        return count;
    }

    public void append(List other)
    {
        ListNode node = other.head;

        while (node != null)
        {
            push_back(node.value);
            node = node.next;
        }
    }

    public void clear()
    {
        head = tail = null;
    }

    public object peek_head()
    {
        if (head != null)
            return head.value;
        else
            return null;
    }

    public object peek_tail()
    {
        if (tail != null)
            return tail.value;
        else
            return null;
    }

    public bool has(object elem)
    {
        ListNode node = head;
        while (node != null && !node.value.Equals(elem))
            node = node.next;
        return node != null;
    }

    public object clone()
    {
        List temp = new List();
        ListNode node = head;
        while (node != null)
        {
            temp.push_back(node.value);
            node = node.next;
        }
        return temp;
    }

    public override string ToString()
    {
        string temp = "[";
        ListNode node = head;
        while (node != null)
        {
            temp += node.value.ToString();
            node = node.next;
            if (node != null)
                temp += ", ";
        }
        temp += "]";

        return temp;
    }

    class Enum : Enumeration
    {
        private ListNode node;
        internal Enum(ListNode start)
        {
            node = start;
        }

        public bool hasMoreElements()
        {
            return node != null;
        }

        public object nextElement()
        {
            Object temp;
            if (node == null)
                throw new NoSuchElementException();
            temp = node.value;
            node = node.next;
            return temp;
        }
    }

    public Enumeration elements()
    {
        return new Enum(head);
    }

}