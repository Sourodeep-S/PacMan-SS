using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  public Ghost[] ghosts;
  public PacMan pacman;
  public Transform pellets;
  public Transform death;

  public int score { get; private set; }
  public int lives { get; private set; }
  public int ghostMultiplier { get; private set; } = 1;

  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI livesText;
  public TextMeshProUGUI gameOverText;

  private PlaySoundEffects sound;
  private MovementController movement;

  private void Awake()
  {
    sound = GetComponent<PlaySoundEffects>();
  }

  private void Start()
  {
    NewGame();
  }

  private void NewGame()
  {
    sound.PlayGameStartSound();
    gameOverText.gameObject.SetActive(false);

    SetScore(0);
    SetLives(3);
    NewRound();
  }

  private void Update()
  {
    if (this.lives <= 0 && Input.anyKeyDown)
      NewGame();
  }

  private void NewRound()
  {
    foreach (Transform pellet in this.pellets)
    {
      pellet.gameObject.SetActive(true);
    }

    ResetState();
  }

  private void ResetState()
  {
    foreach (Ghost ghost in this.ghosts)
    {
      ghost.ResetState();
    }

    this.death.gameObject.SetActive(false);
    this.pacman.ResetState();
  }

  private void GameOver()
  {
    sound.PlayPacmanDeathSound();

    foreach (Ghost ghost in this.ghosts)
    {
      ghost.gameObject.SetActive(false);
    }

    this.pacman.gameObject.SetActive(false);
    gameOverText.gameObject.SetActive(true);
  }

  private void SetScore(int score)
  {
    this.score = score;
    scoreText.text = this.score.ToString("D4");
  }

  private void SetLives(int lives)
  {
    this.lives = lives;
    livesText.text = this.lives.ToString();
  }

  public void GhostEaten(Ghost ghost)
  {
    sound.PlayGhostEatenSound();
    int points = ghost.points * this.ghostMultiplier;
    SetScore(this.score + points);
    this.ghostMultiplier++;
  }

  public void PacmanEaten()
  {
    this.death.transform.position = this.pacman.transform.position;
    this.pacman.gameObject.SetActive(false);
    this.death.gameObject.SetActive(true);
    SetLives(this.lives - 1);

    if (this.lives > 0)
    {
      sound.PlayLifeLostSound();
      Invoke(nameof(ResetState), 3f);
    }
    else
      GameOver();
  }

  public void PelletEaten(Pellets pellet)
  {
    //sound.PlayPelletEatenSound();
    pellet.gameObject.SetActive(false);
    SetScore(this.score + pellet.points);

    if (!HasRemainingPellets())
    {
      sound.PlayIntermissionSound();
      this.pacman.gameObject.SetActive(false);
      Invoke(nameof(NewRound), 6f);
    }

  }

  public void PowerPelletEaten(PowerPellets powerPellet)
  {
    sound.PlayPowerPelletEatenSound();
    foreach (Ghost ghost in this.ghosts)
    {
      ghost.frightened.Enable(powerPellet.duration);
    }

    PelletEaten(powerPellet);
    CancelInvoke();
    Invoke(nameof(ResetPowerPellet), powerPellet.duration);
  }

  private bool HasRemainingPellets()
  {
    foreach (Transform pellet in this.pellets)
    {
      if (pellet.gameObject.activeSelf)
        return true;
    }
    return false;
  }

  private void ResetPowerPellet()
  {
    this.ghostMultiplier = 1;
  }
}
