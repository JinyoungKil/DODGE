using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float speed = 2.0f;
    public GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update () {
        //player.transform.position을 활용해서 dir을 계산
        Vector3 diff = player.transform.position - transform.position;
        Vector3 dir = diff.normalized;

        transform.Translate(dir * speed * Time.deltaTime);
	}
}
