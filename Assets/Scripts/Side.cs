using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Side : MonoBehaviour
{
    [SerializeField]
    private ColorData color;
    [SerializeField]
    private Vector3 _direction;

    public ParametrisedEvent<ColorData> ColorChangeEvent;

    public Vector3 Direction => transform.TransformDirection(_direction.normalized);

    private void Awake()
    {
        if (color != null)
            ApplyColor(color);
    }

    public virtual void ApplyColor(ColorData color)
    {
        this.color = color;
        ColorChangeEvent?.Invoke(color);
    }

    public static void SwapColors(Side one, Side other)
    {
        var c1 = one.color;
        var c2 = other.color;
        if (c1 == c2)
            return;
        if (c1.IsActiveColor && c2.IsActiveColor)
            return;
        one.ApplyColor(c2);
        other.ApplyColor(c1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawLine(Vector3.zero, _direction.normalized);
    }
}
