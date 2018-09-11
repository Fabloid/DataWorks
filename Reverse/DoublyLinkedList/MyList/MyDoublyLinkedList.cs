using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList.MyList
{
    public class MyDoublyLinkedList<T> : IEnumerable<T>
    {
        Node<T> _head;
        Node<T> _tail;
        int _count;

        //adding an entry to the top of the list
        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> temp = _head;
            node._next = temp;
            _head = node;
            if (_count == 0)
                _tail = _head;
            else
                temp._prev = node;
            _count++;
        }

        //adding an entry to the end of the list
        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);
            if (_head == null)
                _head = node;
            else
            {
                _tail._next = node;
                node._prev = _tail;
            }
            _tail = node;
        }

        //reverse list by changing links
        public void Reverse()
        {
            Node<T> temp_head = _tail;
            _tail = _head;
            Node<T> current = _tail;
            while (current != null)
            {
                Node<T> temp_prev = current._prev;
                current._prev = current._next;
                current._next = temp_prev;
                current = current._prev;
            }
            _head = temp_head;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current._data;
                current = current._next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
