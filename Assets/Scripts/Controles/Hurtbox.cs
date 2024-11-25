using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public GameObject owner; // O dono da hurtbox
    [SerializeField] public GerenciarVida vida; // Refer�ncia ao script de vida

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hitbox"))
        {
            var hitbox = other.GetComponent<Hitbox>();
            if (hitbox != null && hitbox.owner != null)
            {
                // Garante que o hitbox e o hurtbox n�o s�o do mesmo grupo
                bool sameGroup = owner.CompareTag("Player") == hitbox.owner.CompareTag("Player");
                if (sameGroup)
                {
                    // Ignora colis�o entre aliados
                    return;
                }

                //Debug.Log($"[Hurtbox] Recebendo {hitbox.dano.valorDano} de dano de: {hitbox.owner.name}");
                //vida.ReceberDano(hitbox.dano.valorDano);
            }
        }
    }


}