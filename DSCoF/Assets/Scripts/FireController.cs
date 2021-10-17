using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    public Image CA;
    public GameObject[] fires;
    private Collider2D CAC;
    private HashSet<int> used;
    void Start()
    {
        CAC = CA.GetComponent<Collider2D>();
        used = new HashSet<int>();
    }

    public void CreateFire()
    {
        var tmp = Random.Range(0, fires.Length);
        while (used.Contains(tmp)) tmp = Random.Range(0, fires.Length);
        var fire = fires[tmp];
        int i=0, j=0;
        // while (true) {
        for (int k = 0; k < 100; k++) {
            i = Random.Range(0,(int)CA.sprite.rect.width);
            j = Random.Range(0,(int)CA.sprite.rect.height);
            if (CAC.OverlapPoint(new Vector2(i,j))) {
                Debug.Log("Found");
                break;
            }
        }

        fire.transform.Translate(i,j,0);
    }
}
