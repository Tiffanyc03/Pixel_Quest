using UnityEngine;

public class SoundEffectDeath : MonoBehaviour {
    
    // =================================================================================================================
    // VARIABLES 
    // =================================================================================================================
    private AudioSource _audioSource;
    
    // =================================================================================================================
    // METHODS  
    // =================================================================================================================

    public void SetAudio(AudioSource audioSource) {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = audioSource.clip;
        _audioSource.volume = audioSource.volume;
        _audioSource.Play();
        // Invoke the method to destroy the GameObject after the audio clip length
        Invoke($"DestroyAfterAudio", _audioSource.clip.length);
    }

    private void DestroyAfterAudio()
    {
        // Destroy the GameObject or perform other actions
        Destroy(gameObject);
    }
}
