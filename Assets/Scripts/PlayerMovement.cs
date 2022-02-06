using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private ScriptableParametrisedEvent<Vector2Int> moveEvent;
    [SerializeField]
    private CubeJumping cubeJumps;

    private void OnEnable()
    {
        moveEvent.Event += Move;
    }

    private void OnDisable()
    {
        moveEvent.Event -= Move;
    }

    private void Move(Vector2Int direction)
    {
        cubeJumps.Jump(direction);
    }
}
