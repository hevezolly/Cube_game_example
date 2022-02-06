using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

public abstract class DestinationCalculator : MonoBehaviour
{
    public abstract Block GetDestination(Vector2Int jumpDir);
}
