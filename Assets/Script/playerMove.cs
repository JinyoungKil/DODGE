using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed = 8;
    public DirPad dirPad;

    public GameObject rightTopSphere;
    public GameObject LeftBottomSphere;

    // Use this for initialization
    void Start() {
        Debug.Log("Start() called.");
    }

    // Update is called once per frame
    void Update() {
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

        Vector3 movePosition = transform.position;



        if (movePosition.x < LeftBottomSphere.transform.position.x + 0.5f)
        {
            movePosition.x = LeftBottomSphere.transform.position.x + 0.5f;
        }
        if(movePosition.z < LeftBottomSphere.transform.position.z + 0.5f)
        {
            movePosition.z = LeftBottomSphere.transform.position.z + 0.5f;
        }

        if (movePosition.x > rightTopSphere.transform.position.x - 0.5f)
        {
            movePosition.x = rightTopSphere.transform.position.x - 0.5f;
        }
        if (movePosition.z > rightTopSphere.transform.position.z - 0.5f)
        {
            movePosition.z = rightTopSphere.transform.position.z - 0.5f;
        }



        movePosition.z = Mathf.Clamp(movePosition.z, -50, 50);
        transform.position = movePosition;
    }
    

}
