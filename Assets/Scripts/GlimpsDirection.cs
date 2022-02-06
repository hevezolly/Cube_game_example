using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlimpsDirection : MonoBehaviour
{
    [SerializeField]
    private List<MeshRenderer> renderers;
    [SerializeField]
    private Side side;

    private Vector3 lastAngles;
    private Vector3 lastPos;

    private void Awake()
    {
        lastAngles = transform.rotation.eulerAngles;
        lastPos = transform.position;
        UpdateDirection();
    }

    private void Update()
    {
        if (Vector3.Distance(lastAngles, transform.rotation.eulerAngles) > 0.001f
            || Vector3.Distance(lastPos, transform.position) > 0.001f)
        {
            UpdateDirection();
        }
    }

    private void UpdateDirection()
    {
        var dir = side.Direction;
        foreach (var r in renderers)
        {
            r.material.SetVector("_SideDirection", dir);
        }
    }

}
