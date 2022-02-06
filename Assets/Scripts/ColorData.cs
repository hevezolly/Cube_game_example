using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

[CreateAssetMenu(fileName = "new color data", menuName = "Color data")]
public class ColorData : ScriptableObject
{
    [SerializeField]
    private ScriptableValue<Color> color;

    [SerializeField]
    private bool _isBaseColor;

    public Color Color => color.Value;
    public ScriptableValue<Color> Value => color;
    public bool IsBase => _isBaseColor;
    public bool IsActiveColor => !_isBaseColor;
}
