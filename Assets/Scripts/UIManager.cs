using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    #region Public variables
    public Text infoBar;
    public Text timerTxt;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    TimeSpan timeSpan;
    void Update()
    {
        timeSpan += TimeSpan.FromSeconds(Time.deltaTime);
        string timeText = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes+5, timeSpan.Seconds);
        timerTxt.text = timeText+" PM";
    }
}
