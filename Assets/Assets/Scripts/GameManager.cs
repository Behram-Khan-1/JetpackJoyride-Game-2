
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerPrefs playerData;
    public static GameManager Instance { get; private set; }
    public GameObject Player;
    private float distanceTraveled = 0f;
    private float highScore = 0f;
    private int health = 1;

    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject DeathScreen;


    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // destroy duplicate
            return;
        }
        Instance = this;

        highScore = PlayerPrefs.GetFloat("HighScore");
        highScoreText.text = "Highscore " + highScore.ToString("0") + "m";
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
    }

    private void CalculateDistance()
    {
        if (distanceText != null)
        {
            distanceTraveled += Time.deltaTime * 2f; // Assuming a speed of 5 units per second
            distanceText.text = "Distance: " + Mathf.RoundToInt(distanceTraveled) + "m";
        }
    }

    public void DecreaseHealth()
    {
        health--;
        if (health <= 0)
        {
            Debug.Log("Game Over");
            Death();
            // Handle game over logic here
        }
    }

    private void Death()
    {
        Debug.Log("Player has died");
        if(distanceTraveled > highScore)
        {
            highScore = distanceTraveled;
            highScoreText.text = highScore.ToString("0") + "m";
            PlayerPrefs.SetFloat("HighScore", distanceTraveled);
        }


        Destroy(Player);
        DeathScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
