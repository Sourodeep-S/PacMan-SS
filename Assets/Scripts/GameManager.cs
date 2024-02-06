using UnityEngine;

public class GameManager : MonoBehaviour
{
  public Ghost[] ghosts;
  public PacMan pacman;
  public Transform pellets;

  public int score { get; private set; }
  public int lives { get; private set; }

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
    SetScore(this.score + ghost.points);
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
}