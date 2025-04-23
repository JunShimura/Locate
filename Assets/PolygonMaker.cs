using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(MeshFilter), typeof(MeshRenderer))]
public class PolygonMaker : MonoBehaviour
{
    [SerializeField] Vector3[] vertices;
    [SerializeField] float lineWidth = 0.1f; // LineRendererの太さを調整するフィールド
    [SerializeField] Color lineColor = Color.white; // LineRendererの色を調整するフィールド

    private LineRenderer lineRenderer;
    private MeshFilter meshFilter;

    void Start()
    {
        if (vertices == null || vertices.Length < 3)
        {
            Debug.LogError("多角形を描画するには少なくとも3つの頂点が必要です。");
            return;
        }

        // LineRendererの設定
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = vertices.Length + 1; // 始点を終点として追加
        lineRenderer.loop = false;

        // マテリアルを設定
        Material lineMaterial = new Material(Shader.Find("Sprites/Default")); // 色を反映するシェーダー
        lineRenderer.material = lineMaterial;

        // LineRendererの太さを設定
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        // LineRendererの色を設定
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        // LineRendererの頂点を設定
        for (int i = 0; i < vertices.Length; i++)
        {
            lineRenderer.SetPosition(i, transform.TransformPoint(vertices[i])); // ローカル座標をワールド座標に変換
        }
        lineRenderer.SetPosition(vertices.Length, transform.TransformPoint(vertices[0])); // 始点を終点として追加

        // Meshの構築
        meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        // 頂点を設定
        Vector3[] meshVertices = new Vector3[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            meshVertices[i] = vertices[i]; // ローカル座標のまま使用
        }
        mesh.vertices = meshVertices;

        // 三角形インデックスを設定
        int[] triangles = new int[(vertices.Length - 2) * 3];
        for (int i = 0; i < vertices.Length - 2; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }
        mesh.triangles = triangles;

        // UVを設定（必要に応じて）
        Vector2[] uv = new Vector2[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            uv[i] = new Vector2(vertices[i].x, vertices[i].z);
        }
        mesh.uv = uv;

        // メッシュを適用
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        meshFilter.mesh = mesh;
    }
}
