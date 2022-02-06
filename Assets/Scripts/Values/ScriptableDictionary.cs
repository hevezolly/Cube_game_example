using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{
    public abstract class ScriptableDictionary<K, V> : ScriptableValue<Dictionary<K, V>>
    {
        [System.Serializable]
        private class DictionaryHandler
        {
            public K key;
            public V value;
        }

        [SerializeField]
        private List<DictionaryHandler> values;

        public Dictionary<K, V> dict;

        public override Dictionary<K, V> Value 
        { 
            get 
            {
                if (dict == null)
                    FormDictionary();
                return dict; 
            } 
            set => dict = value; 
        }

        private void FormDictionary()
        {
            dict = new Dictionary<K, V>();
            foreach (var kv in values)
            {
                dict.Add(kv.key, kv.value);
            }
        }
    }
}
