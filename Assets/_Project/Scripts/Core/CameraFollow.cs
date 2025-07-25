using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 offset;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 newPos = target.position + (Vector3)offset;
        newPos.z = transform.position.z;

        transform.position = newPos;
    }
}