using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    public Transform cameraTransform;
    public Camera computerCamera;
    public GameObject canvas;
    public AudioSource walkSfx;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        computerCamera.gameObject.SetActive(false);
        canvas.SetActive(false);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        float xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float zMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 moveDirection = cameraTransform.transform.forward * zMovement + cameraTransform.transform.right * xMovement;
        moveDirection.y = 0f;
        transform.position += moveDirection;
        walkSfx.Play();
    }
}
