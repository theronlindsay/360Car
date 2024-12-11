using UnityEngine;

public class CrashScene : MonoBehaviour
{
    private bool activate = false;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    public void Activate()
    {
        activate = true;
    }
}
