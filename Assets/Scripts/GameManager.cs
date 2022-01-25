using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public ParticleSystem deadParticle;
    public GameObject restartText;
    bool gameOver;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (gameOver == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            gameOver = false;
            restartText.SetActive(false);
        }
    }

    public void SetParticleColor(ParticleSystem particleSystem, Color32 color)
    {
        ParticleSystem.MainModule deadMain = particleSystem.main;
        ParticleSystem.MinMaxGradient deadColor = deadMain.startColor;

        deadColor.mode = ParticleSystemGradientMode.Color;
        deadColor.color = color;
        deadMain.startColor = deadColor;
    }

    public void PlayDieEffects()
    {
        //Set Particle
        deadParticle.transform.position = Player.Instance.transform.position;
        SetParticleColor(deadParticle, Player.Instance.currentColor);
        deadParticle.Play();

        restartText.SetActive(true);

        gameOver = true;
    }
}
