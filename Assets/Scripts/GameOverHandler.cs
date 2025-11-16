using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public AudioClip tigerHitSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            ShowGameOver();
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            PlayTigerSound();
            ShowGameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            ShowGameOver();
        }

        if (other.CompareTag("Enemy"))
        {
            PlayTigerSound();
            ShowGameOver();
        }
    }

    public void ShowGameWin()
    {
        if (gameWinUI != null)
            gameWinUI.SetActive(true);

        Time.timeScale = 0f;
    }

    private void PlayTigerSound()
    {
        if (tigerHitSound != null && audioSource != null)
            audioSource.PlayOneShot(tigerHitSound);
    }

    private void ShowGameOver()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Update()
    {
        if (transform.position.y < -40f)
            ShowGameOver();
    }

}
