using UnityEngine;

public class SpriteTegak : MonoBehaviour
{
    void LateUpdate()
    {
        // Selalu hadap ke kamera
        transform.forward = Camera.main.transform.forward;
    }
}
