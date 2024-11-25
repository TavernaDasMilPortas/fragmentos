using System.Collections;
using UnityEngine;

public class EspelhoQuebrado : MonoBehaviour, Iinteragivel
{
    [SerializeField] private ItemCore itemCore; // Refer�ncia ao ItemCore a ser verificado no invent�rio
    [SerializeField] private Inventory inventario; // Refer�ncia ao invent�rio
    [SerializeField] private Transform spawnLocation; // Local de spawn do prefab
    [SerializeField] private Camera mainCamera; // Refer�ncia � c�mera principal
    [SerializeField] private Transform player; // Transform do jogador para voltar a c�mera
    [SerializeField] private float cameraTransitionDuration = 2f; // Dura��o da transi��o da c�mera
    [SerializeField] private EspelhoSprite sprite;
    [SerializeField] private MonoBehaviour camera;
    [SerializeField] private GameObject boss;
    [SerializeField] private ScriptUtility desligar;
    [SerializeField] private EventoQuandoJogadorAbaixo ligarlutaBoss;
    public int fragmentosNoEspelho = 0;
    private const int maxFragmentos = 6;

    void Start()
    {
        desligar.SetScriptsActive(boss, false);
        boss.SetActive(false);
    }


    public void Interagir()
    {
        // Verifica se o item cacoEspelho existe no invent�rio e se tem quantidade suficiente
        InventorySlot slotDoCaco = inventario.EncontrarItemPorNome(itemCore);

        if (slotDoCaco == null || slotDoCaco.item == null || slotDoCaco.item.quantidade <= 0)
        {
            Debug.Log("Nenhum caco de espelho encontrado ou a quantidade � insuficiente.");
            return;
        }

        // Zera a quantidade e remove o item do slot
        Debug.Log($"Item {itemCore.name} encontrado. Adicionando fragmentos ao espelho...");
        int quantidadadeAtual = slotDoCaco.item.quantidade;

        // Reduz 1 caco, aumenta em 1 os cacos do espelho e altera a o sprite do espelho
        for (int i = 0; i < quantidadadeAtual; i++)  // Corrigido o loop para adicionar fragmentos corretamente
        {
            inventario.AtualizarQuantidadeOuRemover(slotDoCaco, -1);
            fragmentosNoEspelho++;
            sprite.AtualizarSprite();
        }

        Debug.Log($"Fragmentos no espelho: {fragmentosNoEspelho}/{maxFragmentos}");

        // Verifica se todos os fragmentos foram adicionados
        if (fragmentosNoEspelho >= maxFragmentos)
        {
            Debug.Log("Todos os fragmentos foram adicionados. Spawnando o prefab...");
            StartCoroutine(SpawnPrefabETransitarCamera());
        }
    }

    private IEnumerator SpawnPrefabETransitarCamera()
    {
        
        // Transi��o da c�mera para o local de spawn
        camera.enabled = false;
       

        Vector3 initialPosition = mainCamera.transform.position;
        Vector3 targetPosition = new Vector3(spawnLocation.position.x, spawnLocation.position.y, mainCamera.transform.position.z);

        float elapsedTime = 0f;
        while (elapsedTime < cameraTransitionDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / cameraTransitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        boss.SetActive(true);
        desligar.SetScriptsActive(boss, true);
        mainCamera.transform.position = targetPosition;

        // Spawna o prefab
       

        // Espera um pouco antes de retornar ao jogador
        yield return new WaitForSeconds(2f);

        // Retorna a c�mera para o jogador
        elapsedTime = 0f;
        while (elapsedTime < cameraTransitionDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(targetPosition, new Vector3(player.position.x, player.position.y, mainCamera.transform.position.z), elapsedTime / cameraTransitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = new Vector3(player.position.x, player.position.y, mainCamera.transform.position.z);
        camera.enabled = true;
        ligarlutaBoss.enabled = true;

    }
}