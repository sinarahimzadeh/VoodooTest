using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public bool isTestingOnDesktop = false;
    public bool move, lose, win,feverMode;
    public CameraFollow cameraFollow;
    public ForwardMovement forwardMovement;

    public float speed, feverModeSpeed, initialSpeed;
    [SerializeField]
    private GameObject
        panel,
        failedImage,
        winImage;
    public static GameManager shared;
    [SerializeField] private GameObject fireparticle1, fireparticle2;
    [SerializeField] HorizontalMovement horizontalMovement;
    [SerializeField] TMPro.TextMeshProUGUI coinText;
    public int collectedCoin = 0;
    public GameObject uiCoin;
    public ParticleSystem uiCoinParticle;
    public bool isPolicPulling = false;
    public bool isMovingOut = false;

    // Start is called before the first frame update
    void Start()
    {
        shared = this;
        initialSpeed = speed;
    }
    public void MoveOut() {
        speed = 7;
        move = true;
        cameraFollow.enabled = false;
        forwardMovement.enabled = true;
        isMovingOut = true;
    }

    public void Move()
    {
        move = true;
    }
    public void CoinCollected() {
        collectedCoin++;
        coinText.text = collectedCoin.ToString();
        uiCoin.transform.DOScale(new Vector3(60,50,60), 0.2f).SetLoops(2, LoopType.Yoyo);
        uiCoinParticle.Play();
    }
    public void Lose()
    {
        NormalMode();

        move = false;
        lose = true;
        failedImage.SetActive(true);
        horizontalMovement.enabled = false;
        //Invoke("resetPanel", 1);
    }

    public void Win()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings)
        {
            move = false;
            winImage.SetActive(true);
            win = true;
            panel.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
        }


    }

    void resetPanel()
    {
        panel.SetActive(true);

    }

    public void Reset()
    {

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
 public   void FeverMove()
    {
        feverMode = true; 
        speed = feverModeSpeed;
        fireparticle1.SetActive(true);
        fireparticle2.SetActive(true);
        // GameManager.shared.speed
    }

   public void NormalMode()
    {
        feverMode = false;
         speed =initialSpeed;
        fireparticle1.SetActive(false);
        fireparticle2.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !lose && !win)
        {
            Move();
        }
    }
}
