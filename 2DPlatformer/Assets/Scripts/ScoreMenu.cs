using UnityEngine;

public class ScoreMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(!PauseMenu.IsPaused);
    }

    private void Update()
    {
        gameObject.SetActive(!PauseMenu.IsPaused);
    }
}