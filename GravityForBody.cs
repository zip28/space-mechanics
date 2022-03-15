using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForBody : MonoBehaviour
{
    
    public float mass;
    public Vector2 moveDitection;
    public Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        GravityMainSystem.bodies.Add(this);
        position = transform.position;
    }

    // Update is called once per frame
    static Vector2 ApplyForceForBody(GravityForBody body, GravityForBody gravitator)
    {
        Vector2 force = Vector2.zero;
        if (gravitator != body)
        {
            Vector2 heading = gravitator.position - body.position;
            float distance = heading.magnitude;
            Vector2 direction = heading / distance;
            force += GravityMainSystem.G / distance / distance * direction;
        }
        Vector2 newForce = force / body.mass;
        return newForce;
    }
    static Vector2 ApplyGravityForBody(GravityForBody body, List<GravityForBody> bodies)
    {
        Vector2 sumForce = Vector2.zero;
        for (int i = 0; i < bodies.Count; i++)
        {
            if(body != bodies[i])
            sumForce = ApplyForceForBody(body, bodies[i]);
        }
        body.moveDitection += sumForce;
        return body.moveDitection;
    }
    public static void MoveGravityForAll(List<GravityForBody> bodies)
    {
        for (int i = 0; i < bodies.Count; i++)
        {
            bodies[i].moveDitection = ApplyGravityForBody(bodies[i], bodies);
        }
        for (int i = 0; i < bodies.Count; i++)
        {
            bodies[i].position += bodies[i].moveDitection;
            if (bodies == GravityMainSystem.bodies)
            {
                bodies[i].transform.position = bodies[i].position;
            }
        }
    }
    public GravityForBody(float masss, Vector2 positionn, Vector2 moveDirectionn)
    {
        mass = masss;
        position = positionn;
        moveDitection = moveDirectionn;
    }
}
