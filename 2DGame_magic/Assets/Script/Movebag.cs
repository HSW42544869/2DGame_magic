using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movebag : MonoBehaviour, IDragHandler
{
    
    RectTransform currentRest;

    public void OnDrag(PointerEventData eventData)
    {
        currentRest.anchoredPosition += eventData.delta;
    }
    private void Awake()
    {
        currentRest = GetComponent<RectTransform>();
    }
}
