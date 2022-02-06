using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{
    [CreateAssetMenu(fileName = "new string to color data", menuName = "Values/Dctionary string colorData")]
    public class StringToColorValue : ScriptableDictionary<string, ColorData>
    {
    }
}
