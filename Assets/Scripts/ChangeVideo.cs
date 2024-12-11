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
            videoPlayer.Play();
            Debug.Log("Video changed and playing new video: "  + newVideoClip);
        }
        else
        {
            Debug.LogWarning("New video URL is empty or null.");
        }
    }

    void ChangeVideo(int clipNumber)
    {
        ChangeVideo(availableClips[clipNumber]);
    }
}