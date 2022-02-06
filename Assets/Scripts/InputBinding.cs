using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{
    [CreateAssetMenu(fileName = "new List KeyToDirection", menuName = "Values/ListKeyToDirection")]
    public class InputBinding : ExposedValue<List<KeyToDirection>>
    {

        public Vector2Int? GetDirection()
        {
            foreach(var ktd in Value)
            {
                foreach (var key in ktd.keys)
                {
                    if (Input.GetKeyDown(key))
                        return ktd.direction;
                }
            }
            return null;
        }
    }
}

[System.Serializable]
public class KeyToDirection
{
    public Vector2Int direction;
    public List<KeyCode> keys;
}
