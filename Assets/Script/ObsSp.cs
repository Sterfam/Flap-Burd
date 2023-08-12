using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSp : MonoBehaviour
{
    private float Carr = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = Ger.Instance;

        if(gameManager.IsGameOver()) {return;}

        Carr -= Time.deltaTime;
        if (Carr <= 0f)
        {
            Carr = Ger.Instance.ObsInt;


            int prefabIndex = Random.Range(0, gameManager.ObsPrefab.Count);
            GameObject prefab = gameManager.ObsPrefab[prefabIndex];
            float x = gameManager.setx;
            float y = Random.Range(gameManager.sety.x, gameManager.sety.y);
            float z = (float)-0.44;
            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
} 