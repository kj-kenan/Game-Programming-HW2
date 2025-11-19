using UnityEngine;

public class SwingTrap : MonoBehaviour
{
    public float swingAngle = 60f;
    public float speed = 2f;

    private float angle = 0f;
    private bool forward = true;

    private Quaternion startRot; 

    void Start()
    {
        startRot = transform.localRotation;
    }

    void Update()
    {

        if (forward)
        {
            angle += speed * Time.deltaTime;
        }
        else
        {
            angle -= speed * Time.deltaTime;
        }

        if (angle > swingAngle)
        {
            forward = false;
        }
        else if (angle < -swingAngle)
        {
            forward = true;
        }

        transform.localRotation = startRot * Quaternion.Euler(0, 0, angle);
    }
}
