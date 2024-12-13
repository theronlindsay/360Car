using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonVr : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {
           StartCoroutine(playMedia());
        }
    }
    IEnumerator playMedia()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}