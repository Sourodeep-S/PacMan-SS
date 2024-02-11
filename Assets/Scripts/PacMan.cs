using UnityEngine;

public class PacMan : MonoBehaviour
{
  public MovementController movement;

  private void Awake()
  {
    movement = GetComponent<MovementController>();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.UpArrow))
      movement.SetDirection(Vector2.up);
    if (Input.GetKeyDown(KeyCode.LeftArrow))
      movement.SetDirection(Vector2.left);
    if (Input.GetKeyDown(KeyCode.DownArrow))
      movement.SetDirection(Vector2.down);
    if (Input.GetKeyDown(KeyCode.RightArrow))
      movement.SetDirection(Vector2.right);

    float angle = Mathf.Atan2(movement.direction.y, movement.direction.x) * Mathf.Rad2Deg;
    this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
  }

  public void ResetState()
  {
    this.movement.ResetState();
    this.gameObject.SetActive(true);
  }
}
