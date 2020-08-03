using UnityEngine;

public class GameData : MonoBehaviour
{
    public string Size = "4x4";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
