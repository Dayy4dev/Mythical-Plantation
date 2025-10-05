using UnityEngine;

public class Sprite2Tegak : MonoBehaviour
{
    void LateUpdate()
    {
        // Selalu hadap ke kamera, tapi hanya di sumbu Y
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0f; // biar tidak ikut miring ke atas/bawah
        transform.forward = camForward.normalized;
    }
}
