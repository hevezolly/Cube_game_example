using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private ScriptableValue<float> jumpDistance;
    [SerializeField]
    private Vector3 origin;
    [SerializeField]
    private ScriptableValue<Dictionary<string, ColorData>> colorEncoding;
    [SerializeField]
    private ScriptableValue<Dictionary<string, GameObject>> blocksEncoding;
    [SerializeField]
    private LevelLayout level;

    public void GenerateLevel()
    {
        ClearLevel();
        var layout = level.GetLayout();
        for (var x = 0; x < level.Resolution.x; x++)
        {
            for (var  y = 0; y < level.Resolution.y; y++)
            {
                if (layout[x, y] == null)
                    continue;
                var offset = new Vector3(x, 0, y) * jumpDistance.Value;
                var color = colorEncoding.Value[layout[x, y][0].ToString()];
                var obj = blocksEncoding.Value[layout[x, y][1].ToString()];
                var block = Instantiate(obj, transform);
                block.transform.position = origin + offset;
                block.GetComponent<Side>().ApplyColor(color);
            }
        }
    }

    public void ClearLevel()
    {
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (level == null || jumpDistance == null)
            return;
        for (var x = 0; x < level.Resolution.x; x++)
        {
            for (var y = 0; y < level.Resolution.y; y++)
            {
                var offset = new Vector3(x, 0, y) * jumpDistance.Value;
                Gizmos.DrawWireCube(origin + offset - Vector3.up / 2, Vector3.one);
            }
        }
    }
}
