using System;

namespace ServicesGateways.NoiseDetection
{
    public class RingBuffer<T>
    {
        private readonly T[] _buffer;
        private readonly int _maxSize;

        private int _pointer;
        private int _counter;
        private object _cachedFold;

        public RingBuffer(int size)
        {
            _maxSize = size;
            _buffer = new T[_maxSize];
        }

        public void Add(T value)
        {
            _buffer[_pointer] = value;
            _pointer = (_pointer + 1) % _buffer.Length;
            _counter++;
        }

        public bool IsFull() => _counter > _maxSize;

        public T Get(int position) => _buffer[position];

        public TA Fold<TA>(Func<T[], TA> func)
        {
            var fold = func(_buffer);
            _cachedFold = fold;
            return fold;
        }

        public TA CachedFold<TA>(Func<T[], TA> func, int cache)
        {
            if (_pointer % _buffer.Length % cache == 0 || _cachedFold == null)
            {
                _cachedFold = this.Fold(func);
            }
            return (TA)_cachedFold;
        }

    }
}