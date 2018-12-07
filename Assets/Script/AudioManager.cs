using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Maneja el sonido de la scena.
/// </summary>
public class AudioManager : MonoBehaviour
{
	public AudioSource MusicSource;
    
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;
    public Sprite[] soundSprite;
    public bool mute;
    public GameObject buttonSound;
    public AudioSource[] au;

    public static AudioManager Instance = null;
	
	private void Awake()
	{

		if (Instance == null)
		{
			Instance = this;
		}

		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

    //Reproduce un audioClIP 
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}
    //Silencia el audio de todos los audio sources
    public void Mute()
    {

        if (mute)
        {
            buttonSound.GetComponent<Image>().sprite = soundSprite[0];
            for (int i = 0; i < au.Length; i++)
            {
                au[i].volume = 0.5f;
            }
        }
        else
        {
            buttonSound.GetComponent<Image>().sprite = soundSprite[1];
            for (int i = 0; i < au.Length; i++)
            {
                Debug.Log("b");
                au[i].volume = 0;
            }
            
        }
        if (mute)
        {
            mute = false;
        }
        else
        {
            mute = true;
        }

    }
}
