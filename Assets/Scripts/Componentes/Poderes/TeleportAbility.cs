using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    [SerializeField] ManaControl mana;
    public float teleportRange = 1f;  // Maximum teleport distance
    public float teleportCooldown = 2f;  // Cooldown in seconds
    private float lastTeleportTime;
    public int manaCost = 5;
    private Camera mainCamera;

    void Start()
    {
        // Get the camera (useful for mouse position)
        mainCamera = Camera.main;
        lastTeleportTime = -teleportCooldown; // Ensures you can teleport immediately at game start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastTeleportTime + teleportCooldown)
        {
            mana.GastarMana(manaCost);
            Teleport();
        }
    }

    void Teleport()
    {
        // Get the mouse position in world space
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction and distance between the player and the mouse position
        Vector2 direction = mousePosition - (Vector2)transform.position;

        // If the distance is greater than the teleportRange, clamp it
        if (direction.magnitude > teleportRange)
        {
            direction = direction.normalized * teleportRange;
        }

        // Update the player's position to the teleport target location
        transform.position = (Vector2)transform.position + direction;

        // Update the lastTeleportTime to start cooldown
        lastTeleportTime = Time.time;
    }
}