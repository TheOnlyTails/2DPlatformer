using UnityEngine;

public class ScoreMenu : MonoBehaviour
{
    private void Update()
    {
        gameObject.SetActive(!PauseMenu.IsPaused);
    }
}
