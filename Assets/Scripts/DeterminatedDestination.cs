using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminatedDestination : DestinationCalculator
{
    [SerializeField]
    private Block Floor;
    public override Block GetDestination(Vector2Int jumpDir)
    {
        return Floor;
    }
}
