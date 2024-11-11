using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragmento : MonoBehaviour
{
    public string Nome;
    public IHabilidade Habilidade1;
    public IHabilidade Habilidade2;
    public IHabilidade Habilidade3;
    public DisparoProjetil disparo;
    public virtual void IniciarFragmento(){}
    public virtual void AtivarHabilidade1(){}
    public virtual void AtivarHabilidade2(){}
    public virtual void AtivarHabilidade3(){}
    public  virtual void Disparar(){}
}
