﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class EndPosx : MonoBehaviour
{
    Vector3 pos;

    string message;

    private static int localport;

    private string IP;
    public int port;

    IPEndPoint remoteEndPoint;
    UdpClient client;

    void Start()
    {
        IP = "127.0.0.1";
        //port = 5100;

        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        float posx = pos.x;
        UnityEngine.Debug.Log("pos x is " + posx.ToString("f4"));

        string message = posx.ToString("f4");
        byte[] data = Encoding.UTF8.GetBytes(message);
        //sbyte[] sdata = Array.ConvertAll(data, b => unchecked((sbyte)b));
        client.Send(data, data.Length, remoteEndPoint);
    }
}