using UnityEngine;

public class Interagir : MonoBehaviour
{
    [SerializeField] private float raioInteracao = 2f; // Raio para detectar objetos interag�veis
    [SerializeField] private LayerMask layerInteragivel; // Camada dos objetos interag�veis
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
        /*
        // Reverte o sprite do objeto anterior
        if (objetoMaisProximo != null && objetoMaisProximo != candidatoMaisProximo)
        {
            TrocarSprite(objetoMaisProximo, false); // Reverte para o sprite padr�o
        }*/

        // Atualiza o objeto mais pr�ximo
        objetoMaisProximo = candidatoMaisProximo;
        /*
        // Troca para o sprite selecionado do novo objeto
        if (objetoMaisProximo != null)
        {
            TrocarSprite(objetoMaisProximo, true);
        }
        */
    }

    private void TrocarSprite(Iinteragivel interagivel, bool selecionar)
    {
        if (interagivel == null) return;

        var monoBehaviour = interagivel as MonoBehaviour;
        if (monoBehaviour != null)
        {
            var spriteRenderer = monoBehaviour.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Salva o sprite padr�o caso ainda n�o tenha sido salvo
                if (interagivel.SpritePadrao == null)
                {
                    interagivel.SpritePadrao = spriteRenderer.sprite;
                }

                if (selecionar)
                {
                    // Define o sprite para o �ndice selecionado
                    int indice = interagivel.indiceSprite;
                    if (indice >= 0 && indice < interagivel.spritesSelecionaveis.Length)
                    {
                        spriteRenderer.sprite = interagivel.spritesSelecionaveis[indice];
                    }
                }
                else
                {
                    // Retorna ao sprite padr�o
                    spriteRenderer.sprite = interagivel.SpritePadrao;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualiza o raio de intera��o no editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioInteracao);
    }
}
