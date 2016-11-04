using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private WheelCollider[] WheelFront;
    [SerializeField]
    private WheelCollider[] WheelBack;

    [SerializeField]
    private Transform CenterOfMass;

    [SerializeField]
    private Transform[] MeshesFront;
    [SerializeField]
    private Transform[] MeshesBack;


    [SerializeField]
    private float MaxToquer = 50f;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = CenterOfMass.localPosition;
    }

    void Update()
    {
        UpdateMeshesPosition();
    }

    void FixedUpdate()
    {
        UpdateWhellPosition();
    }


    void UpdateWhellPosition()
    {
        for (int i = 0; i < WheelBack.Length; i++)
        {
            WheelBack[i].motorTorque = MaxToquer * Input.GetAxis("Vertical");
        }

        for (int i = 0; i < WheelFront.Length; i++)
        {
            WheelFront[i].steerAngle = 20 * Input.GetAxis("Horizontal");
        }
    }

    void UpdateMeshesPosition()
    {
        for (int i = 0; i < MeshesFront.Length; i++)
        {
            Quaternion qua;
            Vector3 vec;
            WheelFront[i].GetWorldPose(out vec, out qua);

            MeshesFront[i].position = vec;
            MeshesFront[i].rotation = qua;
        }

        for (int i = 0; i < MeshesBack.Length; i++)
        {
            Quaternion qua;
            Vector3 vec;
            WheelBack[i].GetWorldPose(out vec, out qua);

            MeshesBack[i].position = vec;
            MeshesBack[i].rotation = qua;
        }

    }
}
