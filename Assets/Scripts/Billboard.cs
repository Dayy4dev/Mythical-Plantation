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
        transform.forward = Camera.main.transform.forward;

        transform.localScale = originalScale;
    }
}
