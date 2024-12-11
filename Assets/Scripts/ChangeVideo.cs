using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

//Usage: call ChangeVideo() method to change the video clip of the VideoPlayer component

public class ChangeVideoOnTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public VideoClip newVideoClip; // Reference to the new video clip   
    void ChangeVideo(VideoClip newVideoClip) // Change the video clip of the VideoPlayer component
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
}