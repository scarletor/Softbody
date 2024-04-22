using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<TouchablePoint> touchablePointS;


    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        touchablePointS = transform.GetComponentsInChildren<TouchablePoint>(true).ToList();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
