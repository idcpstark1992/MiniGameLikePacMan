using UnityEngine;

public class SerializePointsInJason : ISerializer
{


    public int GetMaxPoints()
    {
        throw new System.NotImplementedException();
    }

    public int LoadPoints()
    {
        int mToReturn = 0;
        if(System.IO.File.Exists(Application.persistentDataPath + "/FinalPointsData.json"))
        {
            string mText = System.IO.File.ReadAllText(Application.persistentDataPath + "/FinalPointsData.json");
            FinalPoints mToLoad = JsonUtility.FromJson<FinalPoints>(mText);
            mToReturn = mToLoad.EarnedPoints;
        }
        return mToReturn;
    }

    public void SavePoints(int _pointsAmount)
    {
       
       FinalPoints mToSave = new FinalPoints(_pointsAmount);
       string JsonString =  JsonUtility.ToJson(mToSave,true);
       System.IO.File.WriteAllText(Application.persistentDataPath + "/FinalPointsData.json", JsonString);
    }
}
