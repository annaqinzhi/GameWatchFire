using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class GameManager : MonoBehaviour {

    public GameObject jumperPrefab;
    public GameObject fireman;
    public LifeViewController lifeController;

    Collider2D firemanCollider;

    //[SerializeField]
    //private int lives = 10;

   // Collider2D tempJumperCollider;



	// Use this for initialization
	void Start () {
        firemanCollider = fireman.GetComponentInChildren<Collider2D>();

        lifeController.RestoreAllLives();
        NewJumper();

	}

    //private void Update()
    //{
    //    if (firemanCollider.IsTouching(tempJumperCollider)){
    //        fireman.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
    //    } else {
    //        fireman.GetComponentInChildren<SpriteRenderer>().color = Color.green;

    //    }
    //}

    void NewJumper() {
        GameObject newJumper = Instantiate(jumperPrefab);
        newJumper.GetComponentInChildren<JumperController>().gameManager = this;

    }


    public bool Crash(GameObject jumper) {

        Collider2D jumperCollider = jumper.GetComponent<Collider2D>();

        if (jumperCollider == null || firemanCollider == null)
        {
            Debug.Log("collider not found");
        }

        if( jumperCollider.IsTouching(firemanCollider)){
            
            return false;
        }
        else {
            LoseOneLife();
            return true;
       } 
    }

    void LoseOneLife() {
        
        if (!lifeController.RemoveLife() )
        {
            Debug.Log("Game Over!");
        }
        else
        {
            NewJumper();
        }
    }

}
