using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace ScriptableValues
{
    [CreateAssetMenu(fileName = "new scriptable event", menuName = "Events/None")]
    public class ScriptableEvent : ScriptableObject
    {
        public event Action Event;

        public void Trigger()
        {
            Event?.Invoke();
        }
    }
}
