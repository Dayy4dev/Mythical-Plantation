using UnityEngine;

public class SpriteTegak : MonoBehaviour
{
    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
