using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    SphereCollider sphereCollider;

    private void OnEnable()
    {
        StartCoroutine(DesactiveNoise());
    }
    public  void MakeNoise(AudioSource audio)
    {
        //Colocar o objeto de barulho no local do barulho
        transform.position = audio.transform.position;
        sphereCollider.radius = audio.maxDistance; //Ajustar a proporção do barulho
    }
    // Start is called before the first frame update
    void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    IEnumerator DesactiveNoise()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
