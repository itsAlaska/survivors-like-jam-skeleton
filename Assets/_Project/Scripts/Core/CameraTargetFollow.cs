using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector2 offset;

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 newPos = player.position + (Vector3)offset;
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
}