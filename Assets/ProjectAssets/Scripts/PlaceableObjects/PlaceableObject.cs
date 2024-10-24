using UnityEngine;
using System;

public abstract class PlaceableObject : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    protected bool isPlaced = false;
    protected float pushForce;

    public float PushForce
    {
        get
        {
            return pushForce;
        }
        protected set
        {
            pushForce = value;
        }
    }

    public event Action OnPlaced;
    public event Action OnGameModeStart;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
    }
    public virtual void Place()
    {
        OnPlaced?.Invoke();
        _rigidbody2D.gravityScale = 1;
        isPlaced = true;
    }
}