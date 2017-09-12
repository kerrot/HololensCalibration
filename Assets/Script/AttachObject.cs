using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class AttachObject : MonoBehaviour {

    [SerializeField] GameObject Target;
    [SerializeField] AssignType targetPosition;
    [SerializeField] AssignType targetRotation;
    [SerializeField] AssignType selfPosition;
    [SerializeField] AssignType selfRotation;

    public enum AssignType
    {
        GLOBAL,
        LOCAL,
    }

    void Start ()
    {
        this.LateUpdateAsObservable().Subscribe(_ =>
        {
            if (Target)
            {
                if (selfPosition == AssignType.GLOBAL)
                {
                    transform.position = (targetPosition == AssignType.GLOBAL) ? Target.transform.position : Target.transform.localPosition;
                }
                else
                {
                    transform.localPosition = (targetPosition == AssignType.GLOBAL) ? Target.transform.position : Target.transform.localPosition;
                }

                if (selfRotation == AssignType.GLOBAL)
                {
                    transform.rotation = (targetPosition == AssignType.GLOBAL) ? Target.transform.rotation : Target.transform.localRotation;
                }
                else
                {
                    transform.localRotation = (targetPosition == AssignType.GLOBAL) ? Target.transform.rotation : Target.transform.localRotation;
                }
            }
        });
	}
}
