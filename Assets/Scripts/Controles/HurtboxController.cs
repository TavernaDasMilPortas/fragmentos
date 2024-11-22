using UnityEngine;

public class HurtboxController : MonoBehaviour
{
    [SerializeField] private GerenciarVida gerenciarVida; // Refer�ncia ao sistema de vida

    public void ReceberDano(int dano)
    {
        if (gerenciarVida != null)
        {
            gerenciarVida.ReceberDano(dano); // Aplica o dano ao sistema de vida
        }
    }
}