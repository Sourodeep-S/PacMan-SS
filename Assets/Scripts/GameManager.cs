using UnityEngine;

public class GameManager : MonoBehaviour
{
  public Ghost[] ghosts;
  public PacMan pacman;
  public Transform pellets;

  public int score { get; private set; }
  public int lives { get; private set; }
  public int ghostMultiplier { get; private set; } = 1;

  private void Start()
  {
    NewGame();
  }

  private void NewGame()
  {
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
      ghost.gameObject.SetActive(true);
    }

    this.pacman.gameObject.SetActive(true);
    this.pacman.transform.position = 0.83f * Vector3.right - 7.2f * Vector3.up - 5f * Vector3.forward;
  }

  private void GameOver()
  {
    foreach (Ghost ghost in this.ghosts)
    {
      ghost.gameObject.SetActive(false);
    }

    this.pacman.gameObject.SetActive(false);
  }

  private void SetScore(int score)
  {
    this.score = score;
  }

  private void SetLives(int lives)
  {
    this.lives = lives;
  }

  private void GhostEaten(Ghost ghost)
  {
    int points = ghost.points * this.ghostMultiplier;
    SetScore(this.score + points);
    this.ghostMultiplier++;
  }

  private void PacmanEaten()
  {
    this.pacman.gameObject.SetActive(false);
    SetLives(this.lives - 1);

    if (this.lives > 0)
      Invoke(nameof(ResetState), 3f);
    else
      GameOver();
  }

  public void PelletEaten(Pellets pellet)
  {
    pellet.gameObject.SetActive(false);
    SetScore(this.score + pellet.points);

    if (!HasRemainingPellets())
    {
      this.pacman.gameObject.SetActive(false);
      Invoke(nameof(NewRound), 3f);
    }

  }

  public void PowerPelletEaten(PowerPellets powerPellet)
  {
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
