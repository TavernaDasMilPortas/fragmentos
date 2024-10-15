using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float velocidadeMovimento;
    [SerializeField]
    private ManaControl mana;
    public bool andando;
    public Shockwave shockwavePrefab;
    [SerializeField]
    private Transform transform;
    public int swManaCost;
    void Start()
    {
        velocidadeMovimento = 0;
        andando = true;
        swManaCost = shockwavePrefab.manaCost;
    }

    // Update is called once per frame
    void Update()
    {
        Andar();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnShockwave();
        }
    }
    void Andar()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direcao = new Vector2(horizontal, vertical);
        direcao = direcao.normalized;
        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.D) == true)
        {
            andando = true;
            velocidadeMovimento = 2;
        }
        else
        {
            andando = false;
            velocidadeMovimento = 0;
        }
        this.rigidbody.velocity = direcao * velocidadeMovimento;

    }
    void SpawnShockwave()
    {
        if (mana.manaAtual - swManaCost >= 0)
        {
            Shockwave shockWave = Instantiate(shockwavePrefab, this.transform.position, Quaternion.identity);
            mana.GastarMana(shockWave.manaCost);
        }
        // Instantiate the shockwave at the player's position (or a specific point)


    }
    }


