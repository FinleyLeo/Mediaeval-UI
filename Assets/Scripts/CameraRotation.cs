using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float turnSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * turnSpeed * Vector3.up);
    }
}
