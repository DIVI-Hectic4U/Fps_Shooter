using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    
    public float xSensitivity = 30f;
    public float ySenitivity = 30f;
    

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        // calculate cameraRotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySenitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        // apply this to our camera Transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }


}
