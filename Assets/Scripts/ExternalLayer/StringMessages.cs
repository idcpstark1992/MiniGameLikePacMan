using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringMessages : MonoBehaviour
{
    [SerializeField] private string InnerString;
    [SerializeField] private string[] MessagesList;

    private void Start()
    {
        SplitMessage();
    }
    private void SplitMessage()
    {
        MessagesList = InnerString.Split(',');
    }
    public string GetRamdomMessage()
    {
        return MessagesList[Random.Range(0, MessagesList.Length)];
    }
}
