using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlipsActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject glimps;

    private void Awake()
    {
        glimps.SetActive(false);
    }

    public void OnColorSet(ColorData data)
    {
        glimps.SetActive(data.IsActiveColor);
    }
}
