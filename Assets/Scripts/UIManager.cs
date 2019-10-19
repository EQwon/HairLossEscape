using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject losePanel;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Text remainTime;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        losePanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        energySlider.value = BoardManager.instance.MyEnergy;

        remainTime.text = BoardManager.instance.NowTime.ToString("#.00 m");
    }

    public void Lose()
    {
        Time.timeScale = 0;
        remainTime.text = BoardManager.instance.NowTime.ToString("#.00 m");

        losePanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void StageSelect()
    {
        SceneManager.LoadScene(1);
    }
}
