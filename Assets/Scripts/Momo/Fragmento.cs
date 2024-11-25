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
    public bool VH1;
    public bool VH2;
    public bool VH3;
    public bool VA;
    public virtual void IniciarFragmento(){}
    public virtual void AtivarHabilidade1(){}
    public virtual void AtivarHabilidade2(){}
    public virtual void AtivarHabilidade3(){}
    public  virtual void Disparar(){}
}
