using UnityEngine;
public class Box : PlaceableObject
{
    protected override void OnPlacedAction()
    {
        base.OnPlacedAction();
        // Activar mec�nicas espec�ficas para la caja com�n
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Permitir que el jugador la empuje o la use como plataforma
        if (collision.gameObject.CompareTag("Player"))
        {
            // Logica para empujar o interactuar
        }
    }
}
