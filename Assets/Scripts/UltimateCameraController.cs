using UnityEngine;

public class UltimateCameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 150f;

    public float distance = 6f;
    public float height = 3f;

    private float verticalRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
    }

    void LateUpdate()
    {
        Vector3 targetPos = player.position
                            - player.forward * distance
                            + Vector3.up * height;

        transform.position = targetPos;

        transform.rotation = Quaternion.Euler(verticalRotation, player.eulerAngles.y, 0f);
    }
}
