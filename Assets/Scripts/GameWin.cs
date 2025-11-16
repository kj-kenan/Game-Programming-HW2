using UnityEngine;

public class GameWin : MonoBehaviour
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

