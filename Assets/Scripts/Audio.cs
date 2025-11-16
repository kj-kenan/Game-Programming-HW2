using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isMuted = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMuted = !isMuted;
            audioSource.mute = isMuted;
        }
    }
}
