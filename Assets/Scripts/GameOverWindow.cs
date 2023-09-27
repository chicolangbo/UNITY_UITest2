using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.PackageManager.UI;

public class GameOverWindow : GenericWindow
{
    public enum Texts
    {
        LeftLabels,
        LeftStats,
        RightLabels,
        RightStats,
        TotalScore,
    }

    public TextMeshProUGUI[] texts;

    private int totalStep = 7; // 0 1 2 / 3 4 5 / 6
    private int currentStep = -1;

    public float duration = 2f;
    public float interval = 1f;
    private float timer = 0f;

    private int[] scores = new int[7];

    public void ClearTexts()
    {
        foreach (var t in texts)
        {
            t.text = string.Empty;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (currentStep >= totalStep)
        {
            int score = (int)Mathf.Lerp(0, scores[6], timer / duration);
            texts[4].text = $"{score:D8}";
            return;
        }

        if (timer > interval)
        {
            timer = 0f;
            ++currentStep;

            switch (currentStep)
            {
                case 0:
                case 1:
                case 2:
                    texts[0].text += $"STAT {currentStep + 1}\n";
                    texts[1].text += $"{scores[currentStep]:D4}\n";
                    break;
                case 3:
                case 4:
                case 5:
                    texts[2].text += $"STAT {currentStep + 1}\n";
                    texts[3].text += $"{scores[currentStep]:D4}\n";
                    break;
                case 6:
                    texts[4].text = $"{0:D8}";
                    break;
            }
        }
    }

    public override void Open()
    {
        scores[6] = 0;
        for (var i = 0; i < 6; ++i)
        {
            scores[i] = Random.Range(0, 9999);
            scores[6] += scores[i];
        }

        ClearTexts();
        base.Open();

        currentStep = -1;
        timer = 0f;
    }

    public override void Close()
    {
        base.Close();
    }

    public void OnClickNext()
    {
        WindowManager.Instance.Open(Windows.Start);
    }
}