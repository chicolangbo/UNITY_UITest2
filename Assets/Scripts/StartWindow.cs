using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public bool canContinue = false;

    public Button newGameButton;
    public Button conitnueButton;


    public override void Open()
    {
        conitnueButton.gameObject.SetActive(canContinue);
        firstSelected = canContinue ?
            conitnueButton.gameObject : newGameButton.gameObject;

        base.Open();
    }

    public void OnClickContinue()
    {
        Debug.Log("Continue");
    }

    public void OnClickNewGame()
    {
        WindowManager.Instance.Open(Windows.GameOver);
    }

    public void OnClickOptions()
    {
        WindowManager.Instance.Open(Windows.Difficulty);
    }
}