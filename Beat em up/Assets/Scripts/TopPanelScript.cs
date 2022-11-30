using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopPanelScript : MonoBehaviour
{
    public DifficultZone DifficultZone;
    public Text Name;

    public void Setup()
    {
        var level = TransitionMaster.CurrentPlanet.ToString() + TransitionMaster.CurrentSublevel;
        var name = TransitionMaster.CurrentPlanet.ToString() + " " + TransitionMaster.CurrentSublevel;
        DifficultZone.Setup(level);
        Name.text = name;
    }


}
