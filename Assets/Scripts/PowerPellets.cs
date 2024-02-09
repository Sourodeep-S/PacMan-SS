using UnityEngine;

public class PowerPellets : Pellets
{
  public float duration = 5f;

  protected override void Eat()
  {
    FindAnyObjectByType<GameManager>().PowerPelletEaten(this);
  }
}
