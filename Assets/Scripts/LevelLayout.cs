using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

[CreateAssetMenu(fileName = "new level layout", menuName = "Level layout")]
public class LevelLayout : ScriptableObject
{
    [SerializeField]
    private Vector2Int resolution;
    public Vector2Int Resolution => resolution;
    [SerializeField]
    [Min(1)]
    private int symbolsForBlock;
    [SerializeField]
    private string blankBlock;
    [SerializeField]
    [TextArea(20, 50)]
    private string Layout;

    public string[,] GetLayout()
    {
        var lines = Layout.Split('\n');
        var result = new string[resolution.x, resolution.y];
        var y = lines.Length-1;
        var yIndex = 0;
        for (; y >= 0; y--)
        {
            lines[y] = lines[y].Replace("|", "");
            var xIndex = 0;
            for (var x = 0; x < Mathf.Min(lines[y].Length, resolution.x * symbolsForBlock); x += symbolsForBlock)
            {
                var encoding = lines[y].Substring(x, symbolsForBlock);
                result[xIndex, yIndex] = (encoding == blankBlock) ? null : encoding;
                xIndex++;
            }
            for (;xIndex < resolution.x; xIndex++)
            {
                result[xIndex, yIndex] = null;
            }
            yIndex++;
        }
        for (; yIndex < resolution.y; yIndex++)
        {
            for (var xIndex = 0; xIndex < resolution.x; xIndex++)
            {
                result[xIndex, yIndex] = null;
            }
        }
        return result;
    }
}
