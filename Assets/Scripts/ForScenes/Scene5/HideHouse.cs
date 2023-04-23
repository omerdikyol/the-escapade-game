using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHouse : MonoBehaviour
{
    public GameObject house;
    public GameObject ladder;

    public bool ladderSolved = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            house.SetActive(false);
            if (ladder.activeSelf == true)
            {
                ladder.SetActive(false);
                ladderSolved = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            house.SetActive(true);
            if (ladderSolved == true)
            {
                ladder.SetActive(true);
            }
        }
    }
}
