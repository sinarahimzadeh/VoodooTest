using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class SizeManager : MonoBehaviour
{
    public static SizeManager instace;
    public Transform prefab;
    public float cutForce;
    private GameObject cylender;
    public float shrinkCm;
    public Vector3 globalPositionOfContact, hitLocation;
    public float xScale, currentScale, shrinkSide;
    //how fast it grows 
    public float growthRate, shrinkRate;
    //how much the pile increases each time
    public float maxInc, relocateSpeed;

    //determines wether the pile should grow or shrink
    public bool grow, shrink, wtf;
    // Start is called before the first frame update
    void Start()
    {
        instace = this;
        xScale = gameObject.transform.localScale.x;
        currentScale = xScale;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "spike")
        {

            Destroy(
                collision.
                transform.
                gameObject.
                GetComponent<Collider>());

            hitLocation =
                      collision.
                      transform.
                      position;

            globalPositionOfContact =
                      collision
                      .contacts[0]
                      .point;

            if (transform.position.x <= globalPositionOfContact.x)
            {
                shrinkCm =
                            gameObject.transform.position.x +
                            gameObject.transform.localScale.x -
                            globalPositionOfContact.x;

                shrinkSide = -1;
            }
            else
            {
                shrinkCm = Math.Abs(
                    gameObject.transform.position.x -
                    gameObject.transform.localScale.x -
                    globalPositionOfContact.x);

                shrinkSide = 1;
            }
            Shrink();
        }
    }

    void FixedUpdate()
    {
        if (grow)
        {
            if (xScale - currentScale <= maxInc)
            {
                gameObject.transform.localScale = new Vector3(
                    xScale,
                    transform.localScale.y,
                    transform.localScale.z);

                xScale += growthRate;
            }
            else
            {
                grow = false;
                currentScale = xScale;
            }

        }
    }

    public void Grow()
    {
        //grow = true;

        transform.DOScaleX(transform.localScale.x + growthRate, 0.3f);
    }

    public void Shrink()
    {
        gameObject.GetComponent<ReCenter>().DoReCenter();

        gameObject.transform.localScale = new Vector3(
            transform.localScale.x - (shrinkCm / 2),
            transform.localScale.y,
            transform.localScale.z);

        gameObject.transform.position = new Vector3(
            transform.position.x + shrinkCm / 2 * shrinkSide,
            transform.position.y,
            transform.position.z);

        if (shrinkSide == -1) cylender = Instantiate(
            prefab,
            new Vector3(
                hitLocation.x + shrinkCm / 2,
                hitLocation.y,
                hitLocation.z),
            Quaternion.Euler(
                0f,
                0f,
                90f)).gameObject;

        if (shrinkSide == 1) cylender = Instantiate(
            prefab,
            new Vector3(
                hitLocation.x - shrinkCm / 2,
                hitLocation.y,
                hitLocation.z),
            Quaternion.Euler(0f,
            0f,
            90f)).gameObject;

        cylender.transform.SetParent(
            GameObject.Find("Level").transform);

        cylender.transform.localScale = new Vector3(
            transform.localScale.y,
            shrinkCm / 2,
            transform.localScale.z);

        cylender.GetComponent<Rigidbody>().AddForce(
            new Vector3(
                -shrinkSide / 4,
                0.2f,
                0.7f) * cutForce,
            ForceMode.Impulse);

    }

}
