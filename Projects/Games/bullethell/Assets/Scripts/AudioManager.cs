using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip ShieldAudio;

    [SerializeField]
    private AudioClip PlayerBulletAudio;

    [SerializeField]
    private AudioClip PlayerLaserAbilityAudio;

    [SerializeField]
    private AudioClip EnemyBulletAudio;

    [SerializeField]
    private float ShieldAudioVolume = 1f;
    [SerializeField]

    private float PlayerBulletAudioVolume = 1f;
    [SerializeField]

    private float PlayerLaserAbilityAudioVolume = 1f;

    [SerializeField]
    private float EnemyBulletAudioVolume = 1f;

    // Start is called before the first frame update


    private void Start()
    {
        
    }

    public void PlayShieldAudio()
    {
        if (ShieldAudio)
        {
            AudioSource.PlayClipAtPoint(ShieldAudio, transform.position, ShieldAudioVolume);

        }
    }

    public void PlayPlayerBulletAudio() 
    {
        if (PlayerBulletAudio)
        {
            AudioSource.PlayClipAtPoint(PlayerBulletAudio, transform.position,PlayerBulletAudioVolume);

        }
    }
    public void PlayPlayerLaserAbilityAudio()
    {
        if (PlayerLaserAbilityAudio)
        {
            Debug.Log("laser"); 
            AudioSource.PlayClipAtPoint(PlayerLaserAbilityAudio, transform.position,PlayerLaserAbilityAudioVolume);

        }
    }

    public void PlayPlayerLaserAbilityAudio(float time)
    {
        if (PlayerLaserAbilityAudio)
        {
            GameObject tempGO = new GameObject("TempAudio"); // create the temp object
            tempGO.transform.position = transform.position; // set its position
            AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
            aSource.clip = PlayerLaserAbilityAudio; // define the clip
                                 // set other aSource properties here, if desired
            aSource.Play(); // start the sound
            Destroy(tempGO, time); // destroy object after clip duration
            

        }
    }

    public void PlayEnemyBulletAudio() 
    {
        if (EnemyBulletAudio)
        {
            AudioSource.PlayClipAtPoint(EnemyBulletAudio, transform.position,EnemyBulletAudioVolume);

        }
    }

}
