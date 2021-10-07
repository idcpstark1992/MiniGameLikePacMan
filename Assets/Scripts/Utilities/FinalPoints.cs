using UnityEngine;

[System.Serializable]
public class FinalPoints
{
    [SerializeField] public int EarnedPoints;
    public FinalPoints(int _finalPoints)
    {
        EarnedPoints = _finalPoints;
    }
}
