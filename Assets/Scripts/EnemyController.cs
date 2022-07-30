using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : GazePointer
{
    public GameObject Skeleton;
    Vector3 endPos;
    public float speed;
    int _limit =1;
    // Start is called before the first frame update
    void Start()
    {
        endPos = (transform.position - Vector3.zero).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, endPos, speed * Time.deltaTime );
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
            Attack();
    }

    public override void OnPointerDown(PointerEventData eventData){
        base.OnPointerDown(eventData);
        //Debug.Log("hello Davish " + _limit);
        if(_limit!=1){
            PlayerManager.currentScore +=100;
            Death();
        }
        else
            _limit = 2;
    }

    public void Death(){
        Debug.Log("death Davish");
        Skeleton.GetComponent<Animator>().SetTrigger("die");
        Skeleton.transform.SetParent(null);
        Destroy(gameObject);
    }

    public void Attack(){
        Skeleton.GetComponent<Animator>().SetTrigger("attack");
        PlayerManager.playerHealth -= 0.2f;
    }
}
