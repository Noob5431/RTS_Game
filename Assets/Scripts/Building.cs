using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float size;
    public LayerMask unwalkable;
    public GameObject targetObject;
    public GameObject resourceManager;
    public int[] cost;

    private void Update()
    {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            Collider2D obstacle = Physics2D.OverlapCircle(transform.position, size, unwalkable);

        gameObject.transform.position = mousePos2D;

            if (obstacle)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            
           if (!obstacle && Input.GetMouseButtonUp(0))
        {
            if (resourceManager.GetComponent<resurse>()._noobomium > cost[0] ||
            resourceManager.GetComponent<resurse>()._naturalium > cost[1] ||
            resourceManager.GetComponent<resurse>()._taranium > cost[2] ||
            resourceManager.GetComponent<resurse>()._weed > cost[3])
            {
                resourceManager.GetComponent<resurse>()._noobomium -= cost[0];
                resourceManager.GetComponent<resurse>()._naturalium -= cost[1];
                resourceManager.GetComponent<resurse>()._taranium -= cost[2];
                resourceManager.GetComponent<resurse>()._weed -= cost[3];
                Instantiate(targetObject, transform.position, transform.rotation).SetActive(true);
                Destroy(gameObject);
            }     
        }
        if (Input.GetKeyUp(KeyCode.Escape))
            Destroy(gameObject);
    }
}
