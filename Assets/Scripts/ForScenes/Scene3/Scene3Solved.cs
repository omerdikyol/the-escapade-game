using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scene3Solved : MonoBehaviour
{
    [SerializeField] private GameObject shield1;
    [SerializeField] private GameObject shield2;
    [SerializeField] private GameObject shield3;
    [SerializeField] private GameObject ladder;
    [SerializeField] private UnityEvent unityEvent;


    public bool move1 = false;
    public bool move2 = false;
    private float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(move1)
        {
            shield1.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            shield3.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

    }

    public void StartAnimation()
    {
        StartCoroutine(CountSeconds());
    }

    IEnumerator CountSeconds()
    {
        move1 = true;
        ladder.SetActive(true);

        yield return new WaitForSeconds(1.8f);

        move1 = false;
        unityEvent.Invoke();
        Destroy(gameObject);
    }


}
