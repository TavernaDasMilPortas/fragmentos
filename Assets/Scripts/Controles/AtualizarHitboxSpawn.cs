using UnityEngine;

public class AtualizarHitboxSpawn : MonoBehaviour
{
    [SerializeField] private Transform hitboxSpawnPoint; // Ponto de spawn da hitbox
    [SerializeField] private Perseguir perseguidor; // Referência ao script Perseguir
    [SerializeField] private GameObject hitbox;
   
    void FixedUpdate()
    {
        if (perseguidor == null || hitboxSpawnPoint == null) return;

        Vector2 direcao = perseguidor.direcaoAtual;

        if (direcao != Vector2.zero)
        {
            if(!hitbox.activeInHierarchy)
            {
                // Atualiza a posição do HitboxSpawnPoint
                hitboxSpawnPoint.localPosition = direcao.normalized; // Ajuste a distância se necessário

                // Atualiza a rotação para alinhar com a direção
                float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
                hitboxSpawnPoint.rotation = Quaternion.Euler(0, 0, angulo);
                hitbox.transform.position = hitboxSpawnPoint.position;
            }

        }
    }
}