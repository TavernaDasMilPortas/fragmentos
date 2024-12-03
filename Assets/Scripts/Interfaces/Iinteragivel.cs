using UnityEngine;

public interface Iinteragivel
{
    // Método que define a interação do objeto
    void Interagir();

    // Propriedade para indicar se o objeto é o mais próximo
    bool EstaMaisProximo { get; set; }
    public Transform[] PontosPrebab { get; set; }
    public string TipoInteracao { get; set; }
    public bool EstaInteragindo { get; set; }

}
