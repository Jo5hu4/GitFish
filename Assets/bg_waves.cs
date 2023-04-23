
using UnityEngine;

public class bg_waves : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollspeed=.5f;
    private float offset;
    private Material mat;

    void Start()
    {
        mat= GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
offset += (Time.deltaTime * scrollspeed) / 10f;
mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        
    }
}
