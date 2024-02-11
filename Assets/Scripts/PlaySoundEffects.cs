using UnityEngine;

public class PlaySoundEffects : MonoBehaviour
{
  public AudioSource src;
  public AudioClip pacmanDeath, fruitEaten, gameStart, ghostEaten, intermission, lifeLost, pelletEaten, powerPelletEaten;

  public void PlayPacmanDeathSound()
  {
    src.clip = pacmanDeath;
    src.Play();
  }
  public void PlayFruitEatenSound()
  {
    src.clip = fruitEaten;
    src.Play();
  }
  public void PlayGameStartSound()
  {
    src.clip = gameStart;
    src.Play();
  }
  public void PlayGhostEatenSound()
  {
    src.clip = ghostEaten;
    src.Play();
  }
  public void PlayIntermissionSound()
  {
    src.clip = intermission;
    src.Play();
  }
  public void PlayLifeLostSound()
  {
    src.clip = lifeLost;
    src.Play();
  }
  public void PlayPelletEatenSound()
  {
    src.clip = pelletEaten;
    src.Play();
  }
  public void PlayPowerPelletEatenSound()
  {
    src.clip = powerPelletEaten;
    src.Play();
  }

}
