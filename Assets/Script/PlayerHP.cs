using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

    public float maxHP = 100;

    //HP_Bar
    private float currentHP = 0;
    private float calc_HP = 0;
    public GameObject hpBar;

    //HP_Text
    public Text hpText;

    public GameObject enemyGroup;

    public bool over = false;
    public AudioSource audioSource;


    private float lastTime = 0;
    private float interval = 4.0f;

    public GameObject prefabImpact;
    public GameObject player;

    public GameObject backButton;

    public Score score;

    public GameObject gameOver;

    private void Start()
    {
        currentHP = maxHP;
        UpdateHp();
        backButton.SetActive(false);
    }

    void Update()
    {
        if (Time.time - lastTime > interval)
        {
            //HealHp(5);
            lastTime = Time.time;
        }

    }

    public void HealHp(int amount)
    {
        currentHP += amount;
        calc_HP = currentHP / maxHP;

        if (currentHP >= 100)
        {
            currentHP = 100;
            calc_HP = 1;
        }

        setHPBar(calc_HP);
        UpdateHp();
    }

    public void DamageHp(int amount)
    {
        currentHP -= amount;
        calc_HP = currentHP / maxHP;

        if (currentHP <= 0)
        {

            over = true;
            gameOver.SetActive(true);
            currentHP = 0;
            calc_HP = 0;
            backButton.SetActive(true);

            score.BestScore();
        }

        setHPBar(calc_HP);
        UpdateHp();
    }

    public void UpdateHp()
    {
        string str_hp = currentHP + "/" + maxHP;
        hpText.text = str_hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            DamageHp(10);

            if (currentHP <= 0)
            {
                DestroyAllChildren(enemyGroup);
            }
            else
            {
                Destroy(other.gameObject);
                audioSource.Play();
                var impact = Instantiate(prefabImpact);
                impact.transform.position = player.transform.position;
            }
            UpdateHp();
        }
        
    }

    private void DestroyAllChildren(GameObject gameObject)
    {

        foreach(var child in gameObject.transform.Cast<Transform>().ToArray())
        {
            Destroy(child.gameObject);
        }
    }

    public void setHPBar(float myHP)
    {
        var dy = hpBar.transform.localScale.y;
        var dz = hpBar.transform.localScale.z;
        //myHP value
        hpBar.transform.localScale = new Vector3(myHP, dy, dz);
    }
}



//1. GameObject이름을오 구분
//if(other.gameObject.name == "Enemy(Clone)")
//2. 컴포넌트가 붙어있는지의 여부로 구분
//if(other.GetComponent<EnemyMove>())

//3. 태그로 구분
//enemy와 player 충돌되면 enemy 사라짐



// transform.childCount
// x = Random.Range(0, )
//transform.GetChild(0).gameObject
