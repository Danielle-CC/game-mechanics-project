using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player (or target object)
    public Vector3 offset; // Offset between the camera and the player

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
