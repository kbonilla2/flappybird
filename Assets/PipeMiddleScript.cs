using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        //when new pipe spawns, it will look through the heirarchy for a game object tagged "logic" and will look throguh
        //its components for a script "logicscript"
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 3 && !logic.gameOverScreen.activeSelf) {
            logic.addScore(1);
        }
    }
}
