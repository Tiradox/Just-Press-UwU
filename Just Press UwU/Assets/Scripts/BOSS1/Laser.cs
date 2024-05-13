using UnityEngine;

public class Laser : MonoBehaviour
{
    private bool b = true;

    public void Bah()
    {
        ControllerOfShake.Instance.InstShakeCamera(6, 1.5f);
    }
    public void DestroyLaser()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && b)
        {
            b = false;
            collision.gameObject.GetComponent<PlayerSet>().TakeDamage(3);
        }
    }
}
