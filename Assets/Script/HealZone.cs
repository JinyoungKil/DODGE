using UnityEngine;

public class HealZone : MonoBehaviour {

    private float lastTime = 0;
    private float interval = 1.0f;

    public PlayerHP playerhp;
    //public AudioSource audioSource;

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "player")
        {
            if (Time.time - lastTime > interval)
            {
                playerhp.HealHp(3);
                lastTime = Time.time;
                //audioSource.Play();
                //var impact = Instantiate(prefabImpact);
                //impact.transform.position = other.transform.position;
            }
        }
    }
}
