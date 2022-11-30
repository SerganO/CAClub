using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanelScript : MonoBehaviour
{
    public Text Text;

    public Button Accept;
    public Button Undo;

    bool isQuest = false;

    private void Start()
    {
        Accept.onClick.AddListener(() =>
        {
            AcceptAction();
        });

        Undo.onClick.AddListener(() =>
        {
            UndoAction();
        });
    }

    void Show()
    {
        gameObject.SetActive(true);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowInfo()
    {
        isQuest = false;
        Undo.gameObject.SetActive(false);
        Accept.transform.localPosition = new Vector3(0, Accept.transform.localPosition.y, Accept.transform.localPosition.z);
        Show();
    }

    BoolFunc _comp;
    public void ShowQuestions(BoolFunc completion)
    {
        _comp = completion;
        isQuest = true;
        Undo.gameObject.SetActive(true);
        Accept.transform.localPosition = new Vector3(175, Accept.transform.localPosition.y, Accept.transform.localPosition.z);
        Show();
    }

    public void SetMessageText(string text)
    {
        Text.text = text;
    }

    public void AcceptAction()
    {
        if(isQuest)
        {
            _comp(true);
        }

        Hide();
    }

    public void UndoAction()
    {
        if (isQuest)
        {
            _comp(false);
        }

        Hide();
    }
}
