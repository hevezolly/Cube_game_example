using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{
    [CreateAssetMenu(fileName = "new HDRcolor", menuName = "Values/HDRColor")]
    public class HDRColor : ScriptableValue<Color>
    {
        [SerializeField]
        [ColorUsage(false, true)]
        private Color _color;
        public override Color Value { get => _color; set => _color = value; }
    }
}
