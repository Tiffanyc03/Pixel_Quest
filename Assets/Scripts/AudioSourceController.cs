using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour
{
    public AudioMixer _mixer;

    // Objects 
    public GameObject coinSFX;
    public GameObject heartSFX;
    public GameObject deathSFX;
    public GameObject checkpointSFX;

    private void Start()
    {
        UpdateMusicGroup(PlayerPrefs.GetFloat(Structs.Mixers.musicVolume));
        UpdateSFXGroup(PlayerPrefs.GetFloat(Structs.Mixers.sfxVolume));
    }

    // Start Method 
    public void PlaySFX(string audioName){    StartCoroutine(CreateSFX(audioName));}

    // Creates, Plays and Destorys the SFX 
    public IEnumerator CreateSFX(string audioName)
    {
        // Creates the asked for SFX 
        GameObject newAudio = Instantiate(GetSFX(audioName), Vector3.zero, Quaternion.identity);
        if(newAudio == null) { yield break; }
        newAudio.GetComponent<AudioSource>().Play();
        // Waits till the audio is done playing then destorys it 
        while (newAudio.GetComponent<AudioSource>().isPlaying){ yield return null;}
        Destroy(newAudio);
    }

    // Retuns the asked for Audio Soruce Game Object 
    public GameObject GetSFX(string audioName)
    {
        switch (audioName) {
            case Structs.SoundEffects.coin:
                {
                    return coinSFX;
                }
            case Structs.SoundEffects.heart:
                {
                    return heartSFX;
                }
            case Structs.SoundEffects.death:
                {
                    return deathSFX;
                }
            case Structs.SoundEffects.checkpoint:
                {
                    return checkpointSFX;
                }
        }
        return null;

    }

    // Updates the SFX volume 
    public void UpdateSFXGroup(float newVolume){
        PlayerPrefs.SetFloat(Structs.Mixers.sfxVolume, newVolume);
        _mixer.SetFloat(Structs.Mixers.sfxVolume, Mathf.Log10(newVolume) * 20); }


    // Updates the Music volume 
    public void UpdateMusicGroup(float newVolume) {
        PlayerPrefs.SetFloat(Structs.Mixers.musicVolume, newVolume);
        _mixer.SetFloat(Structs.Mixers.musicVolume, Mathf.Log10(newVolume) * 20);}
}
