using UnityEngine;

public class AtualizarHitboxSpawn : MonoBehaviour
{
    [SerializeField] private Transform walker; // Transform do Walker (personagem)
    [SerializeField] private GameObject hitbox; // Hitbox que será reposicionada
    [SerializeField] private float distancia = 1f; // Distância do ponto de ataque ao Walker
    [SerializeField] private Transform pontoAtaque; // Ponto de origem para a hitbox (centro do arco)
    [SerializeField] private OponenteCore alvo; // Alvo que o Walker está mirando (ex: jogador ou inimigo)

    void FixedUpdate()
    {
        if (walker == null || pontoAtaque == null || alvo == null) return;

        if (alvo.Alvo != null)
        {
            // Obtém a direção em relação ao alvo
            Vector2 direcao = (alvo.Alvo.position - walker.position).normalized;

            // Atualiza a posição do ponto de ataque em órbita ao redor do Walker
            Vector2 novaPosicao = (Vector2)walker.position + direcao * distancia;
            pontoAtaque.position = novaPosicao;

            // Calcula o ângulo da direção para o alvo
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

            // Ajusta o ângulo para alinhar o arco paralelamente ao alvo
            angulo += 90f;

            // Atualiza a rotação do ponto de ataque
            pontoAtaque.rotation = Quaternion.Euler(0f, 0f, angulo);

            // Atualiza a posição e rotação da hitbox com base no ponto de ataque
            hitbox.transform.position = pontoAtaque.position;
            hitbox.transform.rotation = pontoAtaque.rotation;
        }
    }
}