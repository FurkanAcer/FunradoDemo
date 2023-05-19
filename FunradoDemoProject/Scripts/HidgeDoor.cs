using UnityEngine;

public class HidgeDoor : MonoBehaviour
{
    public HingeJoint _hingeJoint;
    private JointMotor _motor;
    private float _angle;
    private float _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _motor = _hingeJoint.motor;
    }

    // Update is called once per frame
    void Update()
    {
        _angle = _hingeJoint.angle;
        _motor.targetVelocity = -_angle;
        _hingeJoint.motor = _motor;
    }
}
