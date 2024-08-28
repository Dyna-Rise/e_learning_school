using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject retryButton;
    public GameObject nextButton;
    public GameObject gameOverText;
    public GameObject stageClearText;

    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);    
        nextButton.SetActive(false);    
        gameOverText.SetActive(false);    
        stageClearText.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.gameState == "gameOver")
        {
            retryButton.SetActive(true);
            gameOverText.SetActive(true);
            PlayerController.gameState = "gameEnd";
        }

        if (PlayerController.gameState == "gameClear")
        {
            nextButton.SetActive(true);
            stageClearText.SetActive(true);
            PlayerController.gameState = "gameEnd";
        }
    }
}
