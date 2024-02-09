using UnityEngine;

public class Ghost : MonoBehaviour
{
  public int points = 200;
  public Transform target;

  public MovementController movement { get; private set; }
  public GhostBehaviour initialBehaviour { get; private set; }
  public Ghost_Chase chase { get; private set; }
  public Ghost_Frightened frightened { get; private set; }
  public Ghost_Home home { get; private set; }
  public Ghost_Scatter scatter { get; private set; }

  private void Awake()
  {
    this.movement = GetComponent<MovementController>();

    this.chase = GetComponent<Ghost_Chase>();
    this.home = GetComponent<Ghost_Home>();
    this.frightened = GetComponent<Ghost_Frightened>();
    this.scatter = GetComponent<Ghost_Scatter>();
  }
}
