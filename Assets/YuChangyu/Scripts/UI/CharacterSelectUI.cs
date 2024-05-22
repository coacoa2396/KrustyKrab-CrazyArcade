using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 제작 : 찬규
/// 캐릭터셀렉칸에 마우스를 올리면 캐릭터의 초기스탯과 최대스텟을 보여주는 UI를 띄워준다
/// 마우스를 내리면 다시 꺼진다
/// </summary>
public class CharacterSelectUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Canvas characterStatImage;
    [SerializeField] Canvas curImage;

    bool isInst;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isInst == false)
        {
            curImage = Instantiate(characterStatImage);
            isInst = true;
        }
        else
        {
            curImage.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        curImage.gameObject.SetActive(false);
    }
}
