using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class LevelBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool autoGenerate = false;
    [SerializeField] float standardDistance;

    [SerializeField] GameObject gate1_dynamic;
    [SerializeField] GameObject gate2_easy;
    [SerializeField] GameObject gate2_medium;
    [SerializeField] GameObject gate2_hard;
    [SerializeField] GameObject gate2_veryhard;
    [SerializeField] GameObject gate3_right_easy;
    [SerializeField] GameObject gate3_left_easy;
    [SerializeField] GameObject gate3_balance;
    [SerializeField] GameObject gate4_right_easy;
    [SerializeField] GameObject gate4_left_easy;
    [SerializeField] GameObject gate4_balance;
    [SerializeField] GameObject gate4_center_easy;

    [SerializeField] GameObject gate5;


    [SerializeField] GameObject staticSpike;
    [SerializeField] GameObject dynamicSpike;

    [SerializeField] GameObject collectAblePile;
    [SerializeField] GameObject collectAblePile2;
    [SerializeField] GameObject collectAblePile3;
    [SerializeField] GameObject collectAblePile4;

    [SerializeField] GameObject coinPack1;
    [SerializeField] GameObject coinPack2;
    [SerializeField] GameObject coinPack3;

    [SerializeField] public LevelObjects levelObjects;

    int[] validItems;
    int[] coinOnly = { 15, 16, 17 };
    int[] spikeOnly = { 13, 14 };
    int[] startItems = { 0, 1, 2, 3, 4, 5, 13, 14, 15, 16, 17 };
    int[] startItemsNoCoin = { 0, 1, 2, 3, 4, 5, 13, 14 };
    int[] all = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18,19,20,21 };
    int[] allNoCoin = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 18,19,20,21 };
    int[] allNoCoinNoGate = { 13, 14, 18, 19, 20, 21 };
    int[] allNoGate = { 13, 14, 15, 16, 17, 18, 19, 20, 21 };


    int continuesGate = 0;
    int continuesSpike = 0;
    int maxContinuesGate = 4;
    int maxContinuesSpike = 1;


    bool isGate(LevelObjectType objectType) {
        if (((int)objectType) <= 12) {
            return true;
        }
        return false;
    }

    void Start()
    {
        levelObjects = DataSaver.loadData<LevelObjects>("lvl" + PlayerPrefs.GetInt("lvl"));
        if (levelObjects == null) {
            levelObjects = new LevelObjects();
            levelObjects.levelObjects = new List<LevelObject>();
        }
        if (levelObjects.levelObjects.Count == 0 || levelObjects == null)
            {
            levelObjects.levelObjects = new List<LevelObject>();
                for (int i = 0; i < 12; i++)
                {
                    LevelObject levelObject = new LevelObject();
                    levelObject.zPosition = UnityEngine.Random.Range(i + 0.5f, i + 1) / 2;
                    Debug.Log(levelObject.zPosition);
                    levelObject.xPosition = UnityEngine.Random.Range(-2, 2);
                    if (i == 0)
                    {
                        validItems = startItems;
                        levelObject.type = (LevelObjectType)validItems[UnityEngine.Random.Range(0, validItems.Length)];

                    }
                    if (i > 0)
                    {


                        if (levelObjects.levelObjects[i - 1].type == (LevelObjectType.STATIC_SPIKE) ||
                            levelObjects.levelObjects[i - 1].type == (LevelObjectType.DYNAMIC_SPIKE))
                        {
                            validItems = all;
                            if (levelObjects.levelObjects[i - 1].type == (LevelObjectType.COIN_PACK_1) ||
                            levelObjects.levelObjects[i - 1].type == (LevelObjectType.COIN_PACK_2) ||
                            levelObjects.levelObjects[i - 1].type == (LevelObjectType.COIN_PACK_3))
                            {
                                validItems = allNoCoin;
                            }
                        }
                        else
                        {
                            if (levelObjects.levelObjects[i - 1].type == (LevelObjectType.COIN_PACK_1) ||
                           levelObjects.levelObjects[i - 1].type == (LevelObjectType.COIN_PACK_2) ||
                           levelObjects.levelObjects[i - 1].type == (LevelObjectType.COIN_PACK_3))
                            {
                                validItems = startItemsNoCoin;
                            }
                            else
                            {
                                validItems = startItems;
                            }
                        }
                    if (continuesGate >= maxContinuesGate) {
                        continuesGate = 0;

                        if (levelObjects.levelObjects[i - 1].type == (LevelObjectType.COIN_PACK_1) ||
                       levelObjects.levelObjects[i - 1].type == (LevelObjectType.COIN_PACK_2) ||
                       levelObjects.levelObjects[i - 1].type == (LevelObjectType.COIN_PACK_3))
                        {
                            validItems = allNoCoinNoGate;
                        }
                        else
                        {
                            validItems = allNoGate;
                        }
                    } 
                      levelObject.type = (LevelObjectType)validItems[UnityEngine.Random.Range(0, validItems.Length)];
                    if (isGate(levelObject.type)) {
                        continuesGate++;
                    }

                    }
                    levelObjects.levelObjects.Add( levelObject);

                }
                BuildLevel();


            }
            else
            {
                BuildLevel();

            }
        
        


    }

    // Update is called once per frame
    void Update()
    {

    }
    void BuildLevel() {
        
        DataSaver.saveData(levelObjects, "lvl" + PlayerPrefs.GetInt("lvl"));
        foreach (LevelObject levelObject in levelObjects.levelObjects)
        {
            switch (levelObject.type)
            {
                case LevelObjectType.GATE1_DYNAMIC:
                    Instantiate(gate1_dynamic, new Vector3(
                        levelObject.xPosition,
                        0.32f,
                        standardDistance * levelObject.zPosition),
                        levelObject.rotation).
                        transform.SetParent(gameObject.transform);
                    break;

                case LevelObjectType.GATE2_EASY:

                    Instantiate(gate2_easy, new Vector3(
                    levelObject.xPosition,
                    2.56f,
                    standardDistance * levelObject.zPosition),
                    levelObject.rotation).
                    transform.SetParent(gameObject.transform);

                    break;
                case LevelObjectType.GATE2_MEDIUM:
                    Instantiate(gate2_medium, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE2_HARD:
                    Instantiate(gate2_hard, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE2_VERYHARD:
                    Instantiate(gate2_veryhard, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE3_LEFT_EASY:
                    Instantiate(gate3_left_easy, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE3_RIGHT_EASY:
                    Instantiate(gate3_right_easy, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE3_BALANCE:
                    Instantiate(gate3_balance, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE4_LEFT_EASY:
                    Instantiate(gate4_left_easy, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE4_RIGHT_EASY:
                    Instantiate(gate4_right_easy, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE4_CENTER_EASY:
                    Instantiate(gate4_center_easy, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE4_BALANCE:
                    Instantiate(gate4_balance, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.GATE5_BALANCE:
                    Instantiate(gate5, new Vector3(
                       levelObject.xPosition,
                       2.56f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.STATIC_SPIKE:
                    Instantiate(staticSpike, new Vector3(
                       levelObject.xPosition,
                       0.32f,
                       standardDistance * levelObject.zPosition),
                       Quaternion.Euler(0, -90, 0)).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.DYNAMIC_SPIKE:
                    Instantiate(dynamicSpike, new Vector3(
                       levelObject.xPosition,
                       0.32f,
                       standardDistance * levelObject.zPosition),
                       levelObject.rotation).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.COLLECTABLE_PILE:
                    Instantiate(collectAblePile, new Vector3(
                       levelObject.xPosition,
                       0.6f,
                       standardDistance * levelObject.zPosition),
                       Quaternion.Euler(0, 0, 0)).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.COLLECTABLE_PILE2:
                    Instantiate(collectAblePile2, new Vector3(
                       levelObject.xPosition,
                       0.6f,
                       standardDistance * levelObject.zPosition),
                       Quaternion.Euler(0, 0, 0)).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.COLLECTABLE_PILE3:
                    Instantiate(collectAblePile3, new Vector3(
                       levelObject.xPosition,
                       0.6f,
                       standardDistance * levelObject.zPosition),
                       Quaternion.Euler(0, 0, 0)).
                       transform.SetParent(gameObject.transform);
                    break;
                case LevelObjectType.COLLECTABLE_PILE4:
                    Instantiate(collectAblePile4, new Vector3(
                       levelObject.xPosition,
                       0.6f,
                       standardDistance * levelObject.zPosition),
                       Quaternion.Euler(0, 0, 0)).
                       transform.SetParent(gameObject.transform);
                    break;

                case LevelObjectType.COIN_PACK_1:
                    Instantiate(coinPack1, new Vector3(
                   levelObject.xPosition,
                   1.43f,
                   standardDistance * levelObject.zPosition),
                   levelObject.rotation).
                   transform.SetParent(gameObject.transform);
                    break;

                case LevelObjectType.COIN_PACK_2:
                    Instantiate(coinPack2, new Vector3(
                   levelObject.xPosition,
                   1.43f,
                   standardDistance * levelObject.zPosition),
                   levelObject.rotation).
                   transform.SetParent(gameObject.transform);
                    break;

                case LevelObjectType.COIN_PACK_3:
                    Instantiate(coinPack3, new Vector3(
                   levelObject.xPosition,
                   1.43f,
                   standardDistance * levelObject.zPosition),
                   levelObject.rotation).
                   transform.SetParent(gameObject.transform);
                    break;


                default:
                    break;
            }
        }
    }
    [Serializable]
    public class LevelObject
    {
        public float zPosition;
        public float xPosition;
        public Quaternion rotation;
        public LevelObjectType type;

    }
    [Serializable]
    public class LevelObjects
    {
        public List<LevelObject> levelObjects;

    }

}

public enum LevelObjectType
{
    GATE2_EASY, GATE2_MEDIUM, GATE2_HARD, GATE2_VERYHARD,
    GATE3_LEFT_EASY, GATE3_RIGHT_EASY, GATE3_BALANCE,
    GATE4_LEFT_EASY, GATE4_RIGHT_EASY, GATE4_CENTER_EASY, GATE4_BALANCE,
    GATE5_BALANCE, GATE1_DYNAMIC,
    STATIC_SPIKE, DYNAMIC_SPIKE,
    COIN_PACK_1, COIN_PACK_2, COIN_PACK_3,
    COLLECTABLE_PILE,COLLECTABLE_PILE2, COLLECTABLE_PILE3, COLLECTABLE_PILE4,




}
