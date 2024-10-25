using UnityEngine;
using System;
using NaughtyAttributes;
using Unity.VisualScripting;

public abstract class PlaceableObject : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    protected bool isPlaced = false;
    protected bool isGameModeStarted = false;
    [SerializeField] protected float mass;
    public bool IsGameModeStarted
    {
        get
        {
            return isGameModeStarted;
        }
        set
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
        set
        {
            isPlaced = value;
        }
    }

    public event Action OnPlaced;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    protected virtual void Start()
    {
        _rigidbody2D.mass = mass;
        _rigidbody2D.isKinematic = true;
    }
    protected virtual void Update()
    {

    }
    protected virtual void OnEnable()
    {

    }
    protected virtual void OnDisable()
    {

    }
    public virtual void Place()
    {
        OnPlaced?.Invoke();
        _rigidbody2D.isKinematic = false;
        isPlaced = true;
    }

}