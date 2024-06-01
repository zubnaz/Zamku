using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour
{
    // Start is called before the first frame update
    public int destroyedRand = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject coll = collision.gameObject;
        if(coll.tag == "Projectile")
        {
            destroyedRand++;
            GameObject block = this.gameObject;
            Renderer renderer = block.GetComponent<Renderer>();
            if (destroyedRand == 2)
            {
                
                renderer.material.color = new Color(68/255f,59 / 255f, 59 / 255f);
            }
            else if(destroyedRand == 3)
            {
                renderer.material.color = new Color(48 / 255f, 39 / 255f, 39 / 255f);
            }
            else if (destroyedRand == 4)
            {
                renderer.material.color = new Color(18 / 255f, 29 / 255f, 29 / 255f);
            }
            else if (destroyedRand == 5)
            {
                Destroy(block);
            }
        }
    }
}
