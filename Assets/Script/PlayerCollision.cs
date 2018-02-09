using UnityEngine;

public class PlayerCollision : MonoBehaviour {
   
    PlayerHP playerHP;
  

    private void OnTriggerEnter(Collider other)
    {
        playerHP.maxHP -= 10;
        Destroy(other.gameObject);
    }



    
}
