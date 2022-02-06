using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapJumpReaction : MonoBehaviour
{
    [SerializeField]
    private Side blockSide;
    public void OnJumpOn(Side playerSide)
    {
        Side.SwapColors(blockSide, playerSide);
    }
}
