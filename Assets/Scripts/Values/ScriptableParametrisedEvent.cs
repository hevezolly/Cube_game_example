using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ScriptableValues 
{
    public class ScriptableParametrisedEvent<T> : ScriptableEvent
    {
        public new event Action<T> Event;
        public void Trigger(T value)
        {
            Event?.Invoke(value);
        }
    }
}
