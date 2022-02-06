using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{
    public abstract class ExposedValueWithCallback<T> : ValueWithCallback<T>
    {
        [SerializeField]
        private T _value;

        public override T Value { get => _value; set { base.Value = value; _value = value; } }
    }
}
