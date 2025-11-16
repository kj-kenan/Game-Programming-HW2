using UnityEngine;

public class SwingTrap : MonoBehaviour
{
    public float swingAngle = 60f;
    public float speed = 2f;

    private float angle = 0f;
    private bool forward = true;

    private Quaternion startRot; // baþlangýç rotasyonu

    void Start()
    {
        // Oyun baþlarken sahnedeki rotasyonu kaydet
        startRot = transform.localRotation;
    }

    void Update()
    {
        // Sallanma yönüne göre açýyý artýr/azalt
        if (forward)
        {
            angle += speed * Time.deltaTime;
        }
        else
        {
            angle -= speed * Time.deltaTime;
        }

        // Limitlere geldiðinde yön deðiþtir
        if (angle > swingAngle)
        {
            forward = false;
        }
        else if (angle < -swingAngle)
        {
            forward = true;
        }

        // Baþlangýç rotasyonunun ÜSTÜNE sallanma açýsý ekle
        transform.localRotation = startRot * Quaternion.Euler(0, 0, angle);
    }
}
