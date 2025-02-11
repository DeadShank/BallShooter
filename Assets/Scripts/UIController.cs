using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    
    public void EnableWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void EnableLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}