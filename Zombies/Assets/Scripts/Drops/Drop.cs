using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    BoxCollider bc;

    private bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeOut());
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasCollided)
        {
            Collisions();
        }
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }

    private void Collisions()
    {
        // Only report the player or its children
        Collider[] hitColliders = Physics.OverlapBox(bc.transform.position, bc.transform.localScale / 2, Quaternion.identity, layer);

        for(int items = 0; items < hitColliders.Length; items++)
        {
            hasCollided = true;
            Debug.Log("Hit : " + hitColliders[items].name + items);
            DropAbility(hitColliders[items]);
        }
    }

    protected virtual void DropAbility(Collider collider)
    {
        Debug.Log("Child Ability failed");
    }

}
