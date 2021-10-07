using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UC_Timer : MonoBehaviour
{
    private bool TriggeredEvent;
    [SerializeField] private int TotalTime;
    [SerializeField] private int TotalPoints;
    [SerializeField] private TMPro.TextMeshProUGUI PrintTime;
    [SerializeField] private TMPro.TextMeshProUGUI PrintPoints;
    [SerializeField] private TMPro.TextMeshProUGUI PrintHighScore;
    [SerializeField] private TMPro.TextMeshProUGUI PrintTotalScore;
    [SerializeField] private TMPro.TextMeshProUGUI PrintMessage;
    [SerializeField] private GameObject WorldCanvas;
    [SerializeField] private Canvas FinishCanvas;
    [SerializeField] private StringMessages _MessagesClass;
    [SerializeField] private UnityEngine.UI.Button OnResetButton;
    [SerializeField] private UC_PointsPrinterAndSerializer _PointSerializer;
    private void Start()
    {
        InvokeRepeating("RestTime", 1, 1);
        MinimizePointsUI();
        FinishCanvas.enabled = false;
        TriggeredEvent = false;
        Delegates.Register_OnEarnPoints += OnEarnPoints;
        OnResetButton.onClick.AddListener(CallRestartGame);
        Delegates.Register_OnEndgame += OnEndGame;
        Delegates.Register_OnResetScene += OnResetGame;
    }
  
    private void OnEndGame()
    {
        TriggeredEvent = true;
        OnFinishGame();
    }
    private void OnDisable()
    {
        Delegates.Register_OnEarnPoints -= OnEarnPoints;
        Delegates.Register_OnEndgame -= OnEndGame;
        Delegates.Register_OnResetScene += OnResetGame;
    }
    void OnResetGame()
    {
        TriggeredEvent = false;
    }
    private void OnEarnPoints(float _somePoints)
    {
        TotalPoints++;
        PrintPoints.text = TotalPoints.ToString();
        PrintMessage.text = _MessagesClass.GetRamdomMessage();
        WorldCanvas.transform.localScale = Vector3.one;
        Invoke("MinimizePointsUI", 1);
    }
    private void MinimizePointsUI()
    {
        WorldCanvas.transform.localScale = Vector3.zero;
    }
    private void RestTime()
    {
        TotalTime--;
        if (TotalTime < 0 && !TriggeredEvent)
        {
            Delegates.Register_OnEndgame?.Invoke();
        }
        PrintTime.text = TotalTime.ToString();
    }
    
    private void OnFinishGame()
    {
        Debug.Log(_PointSerializer.GetDiskPoints());
        if (_PointSerializer.GetDiskPoints() <TotalPoints)
        {
            PrintHighScore.text = _PointSerializer.GetDiskPoints().ToString() ;
            _PointSerializer.SetSerialization(TotalPoints);
        }
        PrintTotalScore.text = TotalPoints.ToString();
        FinishCanvas.enabled = true;
    }
    private void CallRestartGame()
    {
        TotalTime = 30;
        TotalPoints = 0;
        PrintPoints.text = "0";
        PrintTime.text = "30";
        Delegates.Register_OnResetScene?.Invoke();
        FinishCanvas.enabled = false;
    }


}