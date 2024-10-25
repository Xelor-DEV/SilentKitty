using UnityEngine;

public class SpiderWebBox : Box
{
    protected override void Start()
    {
        base.Start();
        _rigidbody2D.freezeRotation = true;
    }
}
