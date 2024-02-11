using UnityEngine;
using System.Collections;

public class Ghost_Home : GhostBehaviour
{
  public Transform inside;
  public Transform outside;

  private void OnEnable()
  {
    StopAllCoroutines();
  }

  private void OnDisable()
  {
    if (this.gameObject.activeSelf)
      StartCoroutine(ExitTransition());
  }

  private IEnumerator ExitTransition()
  {
    this.ghost.movement.SetDirection(Vector2.up, true);
    this.ghost.movement.rigidBody.isKinematic = true;
    this.ghost.movement.enabled = false;

    Vector3 position = this.transform.position;
    float duration = 0.5f;
    float elapsed = 0f;

    while (elapsed < duration)
    {
      Vector3 newPosition = Vector3.Lerp(this.transform.position, this.inside.position, elapsed / duration);
      newPosition.z = position.z;
      this.transform.position = newPosition;
      elapsed += Time.deltaTime;
      yield return null;
    }

    elapsed = 0f;

    while (elapsed < duration)
    {
      Vector3 newPosition = Vector3.Lerp(this.inside.position, this.outside.position, elapsed / duration);
      newPosition.z = position.z;
      this.transform.position = newPosition;
      elapsed += Time.deltaTime;
      yield return null;
    }

    this.ghost.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1f : 1f, 0f), true);
    this.ghost.movement.rigidBody.isKinematic = false;
    this.ghost.movement.enabled = true;
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (this.enabled && other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
    {
      this.ghost.movement.SetDirection(-this.ghost.movement.direction);
    }
  }
}
