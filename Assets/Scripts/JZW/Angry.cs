using System.Collections;
using UnityEngine;

public class Angry : MonoBehaviour
{
    public float scaleAmount = 2f;
    public float rotationSpeed = 1f;
    public float duration = 2f;

    private Vector3 initialScale;
    private Coroutine currentCoroutine;

    private void Start()
    {
        initialScale = transform.localScale;
        transform.localScale = Vector3.zero;
        currentCoroutine = StartCoroutine(ScaleObject());
    }

    private IEnumerator ScaleObject()
    {
        // Scale up and rotate
        float t = 0f;
        Vector3 targetScale = initialScale * scaleAmount;
        while (t < duration)
        {
            t += Time.deltaTime;
            float normalizedTime = t / duration;
            transform.localScale = Vector3.Lerp(Vector3.zero, initialScale, normalizedTime);

            // Rotate object around Z axis
            transform.Rotate(0f, 0f, rotationSpeed);
            yield return null;
        }

        // Start looping scale
        while (true)
        {
            // Scale up
            t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                float normalizedTime = t / duration;
                transform.localScale = Vector3.Lerp(initialScale, targetScale, normalizedTime);
                yield return null;
            }

            // Scale down
            t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                float normalizedTime = t / duration;
                transform.localScale = Vector3.Lerp(targetScale, initialScale, normalizedTime);
                yield return null;
            }
        }
    }
}
