using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSpritesRenderer : MonoBehaviour
{
  public SpriteRenderer spriteRenderer { get; private set; }
  public Sprite[] sprites;
  public int frame { get; private set; }
  public float animationTime = 0.25f;

  public bool loop = true;

  private void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  private void Start()
  {
    InvokeRepeating(nameof(Advance), animationTime, animationTime);
  }

  private void Advance()
  {
    if (!this.spriteRenderer.enabled)
      return;

    frame++;

    if (this.frame >= sprites.Length && this.loop)
      frame = 0;

    if (this.frame >= 0 && this.frame < sprites.Length)
    {
      this.spriteRenderer.sprite = this.sprites[frame];
    }
  }

  public void Restart()
  {
    this.frame = -1;
    Advance();
  }
}
