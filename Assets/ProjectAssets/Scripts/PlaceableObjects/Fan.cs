using UnityEngine;

public class Fan : PlaceableObject
{
    [SerializeField] private float pushVelocity = 5f;  // Velocidad que aplicará el ventilador
    [SerializeField] private Collider2D windTriggerCollider;  // Collider de trigger para el viento
    [SerializeField] private bool isFacingRight = true;  // Dirección inicial (derecha)

    protected override void Start()
    {
        base.Start();
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        // Giramos el ventilador en Y dependiendo de si está mirando a la derecha o a la izquierda
        transform.rotation = isFacingRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                // Ajusta la velocidad del jugador directamente en la dirección del viento
                Vector2 pushDirection = isFacingRight ? Vector2.right : Vector2.left;
                playerRigidbody.velocity = new Vector2(pushDirection.x * pushVelocity, playerRigidbody.velocity.y);
            }
        }
    }

    public void ToggleDirection()
    {
        // Cambia la dirección entre derecha e izquierda
        isFacingRight = !isFacingRight;
        UpdateRotation();
    }

    protected override void Place()
    {
        base.Place();
        windTriggerCollider.enabled = true;  // Activa el trigger para el viento cuando se coloca
    }
}
