using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text scoreText;
    public int scoreKeeper;

    // Hittar texten
    private void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
    }

    public void IncreaseScore()
    {
        scoreKeeper += 1;
        scoreText.text = "Score: " + scoreKeeper.ToString();
    }

    public void DecreaseScore()
    {
        scoreKeeper -= 1;
        scoreText.text = "Score: " + scoreKeeper.ToString();
    }


}
