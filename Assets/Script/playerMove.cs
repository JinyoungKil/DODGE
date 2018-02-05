using UnityEngine;

public class playerMove : MonoBehaviour {
    public float speed = 8;
    public dirPad dirPad;

	// Use this for initialization
	void Start () {
        Debug.Log("Start() called.");
	}
	
	// Update is called once per frame
	void Update () {
        if (dirPad.dragging)
        {
            Vector2 dn = dirPad.dir.normalized * Time.deltaTime * speed;
            transform.Translate(new Vector3(dn.x, 0, dn.y));
        }
        else
        {
            Debug.LogFormat("Time.deltaTime = {0}", Time.deltaTime);
            var dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var dz = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Translate(new Vector3(dx, 0, dz));
        }
    }
}
