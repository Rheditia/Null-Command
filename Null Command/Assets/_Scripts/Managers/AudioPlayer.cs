using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] AudioClip jumpClip;
    [SerializeField] [Range(0f, 1f)] float jumpVolume = 1f;

    [Header("Retract")]
    [SerializeField] AudioClip retractClip;
    [SerializeField] [Range(0f, 1f)] float retractVolume = 1f;

    static AudioPlayer Instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayJumpClip()
    {
        PlayClip(jumpClip, jumpVolume);
    }

    public void PlayRetractClip()
    {
        PlayClip(retractClip, retractVolume);
    }


    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

    public void ResetAudio()
    {
        Instance = null;
        Destroy(gameObject);
    }
}
