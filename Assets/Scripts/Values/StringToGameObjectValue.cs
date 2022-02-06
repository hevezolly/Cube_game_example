using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{
    [CreateAssetMenu(fileName = "new string to gameobject", menuName = "Values/dict string to gameobject")]
    public class StringToGameObjectValue : ScriptableDictionary<string, GameObject>
    {
    }
}
