using UnityEngine;

public class KeyFollow : MonoBehaviour
{
    public Transform player;
    public Transform followTarget;
    public float followSpeed = 10f;
    public float pickupDistance = 2f;

    private Rigidbody rb;
    private Collider col;
    private bool isAttached = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        if (!isAttached && Input.GetKeyDown(KeyCode.F))
        {
            float dist = Vector3.Distance(transform.position, player.position);
            if (dist <= pickupDistance)
            {
                AttachToPlayer();
            }
        }

        if (isAttached && Input.GetKeyDown(KeyCode.G))
        {
            DetachFromPlayer();
        }

        if (isAttached)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                followTarget.position,
                followSpeed * Time.deltaTime
            );

            transform.rotation = followTarget.rotation;
        }
    }

    private void AttachToPlayer()
    {
        isAttached = true;

        rb.isKinematic = true;
        rb.useGravity = false;
        col.enabled = false;     

        transform.position = followTarget.position;
        transform.rotation = followTarget.rotation;
    }

    private void DetachFromPlayer()
    {
        isAttached = false;

        rb.isKinematic = false;
        rb.useGravity = true;
        col.enabled = true;

        transform.position += transform.forward * 0.3f;
    }
}
