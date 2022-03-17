using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class GravityDrawer : MonoBehaviour
{
    private GravityForBody self;
    public int bodyNumber;
    public int iterations;
    public LineRenderer line;
    public int deltaTimeBetween = 20;
    public bool draw;
    static bool inited;
    private void Update()
    {
        if (draw)
        {
            DrawOrbit();
            draw = false;
        }
    }
    void DrawOrbit()
    {
        Init();
        line.positionCount = 0;
        line.positionCount = iterations;
        for(int i = 0;i < iterations; i++)
        {
            for (int j = 0; j < deltaTimeBetween; j++)
            {
                GravityForBody.MoveGravityForAll(GravityMainSystem.virtualBodies);
            }
            line.SetPosition(i, GravityMainSystem.virtualBodies[bodyNumber].position);
        }
    }
    private void Init()
    {
        self = GetComponent<GravityForBody>();
        GravityMainSystem.virtualBodies.Clear();
        for (int i = 0; i < GravityMainSystem.bodies.Count; i++)
        {
            GravityMainSystem.virtualBodies.Add(new GravityForBody(GravityMainSystem.bodies[i].mass, GravityMainSystem.bodies[i].position, GravityMainSystem.bodies[i].moveDirection));
            if (GravityMainSystem.bodies[i] == self)
            {
                bodyNumber = i;
            }
        }
    }
}
