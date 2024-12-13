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
    [SerializeField] public List<VideoClip> availableClips; // Reference to the new video clip
    private float idleTimer = 0;

    private void Start()
    {
        ChangeVideo(0);
        StartCoroutine(playVideo2());
    }

    IEnumerator playVideo2()
    {
        yield return new WaitForSeconds(7);
        ChangeVideo(1);
    }

    public void ChangeVideo(VideoClip newVideoClip) // Change the video clip of the VideoPlayer component
    {
        if (!newVideoClip.Equals(null))
        {
            videoPlayer.clip = newVideoClip;
            videoPlayer.isLooping = false;
            videoPlayer.Play();
            Debug.Log("Video changed and playing new video: "  + newVideoClip);
        }
        else
        {
            Debug.LogWarning("New video URL is empty or null.");
        }
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
            Debug.Log("No video playing, switching to Idle");
        }
    }

    void ChangeVideo(int clipNumber)
    {
        ChangeVideo(availableClips[clipNumber]);
    }
}