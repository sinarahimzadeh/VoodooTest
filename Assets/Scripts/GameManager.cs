using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public bool isTestingOnDesktop = false;
    public bool move, lose, win,feverMode,boe;
    public CameraFollow cameraFollow;
    public Camera camera;
    [SerializeField] private float force;
    public GameObject endSaw1;
    public ForwardMovement forwardMovement;

    public float speed, feverModeSpeed, initialSpeed;
    [SerializeField]
    private GameObject
        panel,
        failedImage,
        winImage;
    public static GameManager shared;
    [SerializeField] private GameObject fireparticle1, fireparticle2,resetButton,Pile,BreakablePile;
    [SerializeField] HorizontalMovement horizontalMovement;
    [SerializeField] TMPro.TextMeshProUGUI coinText;
    [SerializeField] private Transform BreakablePilePrefab;
    
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
        speed = 10;
        move = true;
        cameraFollow.enabled = false;
        forwardMovement.enabled = true;
        isMovingOut = true;
    }

    public void Move()
    {
        move = true;
        TinySauce.OnGameStarted(SceneManager.GetActiveScene().buildIndex.ToString());


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
        camera.cullingMask = LayerMask.GetMask("Default");


        Invoke("resetPanel", 1);
    }

    public void Win()
    {
        PlayerPrefs.SetInt("lvl", PlayerPrefs.GetInt("lvl") + 1);
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings)
        {
            move = false;
            winImage.SetActive(true);
            win = true;
            panel.SetActive(true);
            endSaw1.SetActive(true);
            BreakablePile = Instantiate(BreakablePilePrefab, Pile.transform.position, quaternion.EulerXYZ(0,90,0)).gameObject;
            BreakablePile.transform.localScale= new Vector3(BreakablePile.transform.localScale.x,BreakablePile.transform.localScale.y,Pile.transform.localScale.x/10);
            BreakablePile.transform.SetParent(GameObject.Find("Level").transform);
            foreach (Transform i in BreakablePile.transform)
            {
                i.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-force,force),-force,Random.Range(0,force*2f)));
            }
            Pile.SetActive(false);

        }
        else
        {
            endSaw1.SetActive(true);

            move = false;
            winImage.SetActive(true);
            win = true;
            panel.SetActive(true);
            resetButton.SetActive(false);
            BreakablePile = Instantiate(BreakablePilePrefab, Pile.transform.position, quaternion.EulerXYZ(0,90,0)).gameObject;
            BreakablePile.transform.localScale= new Vector3(BreakablePile.transform.localScale.x,BreakablePile.transform.localScale.y,Pile.transform.localScale.x/10);
            BreakablePile.transform.SetParent(GameObject.Find("Level").transform);
            foreach (Transform i in BreakablePile.transform)
            {
                i.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-force*2,force*2),-force,Random.Range(0,force*2f)));
            }
            Pile.SetActive(false);
            Invoke("NextLevel",3);
       


        }


    }

 public   void NextLevel()
    {
        TinySauce.OnGameFinished(true, collectedCoin, SceneManager.GetActiveScene().buildIndex.ToString()) ;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);

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
    // Update is called once per framelk
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !lose && !win)
        {
         Move();
       
        }
    }
}
