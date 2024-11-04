using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCardManager : MonoBehaviour
{
    [SerializeField] private GameManagerMainMenu gameManagerMenu;

    private void Awake()
    {
        // Encuentra todos los LevelCard en los hijos
        LevelCard[] levelCards = GetComponentsInChildren<LevelCard>();

        for (int i = 0; i < levelCards.Length; ++i)
        {
            levelCards[i].GameManager = gameManagerMenu;
        }
    }
}
