using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _offset;

    void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}
