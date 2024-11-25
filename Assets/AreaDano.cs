using System.Collections;
using UnityEngine;

public class AreaDano : MonoBehaviour
{
    [SerializeField] private float tempoParaDestruir = 5f; // Tempo em segundos para o objeto ser destruído automaticamente.
    [SerializeField] private GameObject pai;
    private void Start()
    {
        GameObject area = this.gameObject;
        area.transform.SetParent(pai.transform);
        // Inicia a contagem regressiva para destruir o objeto.
        StartCoroutine(DestruirAposTempo());
    } 

    private IEnumerator DestruirAposTempo()
    {
        // Aguarda o tempo definido antes de destruir o objeto.
        yield return new WaitForSeconds(tempoParaDestruir);
        Destroy(this.gameObject);
    }

    public void Inicializar(GameObject pai)
    {
        this.pai = pai;

    }
}