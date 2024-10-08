﻿using System.Collections;
using UnityEngine;

namespace _Project.Core.Infrastructure
{
public interface ICoroutineRunner
{
    Coroutine StartCoroutine( IEnumerator coroutine );
    void StopCoroutine( Coroutine coroutine );
}
}