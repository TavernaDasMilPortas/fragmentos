using UnityEngine;
using System.Collections.Generic;
public class HitboxController : MonoBehaviour
{
    [SerializeField] public Hitbox hitbox;
    [SerializeField] public GameObject hitboxObject;
    public void AtivarHitbox()
    {
        hitbox.alvosAtingidos.Clear(); // Reseta a lista de alvos atingidos ao ativar a hitbox
        hitboxObject.SetActive(true); // Ativa a hitbox
    }

    public void DesativarHitbox()
    {
        hitboxObject.SetActive(false); // Desativa a hitbox
    }
}