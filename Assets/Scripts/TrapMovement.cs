using UnityEngine;

public class TrapMovement : MonoBehaviour
{
    public float speed = 2f;             // Hareket hýzý
    public float moveDistance = 2f;      // Yukarý–aþaðý mesafe

    private Vector3 startPos;
    private bool goingUp = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (goingUp)
        {
            transform.position += Vector3.up * step;

            if (Vector3.Distance(startPos, transform.position) >= moveDistance)
                goingUp = false;
        }
        else
        {
            transform.position -= Vector3.up * step;

            if (Vector3.Distance(startPos, transform.position) <= 0.1f)
                goingUp = true;
        }
    }
}
