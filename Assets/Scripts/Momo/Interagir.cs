using UnityEngine;

public class Interagir : MonoBehaviour
{
    [SerializeField] private float raioInteracao = 2f; // Raio para detectar objetos interagíveis
    [SerializeField] private LayerMask layerInteragivel; // Camada dos objetos interagíveis
    public Iinteragivel objetoMaisProximo;

    public void DetectarERealcarObjetoMaisProximo()
    {
        Collider2D[] objetosInteragiveis = Physics2D.OverlapCircleAll(transform.position, raioInteracao, layerInteragivel);

        float menorDistancia = Mathf.Infinity;
        Iinteragivel candidatoMaisProximo = null;

        foreach (var obj in objetosInteragiveis)
        {
            var interagivel = obj.GetComponent<Iinteragivel>();
            if (interagivel != null)
            {
                float distancia = Vector2.Distance(transform.position, obj.transform.position);
                if (distancia < menorDistancia)
                {
                    menorDistancia = distancia;
                    candidatoMaisProximo = interagivel;
                }
            }
        }

        // Remove o destaque do objeto anterior
        if (objetoMaisProximo != null && objetoMaisProximo != candidatoMaisProximo)
        {
            AlterarOutline(objetoMaisProximo as MonoBehaviour, 0.0f); // Remove a borda
        }

        // Adiciona destaque ao novo objeto mais próximo
        objetoMaisProximo = candidatoMaisProximo;
        if (objetoMaisProximo != null)
        {
            // Ajuste o tamanho da borda com base na escala do objeto
            float outlineSize = 2.0f ; // Ajuste o valor conforme necessário
            AlterarOutline(objetoMaisProximo as MonoBehaviour, outlineSize); // Ativa a borda
        }
    }

    private void AlterarOutline(MonoBehaviour objeto, float outlineSize)
    {
        if (objeto == null) return;

        var spriteRenderer = objeto.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Garantir que o material não seja compartilhado
            if (!spriteRenderer.material.name.EndsWith("(Instance)"))
            {
                // Instancia o material para garantir que ele seja único para o objeto
                spriteRenderer.material = new Material(spriteRenderer.material);
            }

            // Define os valores do shader com precisão
            spriteRenderer.material.SetFloat("_OutlineSize", outlineSize);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualiza o raio de interação no editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioInteracao);
    }
}
