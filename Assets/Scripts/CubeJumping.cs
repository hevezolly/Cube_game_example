using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;
using DG.Tweening;
using System;

public class CubeJumping : MonoBehaviour
{
    [SerializeField]
    private ScriptableValue<float> jumpDist;
    [SerializeField]
    private ScriptableValue<float> jumpHeight;
    [SerializeField]
    private ScriptableValue<float> jumpTime;
    [SerializeField]
    private DestinationCalculator calculator;
    [SerializeField]
    private List<Side> sides;

    private Sequence jumpSeq;
    private bool isInJump = false;

    private Block currentBlock;

    private void Awake()
    {
        currentBlock = calculator.GetDestination(Vector2Int.zero);
        currentBlock.JumpOn(SelectSide(Vector3.down));
    }

    public JumpResult Jump(Vector2Int direction)
    {
        if (isInJump)
            return JumpResult.InJump;
        Side selfSide = null;
        if (direction.magnitude == 0)
            selfSide = SelectSide(Vector3.down);
        else
            selfSide = SelectSide(new Vector3(direction.x, 0, direction.y));
        Debug.DrawRay(selfSide.transform.position, selfSide.Direction, Color.red, 1);
        var block = calculator.GetDestination(direction);
        if (block == null)
            return JumpResult.NoDestination;
        currentBlock.JumpOff();
        PerformJump(direction, () => 
        {
            block.JumpOn(selfSide);
            currentBlock = block;
        });
        return JumpResult.Success;
    }

    private void PerformJump(Vector2Int direction, Action callback)
    {
        isInJump = true;
        jumpSeq = DOTween.Sequence();
        var offset = (new Vector3(direction.x, 0, direction.y)) * jumpDist.Value;
        jumpSeq.Append(transform.DOBlendableMoveBy(offset, jumpTime.Value));
        
        var axis = Vector3.Cross(new Vector3(direction.x, 0, direction.y).normalized, Vector3.down) * 90f;
        jumpSeq.Join(transform.DOBlendableRotateBy(axis, jumpTime.Value));
        var moveUpSeq = DOTween.Sequence();
        moveUpSeq.Append(transform.DOBlendableMoveBy(Vector3.up * jumpHeight.Value,
            jumpTime.Value / 2).SetEase(Ease.OutQuad));
        moveUpSeq.Append(transform.DOBlendableMoveBy(Vector3.down * jumpHeight.Value,
            jumpTime.Value / 2).SetEase(Ease.InQuad));
        jumpSeq.Join(moveUpSeq);

        jumpSeq.AppendCallback(() =>
            {
                isInJump = false;
                callback();
            });
    }

    private void OnDestroy()
    {
        jumpSeq.Kill();
    }

    private Side SelectSide(Vector3 direction)
    {
        Side theOne = null;
        var alignment = -2f;
        foreach (var side in sides)
        {
            var current = Vector3.Dot(direction.normalized, side.Direction);
            if (current > alignment)
            {
                theOne = side;
                alignment = current;
            }
        }
        return theOne;
    }
}

public enum JumpResult
{
    Success,
    InJump,
    NoDestination
}
