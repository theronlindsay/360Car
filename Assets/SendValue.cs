using Unity.VRTemplate;
using UnityEngine;

public class SendValue : MonoBehaviour
{

    public float value;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = GetComponent<UnityEngine.XR.Content.Interaction.XRKnob>().value;   
    }
}
