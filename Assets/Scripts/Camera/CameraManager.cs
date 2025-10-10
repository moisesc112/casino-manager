using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform _cameraHolder;

    void Update()
    {
        transform.position = _cameraHolder.position;
    }
}
