
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public abstract class State<T>
{
    public abstract void Execute(T agent);

    public abstract void OnEnter(T agent);

    public abstract void OnExit(T agent);
}