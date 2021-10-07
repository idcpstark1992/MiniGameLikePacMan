public static class Delegates
{
    public delegate void DelegateOnMapCreated();
    public static        DelegateOnMapCreated Register_OnMapCreated;

    public delegate void    DelegateOnResetScene();
    public static           DelegateOnResetScene Register_OnResetScene;

    public delegate void DelegateOnResetBoardItems();
    public static DelegateOnResetBoardItems Register_OnResetBoardItems;

    public delegate void DelegateOnEarnPoint(float _pointsEarned);
    public static DelegateOnEarnPoint Register_OnEarnPoints;


    public delegate void DelegateOnEndGame();
    public static DelegateOnEndGame Register_OnEndgame;

}
