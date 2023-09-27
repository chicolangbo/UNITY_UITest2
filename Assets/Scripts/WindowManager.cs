using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager Instance { get; private set; }
    public GenericWindow[] windows;

    public Windows currentWindowId;
    public Windows defaultWindowId;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("!!");
        }
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void Start()
    {
        foreach (var window in windows)
        {
            window.Close();
        }
        Open(defaultWindowId);
    }

    public GenericWindow Open(Windows window)
    {
        // activeSelf => 현재의 active상태를 bool형으로 반환(계층관계 상관X)
        // activeHierArcky => 계층관계 상관O
        if (windows[(int)currentWindowId].gameObject.activeSelf)
        {
            windows[(int)currentWindowId].Close();
        }
        currentWindowId = window;

        windows[(int)currentWindowId].Open();
        return windows[(int)currentWindowId];
    }


}