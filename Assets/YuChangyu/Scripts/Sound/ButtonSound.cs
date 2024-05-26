using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Manager.Sound.PlaySFX("Click");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Manager.Sound.PlaySFX("OnButton");
    }
}
