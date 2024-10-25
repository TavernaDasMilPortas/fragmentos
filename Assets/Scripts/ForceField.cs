using UnityEngine;

public class ForceField : MonoBehaviour
{
   
    [SerializeField] ManaControl mana;
    public GameObject forceFieldObject;  // The visual object for the force field
    private float timer = 0f;
    public float intervaloMana = 0.5f;
    public int manaCost;
    void Start()
    {
        // Ensure the force field starts inactive
        if (forceFieldObject != null)
        {
            forceFieldObject.SetActive(false);
        }
        manaCost = 1;
    }

    void Update()
    {
        // Check if 'E' key is held down
        if (Input.GetKey(KeyCode.Mouse1) && mana.manaAtual > 0)
        {
            timer += Time.deltaTime;
            if (timer >= intervaloMana)
            {
                mana.GastarMana(manaCost);
                timer = 0f;
            }
            ActivateForceField();
            
}
        else
        {
            DeactivateForceField();
        }
    }

    void ActivateForceField()
    {
        // Enable the force field visual if it's not already active
        if (forceFieldObject != null && !forceFieldObject.activeInHierarchy)
        {
            
            forceFieldObject.SetActive(true);
            Debug.Log("Force field activated!");
        }
    }

    void DeactivateForceField()
    {
        // Disable the force field visual if it's currently active
        if (forceFieldObject != null && forceFieldObject.activeInHierarchy)
        {
            forceFieldObject.SetActive(false);
            Debug.Log("Force field deactivated!");
        }
    }
}