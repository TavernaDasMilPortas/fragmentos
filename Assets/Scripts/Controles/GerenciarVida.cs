using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GerenciarVida : MonoBehaviour
{
    [SerializeField]
    public int vidaMax;
    public int vidaAtual;
    public int vidaAnterior;
    public SpriteRenderer spriteRenderer;
    public Image imagem;
    // Start is called before the first frame update

    private void Start()
    {
        if (imagem != null)
        {
            imagem.gameObject.SetActive(false);
        }
        
    }
    void Update()
    {
        Morrer();
        if (this.transform.CompareTag("Player"))
        {
            if (vidaAtual <= 0 && imagem.enabled)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

    }
    public void Morrer()
    {
        if (vidaAtual <= 0)
        {
            if (CompareTag("Player"))
            {
                imagem.gameObject.SetActive(true);
                Debug.Log("Momo morreu");
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }

    // Update is called once per frame
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if (this.CompareTag("Oponente"))
         {
             ValorDano dano = collision.gameObject.GetComponent<ValorDano>();
             if (dano != null)
             {
                 if (vidaAtual - dano.valorDano > 0)
                 {
                     vidaAtual -= dano.valorDano;
                 }
                 else
                 {
                     vidaAtual = 0;
                 }

             }

         }
         ValorCura cura = collision.gameObject.GetComponent<ValorCura>();
         if (cura!=null)
         {
             if (vidaAtual + cura.valorCura < vidaMax)
             {
                vidaAtual += cura.valorCura;
             }
             else
             {
                 vidaAtual = vidaMax;
             }

         }
     }
    */
    public IEnumerator FeedbackDano() 
    { 
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    
    }
    public bool ConferirMudancaVida(int vAtual, int vAnterior)
    {
        if (vAtual != vAnterior)
        {
            if (vAtual < vidaAnterior)
            {
                StartCoroutine(FeedbackDano());
            }
            vidaAnterior = vAtual;

            return true;
        }
        else
        {
            return false;
        }
    }

    public void ReceberDano(int dano)
    {
        if (this.vidaAtual - dano > 0)
        {
            this.vidaAtual -= dano;
        }
        else
        {
            this.vidaAtual = 0;
        }
    }

  
     
}
