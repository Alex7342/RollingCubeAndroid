using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject destroyEffect;

    private Quaternion effectRotation = Quaternion.Euler(-90, 0, 0);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            PlayerStats.score++;
            DestroyMeteor();
        }

        if (collision.collider.tag == "Player")
        {
            PlayerStats.lives--;
            DestroyMeteor();
        }
    }

    private void DestroyMeteor()
    {
        Debug.Log("Meteor destroyed.");

        GameObject effect = (GameObject)Instantiate(destroyEffect, this.transform.position, effectRotation);
        Destroy(this.gameObject);
        Destroy(effect, 2f);
    }
}
