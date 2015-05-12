using System.Collections.Generic;

namespace DataStructures.Interface
{
    public interface IBuffer<T>
    {
        void Write(T value);
        T Read();
        bool IsEmpty { get; }
    }

    public class Buffer<T> : IBuffer<T>
    {
        readonly protected Queue<T> _queue = new Queue<T>();
 
        public virtual void Write(T value)
        {
            _queue.Enqueue(value);    
        }

        public virtual T Read()
        {
            return _queue.Dequeue();
        }

        public virtual bool IsEmpty
        {
            get { return _queue.Count == 0; }
        }
    }

    public class CircularBuffer<T> : Buffer<T>
    {
        readonly int _capacity;

        public CircularBuffer()
            : this(capacity: 10)
        {
        }

        public CircularBuffer(int capacity)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if (_queue.Count > _capacity)
            {
                _queue.Dequeue();
            }
        }

        public int Capacity
        {
            get { return _capacity; }
        }

        public bool IsFull
        {
            get { return _queue.Count >= _capacity; }
        }
    }
}
