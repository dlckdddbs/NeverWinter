using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : EnemyCtrl
{
    public GameObject shootPoint;

    private float shootDelay = 2.7f;
    private float temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCtrl targetUnit = null;

        Collider[] colliderList = Physics.OverlapSphere(transform.position, 20.0f, LayerMask.GetMask("Unit"));

        for (int i = 0; i < colliderList.Length; i++)
        {

            EnemyCtrl searchTarget = colliderList[i].GetComponent<EnemyCtrl>();
            if (searchTarget) //&& searchTarget.isDie == false)
            {
                //StartCoroutine(BulletBustShoot2());
                targetUnit = searchTarget;
                break;
            }

        }
        if (targetUnit != null)
        {
            Vector3 viewPos = targetUnit.transform.position - gameObject.transform.position;

            
            Quaternion rot = Quaternion.LookRotation(viewPos);
            //rot.y += 90;
            //해당 회전값 만큼 내 몸을 회전 시킴.
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rot, Time.deltaTime * 50.0f);
            //shootPoint.transform.rotation =;
            if (shootDelay <= 0f)
            {
                BulletShoot();
                shootDelay = temp;
            }
            else
            {
                shootDelay -= Time.deltaTime;
            }
        }

    }
    public void BulletShoot()
    {
        //총알을 생성한다
        GameObject bullet = Instantiate(Resources.Load<GameObject>("Objects/Bullet"));
        if (bullet)
        {
            bullet.transform.position = shootPoint.transform.position;
            Attack obj = bullet.GetComponent<Attack>();
            if (obj)
            {

                obj.MoveStart(this);
            }
        }
    }

    /*public IEnumerator BulletBustShoot()
    {
        for (int i = 0; i < 3; i++)
        {
            //총알 발사
            BulletShoot();
            //0.2초 간 잠시 딜레이
            yield return new WaitForSeconds(0.2f);

        }
    }*/
    public IEnumerator BulletBustShoot2()
    {
        yield return new WaitForSeconds(5.0f);

    }
}
