using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UC_PointsPrinterAndSerializer : MonoBehaviour
{
    private ISerializer JSonSerializer;
    void Start()
    {
        JSonSerializer = new SerializePointsInJason();
        JSonSerializer.LoadPoints();
    }
    public void SetSerialization(int _TotalPoints)
    {
        JSonSerializer.SavePoints(_TotalPoints);
    }
    public int GetDiskPoints()
    {
        return JSonSerializer.LoadPoints();
    }
}
