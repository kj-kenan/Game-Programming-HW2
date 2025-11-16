using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameOverHandler gameOverHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            gameOverHandler.ShowGameWin();
        }
    }
}
