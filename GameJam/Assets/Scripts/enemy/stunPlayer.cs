using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunPlayer : MonoBehaviour
{

    [SerializeField] Sprite shockedImage;
    [SerializeField] Sprite normalImage;


    [SerializeField] private float stunnedDuration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Disablescript()
    {
        //anim.SetTrigger("stunned");
        //body.velocity = new Vector2(horizontalInput * speed, body.velocity.x);

        GetComponent<Movement>().enabled = false;

        GetComponent<SpriteRenderer>().sprite = shockedImage;

        yield return new WaitForSeconds(stunnedDuration);

        GetComponent<Movement>().enabled = true;

        GetComponent<SpriteRenderer>().sprite = normalImage;

    }

    public void startCoroutine()
    {

        StartCoroutine(Disablescript());

    }

}
