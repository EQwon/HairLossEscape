using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Text energyText;
    [SerializeField] private Text remainTime;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        energySlider.value = BoardManager.instance.MyEnergy;
        energyText.text = BoardManager.instance.MyEnergy.ToString("Energy : #0");

        remainTime.text = BoardManager.instance.NowTime.ToString("00.00 m");
    }

    public void Win()
    {
        Time.timeScale = 0;

        winPanel.SetActive(true);
    }

    public void Lose()
    {
        Time.timeScale = 0;
        remainTime.text = BoardManager.instance.NowTime.ToString("00.00 m");

        losePanel.SetActive(true);
    }

    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void StageSelect()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
