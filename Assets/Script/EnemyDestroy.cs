using UnityEngine;

public class EnemyDestroy : MonoBehaviour {
    private float lastTime = 0;
    private float interval = 4.0f;

    public GameObject enemyGroup;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        int enemyCount = transform.childCount;
        int i = Random.Range(0, enemyCount);

        if(Time.time - lastTime > interval && enemyCount != 0)
        {
            Destroy(transform.GetChild(i).gameObject);
            lastTime = Time.time;
        }
		
	}
}
