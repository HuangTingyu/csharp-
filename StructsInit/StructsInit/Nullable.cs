using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructsInit
{
    public class Nullable<T> where T:struct
    {
        private object _value;

        public Nullable(){}

        public Nullable(T value)
        {
            _value = value;
        }
        //判断value是否为空
        public bool HasValue
        {
            get {
                return _value != null;
            }
        }

        // 获取T默认值
        public T GetValueOrDefault()
        {
            if (HasValue)
            {
                // 如果T类型的_value有值，那返回_value
                return (T)_value;
            }
            // 否则返回T类型的默认值
            return default(T);
        }
    }
}
