using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class AttachObject : MonoBehaviour {

    [SerializeField] GameObject Target;

	void Start ()
    {
        this.LateUpdateAsObservable().Subscribe(_ =>
        {
            transform.localPosition = Target.transform.position;
            transform.localRotation = Target.transform.rotation;
        });
	}
}
