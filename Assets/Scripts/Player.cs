using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deathEffect;

    private Quaternion effectRotation = Quaternion.Euler(-90, 0, 0);

    public void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, this.transform.position, effectRotation);
        Destroy(this.gameObject);
        Destroy(effect, 2f);
    }
}
