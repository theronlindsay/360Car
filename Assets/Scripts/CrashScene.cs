using UnityEngine;

public class CrashScene : MonoBehaviour
{
    private bool activate = false;

    // Update is called once per frame
    void Update()
    {
        if (activate) transform.Translate(Vector3.forward * Time.deltaTime);
    }

    public void Activate()
    {
        activate = true;
    }
}
