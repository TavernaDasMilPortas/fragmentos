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
        disparo.tipo = "Temporal";
    }
    public override void AtivarHabilidade1()
    {
    
    }
    public override void AtivarHabilidade2()
    {
        Habilidade2.UsarHabilidade();
    }
    public override void AtivarHabilidade3()
    {
        Habilidade3.UsarHabilidade();
    }
    public override void Disparar()
    {
       disparo.Disparar(player.DanoDisparo, disparo.tipo);
    }

  
}
