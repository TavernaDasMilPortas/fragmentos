using UnityEngine;

public class ControleInventario : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] public GameObject[] excessoes;
 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            AlterarEstado();
        }
    }

    void AlterarEstado()
    {
        if (canvas.activeInHierarchy)
        {
            canvas.SetActive(false);
            pauseManager.Resume(); // Retomar o jogo
        }
        else
        {
            canvas.SetActive(true);
            pauseManager.PauseAllExcept(excessoes); // Pausar o jogo
        }
    }
}