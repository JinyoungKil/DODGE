using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    //sound파일
    public AudioSource audioSource;
    public GameObject hpPanal;
    public Score score_script;

    //public Text bestScore; //누르면 숫자가 증가하는 버튼의 TEXT  

    public void OpenMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenSplashScene()
    {
        SceneManager.LoadScene("Splash");
    }

    public void ToggleHpPanal()
    {
        hpPanal.SetActive(hpPanal.activeSelf == false);
    }

}
