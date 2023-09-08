using UnityEngine;
using UnityEditor;

public class ReverseNormals : MonoBehaviour
{
    [MenuItem("Tools/Reverse Normals")]
    public static void Reverse()
    {
        GameObject selectedObject = Selection.activeGameObject;
        if (selectedObject != null)
        {
            MeshFilter meshFilter = selectedObject.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                Mesh mesh = meshFilter.sharedMesh;
                Vector3[] normals = mesh.normals;

                for (int i = 0; i < normals.Length; i++)
                {
                    normals[i] = -normals[i];
                }
                mesh.normals = normals;

                for (int i = 0; i < mesh.subMeshCount; i++)
                {
                    int[] triangles = mesh.GetTriangles(i);
                    for (int j = 0; j < triangles.Length; j += 3)
                    {
                        int temp = triangles[j];
                        triangles[j] = triangles[j + 1];
                        triangles[j + 1] = temp;
                    }
                    mesh.SetTriangles(triangles, i);
                }

                EditorUtility.SetDirty(mesh);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }
}
