using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsLoop : Photon.MonoBehaviour {
	public float xRmin=-20f;
	public float xRmax=20f;

	public float yRmin=5.8f;
	public float yRmax=9f;


	public int poolsize;
	public GameObject coinprefab;
	public GameObject coinprefab2;
	private GameObject[] coins;
	public float lastspawn;
    public float spawnrate;
	private int currentcoins=0;
    public PhotonView pv;
    public bool isspawned = false;

	private Vector2 objectpools = new Vector2 (-20, -30);
    

    void Start()
    {
        
        
    }
    void Update()
    {
		if (pv.isMine) {
			if (GetComponent<GameStartEnd>().gamestarted && !isspawned)
			{
				MakeCoint();
			}
			if (GetComponent<GameStartEnd>().gamestarted)
			{
				Setspawn();
			}
			if (GetComponent<GameStartEnd>().gameover) {
				sentToPools();
			}
		}

        
    }




	void sentToPools(){
		for (int i = 0; i < poolsize; i++)
		{
			coins [i].transform.position = objectpools;
		}
	}

    void MakeCoint()
   {
       coins = new GameObject[poolsize];
       for (int i = 0; i < poolsize; i++)
       {
           coins[i] = PhotonNetwork.Instantiate(coinprefab.name, objectpools, Quaternion.identity,0);
           coins[i + 1] = PhotonNetwork.Instantiate(coinprefab2.name, objectpools, Quaternion.identity,0);
           i++;
       }
		isspawned = true;
   }
 
   void Setspawn()
   {
       lastspawn += Time.deltaTime;
       if (lastspawn >= spawnrate)
       {
           lastspawn = 0;
           float spawnY = Random.Range(yRmin, yRmax);
           float spawnX = Random.Range(xRmin, xRmax);
           coins[currentcoins].transform.position = new Vector2(spawnY, spawnX);
           currentcoins++;
           if (currentcoins >= poolsize)
           {
               currentcoins = 0;
           }
       }
   }

   
   
}
