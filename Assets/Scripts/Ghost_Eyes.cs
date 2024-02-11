using UnityEngine;

public class Ghost_Eyes : MonoBehaviour
{
  public SpriteRenderer spriteRenderer { get; private set; }
  public MovementController movement { get; private set; }

  public Sprite up;
  public Sprite down;
  public Sprite left;
  public Sprite right;

  private void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    movement = GetComponentInParent<MovementController>();
  }

  private void Update()
  {
    if (this.movement.direction == Vector2.up)
      this.spriteRenderer.sprite = this.up;
    if (this.movement.direction == Vector2.down)
      this.spriteRenderer.sprite = this.down;
    if (this.movement.direction == Vector2.left)
      this.spriteRenderer.sprite = this.left;
    if (this.movement.direction == Vector2.right)
      this.spriteRenderer.sprite = this.right;
  }
}
