using UnityEngine;

public class Ghost : MonoBehaviour
{
  public int points = 200;
  public Transform target;
  public GhostBehaviour initialBehaviour;

  public MovementController movement { get; private set; }
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

  private void Start()
  {
    ResetState();
  }

  public void ResetState()
  {
    this.movement.ResetState();
    this.gameObject.SetActive(true);

    this.chase.Disable();
    this.frightened.Disable();
    this.scatter.Enable();

    if (this.home != this.initialBehaviour)
      this.home.Disable();

    if (this.initialBehaviour != null)
    {
      this.initialBehaviour.Enable();
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.layer == LayerMask.NameToLayer("PacMan"))
    {
      if (this.frightened.enabled)
        FindAnyObjectByType<GameManager>().GhostEaten(this);
      else
        FindAnyObjectByType<GameManager>().PacmanEaten();
    }
  }
}
