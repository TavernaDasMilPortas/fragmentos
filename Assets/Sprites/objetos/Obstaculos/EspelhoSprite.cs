using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspelhoSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] spritesConstrucao;
    [SerializeField] private Sprite spriteInicial;
    [SerializeField] private EspelhoQuebrado espelho;
    [SerializeField] private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer.sprite = spriteInicial;
    }

    // Update is called once per frame
    public void AtualizarSprite()
    {
        spriteRenderer.sprite = spritesConstrucao[espelho.fragmentosNoEspelho - 1];

    }
}
