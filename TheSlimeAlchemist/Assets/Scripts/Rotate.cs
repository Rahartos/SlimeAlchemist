using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void Update()
    {
        // Rotate left when A key is pressed
        if (Input.GetKey(KeyCode.Q))
        {
            RotateObjectLeft();
        }

        // Rotate right when D key is pressed
        if (Input.GetKey(KeyCode.E))
        {
            RotateObjectRight();
        }
    }

    void RotateObjectLeft()
    {
        // Rotate the object around its up axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void RotateObjectRight()
    {
        // Rotate the object around its up axis in the opposite direction
        transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
    }
}