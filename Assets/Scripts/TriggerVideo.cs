using UnityEngine;
using UnityEngine.Video;

public class TriggerVideo : MonoBehaviour
{
    [SerializeField] private VideoClip video;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ChangeVideoOnTrigger>().ChangeVideo(video);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ChangeVideoOnTrigger>().ChangeVideo(video);
        }
    }
}
