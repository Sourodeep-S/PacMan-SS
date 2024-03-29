using UnityEngine;

[RequireComponent(typeof(Ghost))]
public abstract class GhostBehaviour : MonoBehaviour
{
  public float duration;

  public Ghost ghost { get; private set; }

  private void Awake()
  {
    this.ghost = GetComponent<Ghost>();
    this.enabled = false;
  }

  public virtual void Enable()
  {
    Enable(this.duration);
  }

  public virtual void Enable(float duration)
  {
    this.enabled = true;
    CancelInvoke();
    Invoke(nameof(Disable), duration);
  }


  public virtual void Disable()
  {
    this.enabled = false;
    CancelInvoke();
  }

}
