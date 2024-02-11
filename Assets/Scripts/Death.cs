using UnityEngine;

public class Death : MonoBehaviour
{
  private AnimatedSpritesRenderer animatedSpritesRenderer;

  private void Awake()
  {
    animatedSpritesRenderer = GetComponent<AnimatedSpritesRenderer>();
  }

  private void OnEnable()
  {
    animatedSpritesRenderer.frame = 0;
  }
}
