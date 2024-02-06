using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
  public float speed = 8f;
  public float speedMultiplier = 1f;
  public LayerMask obstacleLayer;
  public Vector2 initialDirection;

  public Rigidbody2D rigidBody { get; private set; }
  public Vector2 direction { get; private set; }
  public Vector2 nextDirection { get; private set; }
  public Vector3 startingPosition { get; private set; }

  private void Awake()
  {
    this.rigidBody = GetComponent<Rigidbody2D>();
    this.startingPosition = this.transform.position;
  }

  private void Start()
  {
    ResetState();
  }

  public void ResetState()
  {
    this.speedMultiplier = 1f;
    this.nextDirection = Vector2.zero;
    this.direction = this.initialDirection;
    this.transform.position = this.startingPosition;
    this.enabled = true;
    this.rigidBody.isKinematic = false;
  }

  private void Update()
  {
    if (this.nextDirection != Vector2.zero)
      SetDirection(this.nextDirection);
  }

  private void FixedUpdate()
  {
    Vector2 position = this.rigidBody.position;
    Vector2 translation = this.direction * speed * speedMultiplier * Time.fixedDeltaTime;

    this.rigidBody.MovePosition(position + translation);
  }

  public void SetDirection(Vector2 direction, bool forced = false)
  {
    if (forced || !Occupied(direction))
    {
      this.direction = direction;
      this.nextDirection = Vector2.zero;
    }
    else
    {
      this.nextDirection = direction;
    }
  }

  public bool Occupied(Vector2 direction)
  {
    RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0f, direction, 1.5f, this.obstacleLayer);
    return hit.collider != null;
  }

}