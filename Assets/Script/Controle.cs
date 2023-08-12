using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    private Rigidbody Rig;
    public float Força = 1;
    public float Intervalo = 0.5f;
    private float Tempo = 0;
    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Tempo -= Time.deltaTime;
        bool IsGameActive = Ger.Instance.IsGameActive();
        bool PularP = Tempo <= 0 && IsGameActive;

        if(PularP) { bool PuloI = Input.GetKey(KeyCode.Space);
       if(PuloI) {Pulo();} 
       } Rig.useGravity = IsGameActive;
    }

    void OnCollisionEnter(Collision other) {OnCustomCollisionEnter(other.gameObject);}

    void OnTriggerEnter(Collider other) {OnCustomCollisionEnter(other.gameObject);}
    
    private void OnCustomCollisionEnter(GameObject other) {
        bool isSensor = other.CompareTag("Sensor");
        if(isSensor) {
            Ger.Instance.score++;
            Debug.Log("Pontos: " + Ger.Instance.score);}
            else { Ger.Instance.EndGame();}
    }
    private void Pulo() {
        Tempo = Intervalo;
        Rig.velocity = Vector3.zero;
        Rig.AddForce(new Vector3(0, Força, 0), ForceMode.Impulse);
    }
}
