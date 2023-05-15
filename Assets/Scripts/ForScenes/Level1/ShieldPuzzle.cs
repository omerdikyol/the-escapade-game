using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShieldPuzzle : MonoBehaviour
{
    [SerializeField] PutShield space1;
    [SerializeField] PutShield space2;
    [SerializeField] PutShield space3;

    [SerializeField] UnityEvent unityEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string shield1 = space1.GetCurrentShield();
        string shield2 = space2.GetCurrentShield();
        string shield3 = space3.GetCurrentShield();

        if(shield1 == "dragon" && shield2 == "shield" && shield3 == "sword")
        {
            unityEvent.Invoke();
        }
    }
}
