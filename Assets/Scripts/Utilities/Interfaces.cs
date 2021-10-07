using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardItemType
{
    void SetItemTag(int _TagType);
    void SetPointExternal();
    int GetItemBoardType();
    string GetItemID();
}
public interface ICookiesSpawner
{
    void GrabableItem(Vector3 _InnerPosition, IBoardItemType _BoardParent);
    void RegisterNewType(string _IDCookie,IBoardItemType _InnerType);
    void SelectNewRandomPointToSpawnCookies();
    void OnGrabCookies(string _CookieInstanceID = default);
}

public interface ITween
{
    /// <summary>
    /// Rotate Player Rigid body
    /// </summary>
    /// <param name="_anglesDegrees"> Movement on Y axis</param>
    /// <param name="_ObjecToTween"> rigid body that you neer rotate </param>
    /// <param name="_movementSmothTime">   </param>
    void DoTween(float _anglesDegrees, Rigidbody _ObjecToTween, float _movementSmothTime);

    void DoUITween(float _Time, RectTransform _Transform, int _movementType);
}

public interface IPlayerInteraction
{
    void OnPlayerInteractionSET();
}

public interface ISerializer
{
    void SavePoints(int _points);
    int GetMaxPoints();
    int LoadPoints();
}