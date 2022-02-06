using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

public class InputProvider : MonoBehaviour
{
    [SerializeField]
    private ScriptableParametrisedEvent<Vector2Int> moveEvent;
    [SerializeField]
    private InputBinding currentBinding;

    private void Update()
    {
        var dir = currentBinding.GetDirection();

        if (dir != null)
        {
            moveEvent.Trigger(dir.Value);
        }
    }
}
