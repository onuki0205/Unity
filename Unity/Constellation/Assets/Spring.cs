using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

    //物体をバネで引っ張るためのオブジェクト
    public GameObject targetSphire;

    Rigidbody rb;
    Transform targetSphireTransform;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetSphireTransform = targetSphire.transform;
    }

    //バネの力を加える
    //目標いち、バネ係数rが引数
    void AddSpringForce(Vector3 target_position, float r)
    {
        var diff = target_position - transform.position; //目標位置と、自分の位置との差。要するにバネの伸び
        var force = diff * r; //バネの力、弾性力は、バネ係数*バネの伸び
        rb.AddForce(force);
    }

    //オーバーシュートしないバネの力を加える
    void AddSpringForceExtra(Vector3 target_position)
    {
        var r = rb.mass * rb.drag * rb.drag / 4f;   //オーバーシュートしないバネ係数
        var diff = target_position - transform.position;
        var force = diff * r;
        rb.AddForce(force);
    }

    void FixedUpdate()
    {
        //AddSpringForce(targetSphireTransform.position, 10f);
        AddSpringForceExtra(targetSphireTransform.position);
    }

}