using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentoMomo : Fragmento
{
    public Teleporte teleportar;
    public ForceField campoForca;
    public PlayerCore player;

    public override void IniciarFragmento()
    {
        Nome = "Momo";
        Habilidade2 = teleportar;
        Habilidade3 = campoForca;
        disparo.tipo = DisparoProjetil.TipoProjetil.Temporal;
        VH1 = false;
        VH2 = false;
        VH3 = false;
        VA = false;
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
