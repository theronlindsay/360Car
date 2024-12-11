using UnityEngine;
public class FreezeRotation : MonoBehaviour
{
	public float rotationX;
	public float rotationY;
	public float rotationZ;
 	void Update ()
	{
		Vector3 eulerAngles = transform.eulerAngles;
		transform.Rotate(0, 0, rotationZ);

	}
}