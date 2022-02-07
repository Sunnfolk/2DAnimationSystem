using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class Animations : ScriptableObject
{
    public List<Sprite> north;
    public List<Sprite> northEast;
    public List<Sprite> east;
    public List<Sprite> southEast;
    public List<Sprite> south;
}
