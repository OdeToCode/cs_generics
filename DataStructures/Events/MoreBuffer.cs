using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataStructures.Events
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        void Write(T value);
        T Read();
        bool IsEmpty { get; }
        IEnumerable<TOut> As<TOut>();
    }

    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public ItemDiscardedEventArgs(T item)
        {
            Item = item;
        }

        public T Item { get; protected set; }
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


        public IEnumerable<TOut> As<TOut>()
        {
            var converter = TypeDescriptor.GetConverter(typeof (T));
            foreach (var item in _queue)
            {
                var result = converter.ConvertTo(item, typeof (TOut));
                yield return (TOut)result;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _queue)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class BufferHelpers
    {
        public static IEnumerable<TOut> CastTo<T, TOut>(this IBuffer<T> buffer)
        {
            foreach (object item in buffer)
            {
                yield return (TOut)item;
            }
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
            if (_queue.Count > _capacity)
            {
                var item = _queue.Dequeue();
                if (ItemDiscarded != null)
                {
                    var args = new ItemDiscardedEventArgs<T>(item);
                    ItemDiscarded(this, args);
                }
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

        public EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;
    }

}
