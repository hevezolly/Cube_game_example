using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorSetter : MonoBehaviour
{
    [SerializeField]
    private List<MeshRenderer> renderers;

    public void SetColor(ColorData data)
    {
        foreach (var renderer in renderers)
        {
            var mat = renderer.material;
            mat.SetColor("_Color", data.Color);
        }
    }
}
