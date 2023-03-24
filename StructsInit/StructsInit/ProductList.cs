using System;

namespace HelloWord
{
    public class Dictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public TValue Get(TKey key) {
            throw new NotImplementedException();
        }
    }
    public class ProductList
    {
        public void Add(Product order)
        {
            throw new NotImplementedException();
        }

        public Product this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
