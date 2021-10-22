using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private CharacterController _controller;
    private bool _isMouseMoving;
    private Transform _transform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _isMouseMoving = true;
        _transform = GetComponent<Transform>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.anyKey) Move();
        if (_isMouseMoving) Rotate();
    }

    private void Move()
    {
        // Decides which direction to move based on what the player input's.
        var direction = new Vector3(
            Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        
        // Calculates what direction the charater is supposed to move to based on the rotation of the character. 
        var targetDirection = transform.forward * direction.z + transform.right * direction.x;
        
        // Moves the character using the character controller component
        _controller.Move(targetDirection * movementSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        // Rotates the character based on the mouse's movement on the X-axis
        _transform.Rotate(Vector3.up, Time.deltaTime * Input.GetAxis("Mouse X") * 1000);
    }
}