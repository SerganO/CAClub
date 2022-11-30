using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public bool Enabled = true;
    public string ID = "";

    [Header("Controll Hero")]
    public Hero Hero;

    [Header("UI Elements")]
    public MoveButton BindedButton;

    [Header("Move")]
    public PlayerMoveScript Move;

    public bool isAddedMove = false;
    public PlayerMoveScript AddedMove;

    [Header("Properties")]
    public float Countdown;

    public Sprite moveSprite;
    public bool xInverted = false;

    float currentCountdown;

    //
    bool isButtonActive = true;

    virtual public bool CanAction()
    {
        return isButtonActive;
    }

    void ActionIfCan()
    {
        if(CanAction())
        {
            Action();
            StartCoroutine(CountdownCoroutine());
        }
    }
    
    virtual public void Action(){
        Move.DoWithCompletion(() => { });
        if(isAddedMove)
            AddedMove.DoWithCompletion(() => { });
    }

    void Start()
    {
        BindedButton.onClick.AddListener(() => ActionIfCan());
        var enabled = GlobalUserData.ActiveUser
            .heroes.Find(x => x.HeroID == TransitionMaster.CurrentHeroID)
            .moves.Find(x => x.ID == ID)
            .IsEnable;
        BindedButton.SetEnabled(enabled);

    }

    protected IEnumerator CountdownCoroutine()
    {
        isButtonActive = false;
        currentCountdown = 0;
        while(currentCountdown < Countdown)
        {
            currentCountdown += Time.deltaTime;
            BindedButton.FrontImage.fillAmount = currentCountdown / Countdown;
            yield return null;
        }
        BindedButton.FrontImage.fillAmount = 1;
        currentCountdown = 0;
        isButtonActive = true;
    }

    bool isFirstUpdate = true;

    void Update()
    {
        FirstUpdateIfNeeded();
    }

    protected void FirstUpdateIfNeeded()
    {
        if (isFirstUpdate)
        {
            FirstUpdate();
            isFirstUpdate = false;
        }
    }

    public virtual void FirstUpdate()
    {
        BindedButton.FrontImage.sprite = moveSprite;
        BindedButton.BackImage.sprite = moveSprite;
        if (xInverted)
        {
            BindedButton.FrontImage.transform.localScale = new Vector3(-1, 1);
            BindedButton.BackImage.transform.localScale = new Vector3(-1, 1);
        } else
        {
            BindedButton.FrontImage.transform.localScale = new Vector3(1, 1);
            BindedButton.BackImage.transform.localScale = new Vector3(1, 1);
        }
    }
}
