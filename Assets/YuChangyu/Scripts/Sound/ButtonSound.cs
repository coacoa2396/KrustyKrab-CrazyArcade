using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 제작 : 찬규 
/// 버튼 클릭 사운드
/// </summary>
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
