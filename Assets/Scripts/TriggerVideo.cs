using UnityEngine;
using UnityEngine.Video;

public class TriggerVideo : MonoBehaviour
{
    [SerializeField] private VideoClip video;
    [SerializeField] private AudioClip audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var mediaChanger = GameObject.Find("VideoSphere").GetComponent<ChangeVideoOnTrigger>();
            mediaChanger.ChangeMedia(video, audio);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var mediaChanger = GameObject.Find("VideoSphere").GetComponent<ChangeVideoOnTrigger>();
            mediaChanger.ChangeMedia(video, audio);
        }
    }
}
