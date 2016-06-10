using UnityEngine;


public class PlaySound : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioClip sound;
    public AudioSource soundSource;
    
    public void playSound(bool stopMusic)
    {
        if(stopMusic == true)
        {
            levelMusic.Stop();
        }
        soundSource.PlayOneShot(sound);
    }

}
