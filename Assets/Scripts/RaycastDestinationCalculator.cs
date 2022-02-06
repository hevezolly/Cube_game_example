using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

public class RaycastDestinationCalculator : DestinationCalculator
{

    [SerializeField]
    private ScriptableValue<float> jumpDistance;
    [SerializeField]
    private LayerMask blockMask;

    public override Block GetDestination(Vector2Int jumpDir)
    {
        var origin = transform.position + new Vector3(jumpDir.x, 0, jumpDir.y) * jumpDistance.Value;
        var direction = Vector3.down;
        var ray = new Ray(origin, direction);
        Debug.DrawRay(origin, direction * 2);
        if (Physics.Raycast(ray, out var hit, 2, blockMask))
        {
            var block = hit.collider.gameObject.GetComponent<Block>();
            return block;
        }
        return null;
    }
}
