using UnityEngine;

public class RustKey : MonoBehaviour
{
    public Transform holdPoint;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return; // 2. kez tetiklenmesin

        if (other.CompareTag("Player"))
        {
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                pm.haveKey = true;
            }

            collected = true;

            transform.SetParent(holdPoint);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            if (TryGetComponent<Rigidbody>(out var rb))
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }
    }
}
