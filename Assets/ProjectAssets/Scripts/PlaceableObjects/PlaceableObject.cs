using UnityEngine;
using System;

public abstract class PlaceableObject : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    protected bool isPlaced = false;

    public event Action OnPlaced;
    public event Action OnGameModeStart;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = true;  // Inicia desactivando la gravedad
    }

    // Método para llamar cuando el objeto es colocado por el jugador
    public virtual void Place()
    {
        OnPlaced?.Invoke();
        _rigidbody2D.isKinematic = false; // Activar gravedad
        isPlaced = true;
    }

    // Método para que otros objetos hereden y personalicen
    protected virtual void OnPlacedAction()
    {
        // Acción genérica al ser colocado
    }
}