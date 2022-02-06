using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{
    public abstract class ExposedValue<T> : ScriptableValue<T>
    {
        [SerializeField]
        protected T _value;
        public override T Value { get => _value; set => _value = value; }
    }
}
