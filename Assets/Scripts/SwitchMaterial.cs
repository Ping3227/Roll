using UnityEngine;

[CreateAssetMenu(fileName = "switch material", menuName = "PickUp")]
public class SwitchMaterial : ScriptableObject,IVisitor
{
    [SerializeField] Material material;
    [SerializeField] PhysicMaterial physicMaterial;
    [SerializeField][Range(0,5)] float weight;
    public void Visit(MaterialSetter materialSetter)
    {
        materialSetter.GetComponent<Renderer>().material = material;
        materialSetter.GetComponent<Rigidbody>().mass = weight;
        materialSetter.GetComponent<Collider>().material = physicMaterial;
    }
}