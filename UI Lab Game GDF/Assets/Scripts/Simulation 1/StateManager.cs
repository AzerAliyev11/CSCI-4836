using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        Playing
    }

    public GameState currentState;

    public static StateManager Instance;

    void Awake() {
        Instance = this;
    }

    void Start() {
        currentState = GameState.Playing;
    }

    void Update()
    {
        if (currentState == GameState.Menu)
        {
            UIManager.Instance.Pause();
        }
        else if (currentState == GameState.Playing)
        {
            UIManager.Instance.Play();
        }
    }
}
