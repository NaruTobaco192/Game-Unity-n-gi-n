using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public Image SettingImg;
    public Image BestScoreImg;
    public Image CreditImg;
    public Image VolumeImg;
    public Text scoreText;
    public float bestScore;
    public AudioSource myAudio;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bestScore = PlayerPrefs.GetFloat("MyScore");
        scoreText.text = bestScore.ToString();

        myAudio.volume=volumeSlider.value;
    }

    public void Setting()
    {
        SettingImg.gameObject.SetActive(true);
    }

    public void Exit()
    {
        SettingImg.gameObject.SetActive(false);
    }

    public void BestScore()
    {
        BestScoreImg.gameObject.SetActive(true);
    }

    public void ExitBestScore()
    {
        BestScoreImg.gameObject.SetActive(false);
    }

    public void Credit()
    {
        CreditImg.gameObject.SetActive(true);
    }

    public void ExitCredit()
    {
        CreditImg.gameObject.SetActive(false);
    }

    public void Volume()
    {
        VolumeImg.gameObject.SetActive(true);
    }

    public void ExitVolume()
    {
        VolumeImg.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
