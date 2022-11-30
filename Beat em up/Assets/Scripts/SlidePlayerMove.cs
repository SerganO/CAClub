using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePlayerMove : PlayerMove
{
    public float slideTime = 0.25f;

    public override bool CanAction()
    {
        return base.CanAction() && !Hero.IsDie && Hero.CurrentState != HeroState.slide;
    }

    public override void Action()
    {
        StartCoroutine(DoCoroutine());
    }

    IEnumerator DoCoroutine()
    {
        if (Move != null) Move.Visualizate();
        Hero.CurrentState = HeroState.slide;
        
        for (int i = 0; i < 1; i++)
        {
            Hero.SetHitBoxEnabled(false);
            Hero.AddForce(new Vector2(1f * (Hero.IsInverted ? -1 : 1), 0));
            Hero.PlayAnimation("Sliding");
            yield return new WaitForSeconds(slideTime);
            Hero.SetHitBoxEnabled(true);
        }

        if (!Hero.IsDie) Hero.CurrentState = HeroState.idle;
    }
}
