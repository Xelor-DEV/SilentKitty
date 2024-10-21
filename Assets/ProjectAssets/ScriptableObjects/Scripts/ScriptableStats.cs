using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/Player/PlayerStats")]
public class PlayerMovementStats : ScriptableObject
{
    [BoxGroup("Movement Settings")]
    [Range(0f, 20f), Tooltip("Velocidad de movimiento del jugador")]
    public float moveSpeed = 5f;

    [BoxGroup("Movement Settings")]
    [Range(0f, 1f), Tooltip("Tiempo de suavizado para el movimiento horizontal")]
    public float smoothTime = 0.1f;

    [BoxGroup("Jump Settings")]
    [Range(0f, 20f), Tooltip("Fuerza del salto del jugador")]
    public float jumpForce = 10f;

    [BoxGroup("Jump Settings")]
    [Range(0f, 10f), Tooltip("Altura m�xima que puede alcanzar el jugador al saltar")]
    public float jumpHeight = 4f;

    [BoxGroup("Jump Settings")]
    [Range(0f, 1f), Tooltip("Tiempo que el jugador puede saltar despu�s de caer de una plataforma (Coyote Time)")]
    public float coyoteTime = 0.2f;

    [BoxGroup("Jump Settings")]
    [Range(0f, 1f), Tooltip("Tiempo que el jugador puede presionar el bot�n de salto antes de tocar el suelo (Jump Buffer)")]
    public float jumpBufferTime = 0.1f;

    [BoxGroup("Jump Settings")]
    [Range(1f, 2f), Tooltip("Bonus de control en el punto m�s alto del salto (Apex)")]
    public float apexBonus = 1.2f;

    [BoxGroup("Fall Settings")]
    [Range(-30f, 0f), Tooltip("Velocidad m�xima de ca�da del jugador")]
    public float maxFallSpeed = -15f;

    [BoxGroup("Fall Settings")]
    [Range(1f, 5f), Tooltip("Multiplicador para la velocidad de ca�da cuando el jugador est� cayendo r�pidamente")]
    public float fallMultiplier = 2.5f;

    [BoxGroup("Fall Settings")]
    [Range(1f, 5f), Tooltip("Multiplicador para la velocidad de ca�da cuando el jugador hace un salto bajo")]
    public float lowJumpMultiplier = 2f;
}
