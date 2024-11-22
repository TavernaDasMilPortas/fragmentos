using System.Collections;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public ValorDano dano; // Representa o valor de dano do projétil
    public string tipo = null; // Tipo de dano do projétil (ex.: "Temporal")
    private OponenteCore oponente; // Referência ao oponente atingido
    private Collider2D meuColisor; // Colisor deste projétil
    [SerializeField] private Collider2D colisorIgnorado; // Colisor a ser ignorado pelo projétil
    [SerializeField] private Transform objetoPai; // Objeto que o projétil se tornará filho após a colisão

    void Start()
    {
        meuColisor = GetComponent<Collider2D>();

        if (meuColisor != null && colisorIgnorado != null)
        {
            Physics2D.IgnoreCollision(meuColisor, colisorIgnorado);
        }
        else if (colisorIgnorado == null)
        {
            Debug.LogWarning("Colisor ignorado não configurado no projétil.");
        }
    }

    // Inicializa o projétil com o dano, tipo e colisor a ser ignorado
    public void Inicializar(int dano, string tipo = null, Collider2D colisorIgnorado = null, Transform objetoPai = null)
    {
        this.dano.valorDano = dano;
        this.tipo = tipo;
        this.colisorIgnorado = colisorIgnorado;
        this.objetoPai = objetoPai;

        // Ignora a colisão dinamicamente
        if (meuColisor != null && this.colisorIgnorado != null)
        {
            Physics2D.IgnoreCollision(meuColisor, this.colisorIgnorado);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject raiz = collision.gameObject.transform.root.gameObject;

        // Se o projétil tiver um objeto pai configurado, faz com que o projétil se torne filho deste objeto
        if (objetoPai != null)
        {
            transform.SetParent(objetoPai);
            Debug.Log("Projétil agora é filho do objeto: " + objetoPai.name);
        }

        // Aplica efeitos apenas se o tipo de dano estiver definido
        if (tipo != null)
        {
            // Verifica se o objeto colidido é um oponente e se é um trigger
            if (raiz.CompareTag("Oponente") && collision.isTrigger)
            {
                // Tenta obter o componente OponenteCore do objeto atingido
                oponente = raiz.GetComponent<OponenteCore>();

                if (oponente != null)
                {
                    // Aplica o efeito dependendo do tipo
                    switch (tipo)
                    {
                        case "Temporal":
                            EfeitoTemporal();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        // Destroi o projétil ao colidir
        Destroy(gameObject);
    }

    // Efeito específico do tipo de dano "Temporal"
    void EfeitoTemporal()
    {
        if (oponente.Velocidade >= 0)
        {
            oponente.Velocidade -= 0.2f;
        }
    }
}