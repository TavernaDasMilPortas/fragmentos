using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashEffect : MonoBehaviour
{
    public Image flashImage; // Refer�ncia � imagem branca no Canvas
    public float flashDuration = 1f; // Dura��o total do clar�o
    private bool isFlashing = false;

    public void TriggerFlash()
    {
        if (!isFlashing)
            StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        isFlashing = true;
        float halfDuration = flashDuration / 2f;

        // Aumenta o Alpha at� o m�ximo
        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / halfDuration);
            flashImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        // Diminui o Alpha at� zero
        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / halfDuration);
            flashImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        // Garante que o Alpha fique em zero
        flashImage.color = new Color(1, 1, 1, 0);
        isFlashing = false;
    }
}