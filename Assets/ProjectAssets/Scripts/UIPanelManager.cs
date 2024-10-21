using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class UIPanelManager : UIManager
{
    [BoxGroup("UI Windows and Auxiliary Points")]
    [ReorderableList] 
    [SerializeField] private RectTransform[] windows; 

    [BoxGroup("UI Windows and Auxiliary Points")]
    [MinValue(0)]
    [SerializeField] private float offCameraPosition; 

    [BoxGroup("UI Windows and Auxiliary Points")]
    [SerializeField] private GameObject buttons;  

    [BoxGroup("Transition Properties")]
    [Range(0.1f, 2.0f)] 
    [SerializeField] private float duration = 0.5f;

    [BoxGroup("Transition Properties")]
    [SerializeField] private Ease ease = Ease.OutQuad;

    [BoxGroup("Transition Properties")]
    [SerializeField, ReadOnly] private bool isWindowActive = false;

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
            windows[index].DOAnchorPosY(offCameraPosition, duration).SetEase(ease).OnComplete(() =>
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
