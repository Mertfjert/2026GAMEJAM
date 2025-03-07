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

    // Lägger till +1 i score texten
    public void IncreaseScore()
    {
        scoreKeeper += 1;
        scoreText.text = "Score: " + scoreKeeper.ToString();
    }

    // Lägger till -1 i score texten
    public void DecreaseScore()
    {
        scoreKeeper -= 1;
        scoreText.text = "Score: " + scoreKeeper.ToString();
    }


}
