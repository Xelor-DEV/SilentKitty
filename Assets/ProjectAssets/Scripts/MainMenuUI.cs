using DG.Tweening;
using UnityEngine;

public class MainMenuUI : UIManager
{
    [Header("UI Windows and Auxiliary Points")]
    [SerializeField] private RectTransform[] windows;         // Ventanas de UI
    [SerializeField] private float OffCameraPosition; // Posición fuera de cámara
    [SerializeField] private GameObject buttons;              // Botones de la UI

    [Header("Transition Properties")]
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Ease ease = Ease.OutQuad;

    private bool isWindowActive = false;  // Controla si una ventana está activa

    private void SetActiveAllChildren(GameObject parent, bool isActive)
    {
        int childCount = parent.transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            parent.transform.GetChild(i).gameObject.SetActive(isActive);
        }
    }

    public void HideWindow(int index)
    {
        if (index >= 0 && index < windows.Length && isWindowActive == true)
        {
            SetActiveAllChildren(buttons, true);
            windows[index].DOAnchorPosY(OffCameraPosition, duration).SetEase(ease).OnComplete(() =>
            {
                isWindowActive = false;  // Permitir mostrar otra ventana después de ocultar
            });
        }
    }

    public void ShowWindow(int index)
    {
        if (index >= 0 && index < windows.Length && isWindowActive == false)
        {
            isWindowActive = true;  // Marcar que hay una ventana activa
            windows[index].DOAnchorPosY(0.0f, duration).SetEase(ease).OnComplete(() =>
            {
                SetActiveAllChildren(buttons, false);
            });
        }
    }

}
