using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        var desiredPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}