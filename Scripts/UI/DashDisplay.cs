using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DashDisplay : UIelement
{
    public Text displayText = null;

    public override void UpdateUI()
    {
        base.UpdateUI();
        DisplayDash();
    }

    private void DisplayDash()
    {
        if (displayText != null) {
            displayText.text = "Dash: " + GameManager.dash.ToString();
        }
    }
}