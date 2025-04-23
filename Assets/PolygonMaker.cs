using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(MeshFilter), typeof(MeshRenderer))]
public class PolygonMaker : MonoBehaviour
{
    [SerializeField] Vector3[] vertices;
    [SerializeField] float lineWidth = 0.1f; // LineRenderer�̑����𒲐�����t�B�[���h
    [SerializeField] Color lineColor = Color.white; // LineRenderer�̐F�𒲐�����t�B�[���h

    private LineRenderer lineRenderer;
    private MeshFilter meshFilter;

    void Start()
    {
        if (vertices == null || vertices.Length < 3)
        {
            Debug.LogError("���p�`��`�悷��ɂ͏��Ȃ��Ƃ�3�̒��_���K�v�ł��B");
            return;
        }

        // LineRenderer�̐ݒ�
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = vertices.Length + 1; // �n�_���I�_�Ƃ��Ēǉ�
        lineRenderer.loop = false;

        // �}�e���A����ݒ�
        Material lineMaterial = new Material(Shader.Find("Sprites/Default")); // �F�𔽉f����V�F�[�_�[
        lineRenderer.material = lineMaterial;

        // LineRenderer�̑�����ݒ�
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        // LineRenderer�̐F��ݒ�
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        // LineRenderer�̒��_��ݒ�
        for (int i = 0; i < vertices.Length; i++)
        {
            lineRenderer.SetPosition(i, transform.TransformPoint(vertices[i])); // ���[�J�����W�����[���h���W�ɕϊ�
        }
        lineRenderer.SetPosition(vertices.Length, transform.TransformPoint(vertices[0])); // �n�_���I�_�Ƃ��Ēǉ�

        // Mesh�̍\�z
        meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        // ���_��ݒ�
        Vector3[] meshVertices = new Vector3[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            meshVertices[i] = vertices[i]; // ���[�J�����W�̂܂܎g�p
        }
        mesh.vertices = meshVertices;

        // �O�p�`�C���f�b�N�X��ݒ�
        int[] triangles = new int[(vertices.Length - 2) * 3];
        for (int i = 0; i < vertices.Length - 2; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }
        mesh.triangles = triangles;

        // UV��ݒ�i�K�v�ɉ����āj
        Vector2[] uv = new Vector2[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            uv[i] = new Vector2(vertices[i].x, vertices[i].z);
        }
        mesh.uv = uv;

        // ���b�V����K�p
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        meshFilter.mesh = mesh;
    }
}
