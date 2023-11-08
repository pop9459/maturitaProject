using UnityEngine;

public class RestartButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        Controller.restartGame();
        gameObject.SetActive(false);
    }
}
