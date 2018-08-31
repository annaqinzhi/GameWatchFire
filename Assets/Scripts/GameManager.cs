using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class GameManager : MonoBehaviour {

    public GameObject jumperPrefab;
    public GameObject fireman;
    public LifeViewController lifeController;
    public PointsController pointsController;
    public float spawnDelay=5.0f;
    public float moveDelay = 0.5f;

    bool continueGame = true;
    int points = 0;

    Collider2D firemanCollider;


	// Use this for initialization
	void Start () {
        firemanCollider = fireman.GetComponentInChildren<Collider2D>();

        if (lifeController == null)
            Debug.LogError("No lifeview controller");


        lifeController.RestoreAllLives();
        StartCoroutine(JumperSpawner());

	}

    IEnumerator JumperSpawner(){
        while(continueGame){
            NewJumper(moveDelay-(0.02f*points));
            yield return new WaitForSeconds(spawnDelay-(0.1f*points));

        }
    }


    void NewJumper(float delay) {
        GameObject newJumper = Instantiate(jumperPrefab);
        JumperController jumpercontroller = newJumper.GetComponentInChildren<JumperController>();
        jumpercontroller.gameManager = this;
        jumpercontroller.moveDelay = delay;


        newJumper.GetComponentInChildren<JumperController>().gameManager = this;

    }

    public void JumperSaved(){
        points++;
        pointsController.SetPoint(points);
    }


    public bool Crash(GameObject jumper) {


        LayerMask mask = LayerMask.GetMask("Fireman");
        RaycastHit2D hit = Physics2D.Raycast(jumper.transform.position, Vector2.down, Mathf.Infinity, mask);

        if( hit.collider != null){
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
            continueGame = false;
        }
       
    }

}
