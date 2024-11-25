using UnityEngine;

public class TiroCarregado : MonoBehaviour
{
    [SerializeField] private DisparoOponente disparo; // Referência ao disparo
    [SerializeField] private OponenteCore core; // Referência ao OponenteCore
    [SerializeField] private float danoCarregadoMultiplier = 2f; // Multiplicador de dano do tiro carregado
    [SerializeField] ValorDano dano;
    public void RealizarTiroCarregado()
    {
        // Aplica o dano carregado ao disparar
        int danoCarregado = Mathf.RoundToInt(dano.valorDano * danoCarregadoMultiplier);
        disparo.Disparar(danoCarregado, DisparoProjetil.TipoProjetil.Fisico);
    }
}
