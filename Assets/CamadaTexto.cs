using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamadaTexto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Configurar a camada de renderização
        var meshRenderer = GetComponent<MeshRenderer>();  // Defina o nome da camada
        meshRenderer.sortingOrder = 10;  // Valor alto para exibir na frente
    }

}
