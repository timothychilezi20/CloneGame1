using System.Collections;
using UnityEngine;

public class SpriteFlashEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float flashDuration = 0.1f;
    public int flashCount = 3;
    public Color flashColor = Color.red;

    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(DoFlash());
    }

    private IEnumerator DoFlash()
    {
        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }
    }
}
