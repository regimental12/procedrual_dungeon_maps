using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(TileMap))]
public class TileMapInspector : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(GUILayout.Button("Regenerate"))
        {
            TileMap tilemap = (TileMap)target;
            tilemap.buildMesh();
        }
    }
}
