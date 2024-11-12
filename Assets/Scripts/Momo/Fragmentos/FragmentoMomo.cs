using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentoMomo : Fragmento
{
    public Teleporte teleportar;
    public ForceField campoForca;
    public PlayerCore player;
    private bool VH1 = false;
    private bool VH2 = false;
    private bool VH3 = false;
    private bool VA = false;
    public override void IniciarFragmento()
    {
        Nome = "Momo";
        Habilidade2 = teleportar;
        VH2 = true;
        Habilidade3 = campoForca;
        disparo.tipo = "Temporal";
        VA = true;
    }
    public override void AtivarHabilidade1()
    {
        if (VH1)
        {
            Habilidade1.UsarHabilidade();
        }
    }
    public override void AtivarHabilidade2()
    {
        if (VH2)
        {
            Habilidade2.UsarHabilidade();
        }
    }
    public override void AtivarHabilidade3()
    {
        if (VH3)
        {
            Habilidade3.UsarHabilidade();
        }
    }
    public override void Disparar()
    {
        if (VA)
        {
            disparo.Disparar(player.DanoDisparo, disparo.tipo);
        }
  
    }

  
}
