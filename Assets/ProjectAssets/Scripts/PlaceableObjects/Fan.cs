using UnityEngine;

public class Fan : PlaceableObject
{
    [SerializeField] private bool isFacingRight;
    [SerializeField] private float pushForce;
    [SerializeField] private Collider2D windZone;

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            Vector2 pushDirection = isFacingRight ? Vector2.right : Vector2.left;
            playerRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }

    protected override void OnPlacedAction()
    {
        base.OnPlacedAction();
        // Activar el ventilador cuando sea colocado
    }
}
