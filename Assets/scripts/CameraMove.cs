using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private CustomInput m_input = null;
    private Vector2 m_MoveVector;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float leftLimit = -10f; // Define left limit
    [SerializeField] private float rightLimit = 10f; // Define right limit
    [SerializeField] private float frontLimit = 0.0f; // Define front limit
    [SerializeField] private float backLimit = -20f; // Define back limit

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_input = new CustomInput();
    }

    void OnEnable()
    {
        m_input.Enable();
        m_input.Player.Movement.started += OnMovePerformed;
        m_input.Player.Movement.canceled += OnMoveCanceled;
    }

    void OnDisable()
    {
        m_input.Disable();
        m_input.Player.Movement.started -= OnMovePerformed;
        m_input.Player.Movement.canceled -= OnMoveCanceled;
    }

    void OnMovePerformed(InputAction.CallbackContext context)
    {
        m_MoveVector = context.ReadValue<Vector2>();
    }

    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        m_MoveVector = Vector2.zero;
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(m_MoveVector.x, 0, m_MoveVector.y);
        if (Camera.main != null)
        {
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        }
        else
        {
            Debug.LogError("Main camera is not found!");
            return;
        }
        moveDirection.y = 0;

        Vector3 newPosition = transform.localPosition + moveDirection * moveSpeed * Time.fixedDeltaTime;
        // Clamp the position within the defined limits
        newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);
        newPosition.z = Mathf.Clamp(newPosition.z, backLimit, frontLimit);

        transform.localPosition = newPosition;
    }
}