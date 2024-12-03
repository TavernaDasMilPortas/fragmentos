using UnityEngine;

public interface Iinteragivel
{
    // M�todo que define a intera��o do objeto
    void Interagir();

    // Propriedade para indicar se o objeto � o mais pr�ximo
    bool EstaMaisProximo { get; set; }
    public Transform[] PontosPrebab { get; set; }
    public string TipoInteracao { get; set; }
    public bool EstaInteragindo { get; set; }

}
