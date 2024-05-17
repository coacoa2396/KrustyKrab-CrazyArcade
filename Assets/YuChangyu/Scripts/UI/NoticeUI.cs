using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] Image viewPort;
    [SerializeField] GameObject content;
    [SerializeField] List<TMP_Text> notices;

    [Header("Spec")]
    [SerializeField] float scrollSpeed;
    [SerializeField] float offset;

    private List<Dictionary<string, object>> csv;

    private void Start()
    {
        csv = CSVReader.Read("Data/CSV/noticeTable");
        for (int i = 0; i < csv.Count; i++)
        {
            RectTransform _content = Instantiate(content, transform.position, Quaternion.identity).GetComponent<RectTransform>();
            //_content.anchorePosition = 
        }
    }

    private void Update()
    {

    }
}
