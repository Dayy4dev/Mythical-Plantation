using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void LateUpdate()
    {
        // Selalu hadap kamera
        transform.forward = Camera.main.transform.forward;

        // Kunci skala biar tidak gepeng
        transform.localScale = originalScale;
    }
}
