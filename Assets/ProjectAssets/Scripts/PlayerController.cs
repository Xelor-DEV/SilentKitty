using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private bool isGrounded;
    private float horizontalDirection;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    private float currentVelocityX;
    private Vector2 raycastDirection = new Vector2(0, -1);

    [SerializeField] private PlayerMovementStats playerConfig;
    [SerializeField] private LayerMask groundLayers;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckGrounded();
        HandleCoyoteTime();
        HandleJumpBuffer();
        FlipSprite();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
        ApplyGravityMultipliers();
        LimitFallSpeed();
    }
    

    public void GetMovementHorizontalInput(InputAction.CallbackContext context)
    {
        horizontalDirection = context.ReadValue<float>();
    }

    public void GetJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            jumpBufferCounter = playerConfig.jumpBufferTime;
        }
    }

    private void CheckGrounded()
    {
        // Comprobamos si el jugador está en el suelo
        isGrounded = Physics2D.Raycast(transform.position, raycastDirection, 1, groundLayers);
    }

    private void HandleCoyoteTime()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = playerConfig.coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    private void HandleJumpBuffer()
    {
        jumpBufferCounter -= Time.deltaTime;
    }

    private void FlipSprite()
    {
        // Si se mueve hacia la izquierda, voltea el sprite, si se mueve a la derecha lo regresa a su estado original
        if (horizontalDirection < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (horizontalDirection > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void HandleMovement()
    {
        // Movimiento suavizado utilizando SmoothDamp
        float targetSpeed = horizontalDirection * playerConfig.moveSpeed;
        _rigidbody2D.velocity = new Vector2(
            Mathf.SmoothDamp(_rigidbody2D.velocity.x, targetSpeed, ref currentVelocityX, playerConfig.smoothTime),
            _rigidbody2D.velocity.y
        );
    }

    private void HandleJump()
    {
        // Saltar con buffer y tiempo de coyote
        if (jumpBufferCounter > 0 && (isGrounded || coyoteTimeCounter > 0f))
        {
            // Aplicar bonus de apex si está en el punto más alto del salto
            float apexModifier = (Mathf.Abs(_rigidbody2D.velocity.y) < 0.1f) ? playerConfig.apexBonus : 1f;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, playerConfig.jumpForce * apexModifier);

            // Restablecemos los contadores de buffer y coyote
            jumpBufferCounter = 0;
            coyoteTimeCounter = 0;
        }
    }

    private void ApplyGravityMultipliers()
    {
        // Aplicar multiplicadores de gravedad para un salto más suave
        if (_rigidbody2D.velocity.y < 0)
        {
            // Velocidad de caída aumentada
            _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (playerConfig.fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (_rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // Caída más suave si no se mantiene el salto
            _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (playerConfig.lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    private void LimitFallSpeed()
    {
        // Limitar la velocidad de caída máxima
        if (_rigidbody2D.velocity.y < playerConfig.maxFallSpeed)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, playerConfig.maxFallSpeed);
        }
    }
}
