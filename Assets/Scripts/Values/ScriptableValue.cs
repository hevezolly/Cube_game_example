using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{
    public abstract class ScriptableValue<T> : ScriptableObject
    {
        public virtual T Value { get; set; }
    }
}
