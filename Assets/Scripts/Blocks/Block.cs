using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField]
    private Side side;
    public Side Side => side;

    public ParametrisedEvent<Side> JumpOnEvent;
    public UnityEvent JumpOffEvent;

    public virtual void JumpOn(Side playerSide)
    {
        JumpOnEvent?.Invoke(playerSide);
    }

    public virtual void JumpOff()
    {
        JumpOffEvent?.Invoke();
    }
}
