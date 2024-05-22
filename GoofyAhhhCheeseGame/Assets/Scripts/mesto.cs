using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesto : MonoBehaviour
{
   [SerializeField] private int basehp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(basehp);
    }

    public int GetBaseHp() {
        return basehp;
    }

    public void SetBaseHp(int newHp) {
        basehp = newHp;
    }
}
