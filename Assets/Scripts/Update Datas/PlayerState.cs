
[System.Serializable]
public class PlayerState
{
    public PlayerData playerData = new PlayerData();

    //"Player Turn"
    public bool playerTurn;
    public int currentState = 0;

    public void ResetState()
    {
        currentState = 0;

    }


}
