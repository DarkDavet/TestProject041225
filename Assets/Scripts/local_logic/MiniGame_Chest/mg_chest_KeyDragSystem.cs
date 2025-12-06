using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mg_chest_KeyDragSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private mg_chest_LogicManager mgManager;
    private Color keyColor;
    private Transform originalParent;
    private Canvas canvas;

    public void Init(mg_chest_LogicManager manager, Color color)
    {
        canvas = GetComponentInParent<Canvas>();
        mgManager = manager;
        keyColor = color;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(
            mgManager.LockRect, eventData.position))
        {
            if (mgManager.AddKey(keyColor))
            {
                Destroy(gameObject);
            }
            else
            {
                transform.SetParent(originalParent);
                transform.localPosition = Vector3.zero;
            }
        }
        else
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
        }
    }
}
