namespace DoublyLinkedList.MyList
{
    class Node<T>
    {
        public T _data { get; set; }
        public Node<T> _prev { get; set; }
        public Node<T> _next { get; set; }

        public Node(T data)
        {
            _data = data;
        }
    }
}
