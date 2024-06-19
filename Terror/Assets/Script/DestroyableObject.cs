using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : InteractableObject
{
    protected override void Interact()
    {
        PlayerInteraction.instance.OnInteractionEffected.Invoke();
        Destroy(gameObject);
        //StartCoroutine(NomeDaCoroutine());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
