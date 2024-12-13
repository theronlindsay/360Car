using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

//Usage: call ChangeVideo() method to change the video clip of the VideoPlayer component

public class ChangeVideoOnTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public AudioSource audioSource;
    [SerializeField] public List<VideoClip> availableClips; // Reference to the new video clip
    [SerializeField] public List<AudioClip> availableAudioClips;
    private float idleTimer = 0;

    private void Start()
    {
        ChangeMedia(availableClips[0], availableAudioClips[0]);
        StartCoroutine(playMedia2());
    }

    IEnumerator playMedia2()
    {
        yield return new WaitForSeconds(8);
        ChangeMedia(availableClips[1], availableAudioClips[1]);
    }

    public void ChangeMedia(VideoClip newVideoClip, AudioClip newAudioClip)
    {
        if (newVideoClip != null)
        {
            videoPlayer.clip = newVideoClip;
            videoPlayer.isLooping = false;
            videoPlayer.Play();
        }

        if (newAudioClip != null)
        {
            audioSource.clip = newAudioClip;
            audioSource.loop = false;
            audioSource.Play();
        }

        Debug.Log("Media changed to video: " + newVideoClip + " and audio: " + newAudioClip);
    }


    private void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            idleTimer += Time.deltaTime;
        }
        else
        {
            idleTimer = 0;
        }

        // Switch to Idle if no video is playing, but wait for a moment first in case another video is going to play soon
        if (!videoPlayer.isPlaying && idleTimer > 0.5f)
        {
            videoPlayer.clip = availableClips[2];
            videoPlayer.isLooping = true;
            videoPlayer.Play();

            audioSource.clip = null;
        }
    }
}

