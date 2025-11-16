using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float distance = 7f;
    public float height = 4f;
    public Vector3 offset;
    public float moveDamp = 8f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = target.position
                            - target.forward * distance
                            + Vector3.up * height
                            + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * moveDamp
        );

    }
}
