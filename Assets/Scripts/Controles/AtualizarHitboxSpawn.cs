using UnityEngine;

public class AtualizarHitboxSpawn : MonoBehaviour
{
    [SerializeField] private Transform walker; // Transform do Walker (personagem)
    [SerializeField] private GameObject hitbox; // Hitbox que ser� reposicionada
    [SerializeField] private float distancia = 1f; // Dist�ncia do ponto de ataque ao Walker
    [SerializeField] private Transform pontoAtaque; // Ponto de origem para a hitbox (centro do arco)
    [SerializeField] private OponenteCore alvo; // Alvo que o Walker est� mirando (ex: jogador ou inimigo)

    void FixedUpdate()
    {
        if (walker == null || pontoAtaque == null || alvo == null) return;

        if (alvo.Alvo != null)
        {
            // Obt�m a dire��o em rela��o ao alvo
            Vector2 direcao = (alvo.Alvo.position - walker.position).normalized;

            // Atualiza a posi��o do ponto de ataque em �rbita ao redor do Walker
            Vector2 novaPosicao = (Vector2)walker.position + direcao * distancia;
            pontoAtaque.position = novaPosicao;

            // Calcula o �ngulo da dire��o para o alvo
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

            // Ajusta o �ngulo para alinhar o arco paralelamente ao alvo
            angulo += 90f;

            // Atualiza a rota��o do ponto de ataque
            pontoAtaque.rotation = Quaternion.Euler(0f, 0f, angulo);

            // Atualiza a posi��o e rota��o da hitbox com base no ponto de ataque
            hitbox.transform.position = pontoAtaque.position;
            hitbox.transform.rotation = pontoAtaque.rotation;
        }
    }
}