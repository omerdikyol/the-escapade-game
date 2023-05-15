using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWardrobe : MonoBehaviour
{
    public bool move = false;
    private float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void Move()
    {
        StartCoroutine(CountSeconds());
    }

    IEnumerator CountSeconds()
    {
        move = true;

        yield return new WaitForSeconds(2);

        move = false;
    }
}
