
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    public float maxScale = 2f;  // Maximum size of the shockwave
    public float speed = 3f;     // Speed at which the shockwave expands
    public float duration = 5f;  // How long the shockwave lasts before disappearing
    public int manaCost = 7;
    private float timer = 0f;

    void Update()
    {
        // Expand the shockwave over time
        transform.localScale += Vector3.one * speed * Time.deltaTime;

        // Increment the timer
        timer += Time.deltaTime;

        // Destroy the shockwave after its duration
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}