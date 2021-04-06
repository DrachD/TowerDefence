using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] Text waveLabel;
    [SerializeField] Text gameOverLabel;
    [SerializeField] GameObject[] nextWaveLabels;
    private int wave;
    public int Wave
    {
        get => wave;
        set
        {
            wave = value;
            if (!gameOver)
            {
                for (int i = 0; i < nextWaveLabels.Length; i++)
                {
                    nextWaveLabels[i].GetComponent<Animator>().SetBool("NextWave", true);
                }
            }
            waveLabel.text = "WAVE: " + wave+1;
        }
    }
    [SerializeField] Text healthLabel;
    private int health;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            healthLabel.text = "HEALTH: " + health;
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                gameOverLabel.GetComponent<Animator>().SetBool("GameOver", true);
                
            }
        }
    }
    [SerializeField] Text goldLabel;
    private int gold;
    public int Gold
    {
        get => gold;
        set 
        {
            gold = value;
            goldLabel.text = "GOLD: " + gold;
        }
    }
    public bool gameOver = false;

    private void Start()
    {
        Gold = 1000;
        Health = 5;
        Wave = 0;
    }
}
