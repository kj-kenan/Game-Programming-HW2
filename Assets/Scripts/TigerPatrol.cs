using System.Collections;
using UnityEngine;

public class TigerPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;

    private Vector3 startPos;
    private Animator anim;

    void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();

        StartCoroutine(PatrolRoutine());
    }

    IEnumerator PatrolRoutine()
    {
        while (true)
        {
            yield return MoveForwardRoutine();
            yield return MoveBackwardRoutine();
        }
    }

    IEnumerator MoveForwardRoutine()
    {
        anim.SetFloat("Vert", 1f);
        anim.SetFloat("State", 0.5f);

        while (Vector3.Distance(startPos, transform.position) < moveDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            yield return null;
        }

        transform.Rotate(0f, 180f, 0f);
    }

    IEnumerator MoveBackwardRoutine()
    {
        anim.SetFloat("Vert", 1f);
        anim.SetFloat("State", 0.5f);

        while (Vector3.Distance(startPos, transform.position) > 0.1f)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            yield return null;
        }

        transform.Rotate(0f, 180f, 0f);
    }
}
