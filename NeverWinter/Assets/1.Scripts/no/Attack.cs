using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    public Tower2 tower1 = null;
    public bool isMove = true;
    public int lifeTime = 100;
    // Start is called before the first frame update

    public void MoveStart(Tower2 tower)
    {

        tower1 = tower;

        transform.rotation = tower1.shootPoint.transform.rotation;

        isMove = true;
    }

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (isMove)
        {

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);


        if (collision.gameObject.layer == LayerMask.NameToLayer("Unit"))
        {
            EnemyCtrl unit = collision.gameObject.GetComponent<EnemyCtrl>();
            if (unit)
            {
                //Damage(Random.Range(3, 6)); ������
            }
        }

        Destroy(gameObject);
    }
    //IEnumerator Disapear()
    //{
    //    
    //    isMove = false;
    //    yield return new WaitForSeconds(1.0f);

    //   
    //    Destroy(gameObject);
    //}
}
