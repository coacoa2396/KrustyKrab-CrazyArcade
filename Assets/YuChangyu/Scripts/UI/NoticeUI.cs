using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 제작 : 찬규 
/// 게임씬 우측 상단의 공지를 입력받고 좌우 스크롤 형식으로 이동시키는 컴포넌트
/// </summary>
public class NoticeUI : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] Image viewPort;            // 텍스트를 보여줄 범위
    [SerializeField] GameObject content;        // 공지를 가져와 넣을 프리팹
    [SerializeField] GameObject[] contents;     // 공지를 넣은 프리팹의 배열
    [SerializeField] List<string> notices;      // 공지 확인용 리스트

    [Header("Spec")]
    [SerializeField] float scrollSpeed;         // 스크롤의 스피드
    [SerializeField] float offset;              // 무한스크롤을 위한 offset

    private List<Dictionary<string, object>> csv;

    private void Start()
    {
        csv = CSVReader.Read("Data/CSV/NoticeTable");
        contents = new GameObject[csv.Count];

        for (int i = 0; i < csv.Count; i++)
        {
            // anchoredPosition 사용을 위해 생성하고 RectTransform을 가져온다
            RectTransform _content = Instantiate(content, viewPort.transform).GetComponent<RectTransform>();

            _content.anchoredPosition = new Vector2(230 + (500 * i), _content.anchoredPosition.y);      // 나중에 생성된 공지는 뒤쪽에 생성해준다

            TMP_Text _text = _content.GetComponentInChildren<TMP_Text>();
            _text.text = $"{csv[i]["order"]}.{csv[i]["notice"]}";           // 공지를 TMP_Text에 넣어준다

            contents[i] = _content.gameObject;
            notices.Add($"{csv[i]["order"]}.{csv[i]["notice"]}");
        }
    }

    private void Update()
    {
        for (int i = 0; i < contents.Length; i++)
        {
            // 왼쪽으로 이동하게 만들어준다
            contents[i].transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime, Space.World);

            RectTransform _content = contents[i].GetComponent<RectTransform>();
            Vector2 _offset = new Vector2(offset * contents.Length, _content.anchoredPosition.y);

            if (_content.anchoredPosition.x < -(_offset.x + 85))
            {
                _content.anchoredPosition = _offset;
            }
        }
    }
}
