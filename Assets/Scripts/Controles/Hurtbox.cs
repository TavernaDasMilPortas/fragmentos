using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    [SerializeField] public GerenciarVida vida; // Referência ao script de vida

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hitbox"))
        {
            Debug.Log("Hitbox colidiu com Hurtbox!");

            var hitbox = other.GetComponent<Hitbox>();
            if (hitbox != null)
            {
                Debug.Log("A hitbox não está vazia!");
                vida.ReceberDano(hitbox.dano);
            }
        }
    }
}