using UnityEngine;

public class SpiderWebBox : Box
{
    [SerializeField] private float bounceForce = 15f;

    protected override void Start()
    {
        base.Start();
        _rigidbody2D.freezeRotation = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                ApplyBounce(playerRb);
            }
        }
    }

    private void ApplyBounce(Rigidbody2D playerRb)
    {
        // Aplicamos un impulso hacia arriba
        playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);
    }
}
