using UnityEngine;
using System;

public abstract class PlaceableObject : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    protected bool isPlaced = false;
    protected bool isGameModeStarted = false;
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
    public bool IsGameModeStarted
    {
        get
        {
            return isGameModeStarted;
        }
        protected set
        {
            isGameModeStarted = value;
        }
    }
    public bool IsPlaced
    {
        get
        {
            return isPlaced;
        }
        protected set
        {
            isPlaced = value;
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