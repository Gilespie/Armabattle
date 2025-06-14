using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singlton
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    
    private Player _player;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }

    private CursorBehaviour _cursorBehaviour;

    public CursorBehaviour CursorBehaviour
    {
        get { return _cursorBehaviour; }
        set { _cursorBehaviour = value; }
    }

    private SetTimescale _timescale;

    public SetTimescale Timescale
    {
        get { return _timescale; }
        set { _timescale = value; }
    }
}