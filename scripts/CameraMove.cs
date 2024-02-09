using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private CustomInput input = null;
    private Vector2 m_MoveVector;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float leftLimit = -10f; // Define left limit
    [SerializeField] private float rightLimit = 10f; // Define right limit
    [SerializeField] private float frontLimit = 0.0f; // Define front limit
    [SerializeField] private float backLimit = -20f; // Define back limit

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        input = new CustomInput();
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.Movement.started += OnMovePerformed;
        input.Player.Movement.canceled += OnMoveCanceled;
    }

    void OnDisable()
    {
        input.Disable();
        input.Player.Movement.started -= OnMovePerformed;
        input.Player.Movement.canceled -= OnMoveCanceled;
    }

    void OnMovePerformed(InputAction.CallbackContext context)
    {
        m_MoveVector = context.ReadValue<Vector2>();
    }

    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        m_MoveVector = Vector2.zero;
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(m_MoveVector.x, 0, m_MoveVector.y);
        moveDirection.y = 0;

        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
        // Clamp the position within the defined limits
        newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);
        newPosition.z = Mathf.Clamp(newPosition.z, backLimit, frontLimit);

        transform.position = newPosition;
    }
}