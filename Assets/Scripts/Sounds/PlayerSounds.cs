using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource soundsSource;
    public AudioSource levelMusic;
    public AudioClip deathSound;
    public AudioClip jumpSound;
    
    public void playDeathSound()
    {
        levelMusic.Stop();
        soundsSource.PlayOneShot(deathSound);
    }
    public void playJumpSound()
    { 
        soundsSource.PlayOneShot(jumpSound);
    }

}
