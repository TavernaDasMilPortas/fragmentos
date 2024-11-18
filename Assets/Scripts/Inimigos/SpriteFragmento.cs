using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFragmento : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    public int indice;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer.sprite = sprites[indice];
    }


}
