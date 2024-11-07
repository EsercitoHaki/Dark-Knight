using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_StatToolTip : UI_ToolTip
{
     [SerializeField] private TextMeshProUGUI description;
    
    public void ShowStatToolTip( string _text)
    {
        description.text = _text;
        AdjustPosition();

        gameObject.SetActive(true);
    }

    public void HideStatToolTip()
    {
        description.text = "";
        gameObject.SetActive(false);
    }
}
