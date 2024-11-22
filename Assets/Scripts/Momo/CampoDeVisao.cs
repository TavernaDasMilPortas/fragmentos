using UnityEngine;

public class CampoDeVisao : MonoBehaviour
{
    public float raioVisao = 5f; // Alcance da visão
    public int resolucao = 360; // Número de raios disparados
    public LayerMask camadaObstaculos; // Paredes e portas

    private Mesh malhaDeVisao;

    void Start()
    {
        malhaDeVisao = new Mesh();
        GetComponent<MeshFilter>().mesh = malhaDeVisao;
    }

    void LateUpdate()
    {
        AtualizarVisao();
    }

    void AtualizarVisao()
    {
        Vector3[] vertices = new Vector3[resolucao + 1];
        int[] triangulos = new int[resolucao * 3];

        vertices[0] = Vector3.zero;

        float anguloAtual = 0;
        float passoAngulo = 360f / resolucao;

        for (int i = 0; i < resolucao; i++)
        {
            Vector3 direcao = DirecaoDoAngulo(anguloAtual);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direcao, raioVisao, camadaObstaculos);

            if (hit.collider == null)
            {
                vertices[i + 1] = direcao * raioVisao;
            }
            else
            {
                vertices[i + 1] = transform.InverseTransformPoint(hit.point);
            }

            if (i < resolucao)
            {
                int verticeIndex = i + 1;
                triangulos[i * 3] = 0;
                triangulos[i * 3 + 1] = verticeIndex;
                triangulos[i * 3 + 2] = verticeIndex + 1;
            }

            anguloAtual -= passoAngulo;
        }

        malhaDeVisao.Clear();
        malhaDeVisao.vertices = vertices;
        malhaDeVisao.triangles = triangulos;
        malhaDeVisao.RecalculateNormals();
    }

    Vector3 DirecaoDoAngulo(float angulo)
    {
        float rad = angulo * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
    }
}
