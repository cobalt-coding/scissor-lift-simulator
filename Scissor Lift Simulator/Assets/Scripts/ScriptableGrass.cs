using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScriptableGrass : Tile {
    [SerializeField]
    private Sprite[] grassSprites;

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for(int y = -1; y <= 1; y++)
        {
            for(int x = -1; x <= 1; x++)
            {
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);
                if (CheckGrass(tilemap, nPos))
                {
                    tilemap.RefreshTile(nPos);
                }
            }
        }
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        Vector3Int nPos = new Vector3Int(position.x, position.y + 1, position.z);
        if (CheckGrass(tilemap, nPos))
        {
            tileData.sprite = grassSprites[1];
        }
        else if(!CheckGrass(tilemap, nPos))
        {
            tileData.sprite = grassSprites[0];
        }
        tileData.colliderType = ColliderType.Sprite;
    }

    private bool CheckGrass(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
        //if true, it is a tile
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/GrassTile")]
    public static void CreateGrassTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Grass Tile", "New Grass Tile", "Asset", "Save Grass Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<ScriptableGrass>(), path);
    }
#endif
}
