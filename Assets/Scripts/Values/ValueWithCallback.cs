using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ScriptableValues
{
    public abstract class ValueWithCallback<T> : ScriptableValue<T>
    {
        public event Action<T> ValueChangeEvent;
        public override T Value { get => base.Value; set { ValueChangeEvent?.Invoke(value); base.Value = value; } }
    }
}
