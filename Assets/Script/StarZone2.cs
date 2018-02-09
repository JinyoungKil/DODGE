using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarZone2 : MonoBehaviour {

    private AudioSource audioSource;
    public GameObject prefabImpact;
    public PlayerHP playerhp;
    public Score score;
    public GameObject score5;

    public float Interval = 1.0f;
    public float lastTime = 0;

    private void Start()
    {
        score5.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            //audioSource.Play();
            var impact = Instantiate(prefabImpact);
            impact.transform.position = other.transform.position;
            score.score += 5;
            score5.SetActive(true);
            StartCoroutine(Score5Job());
        }
    }

    private IEnumerator Score5Job()
    {
        yield return new WaitForSeconds(0.5f);
        score5.SetActive(false);
    }


}
