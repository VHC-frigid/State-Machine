using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomColour : MonoBehaviour
{
    private MaterialPropertyBlock propertyBlock;
    private Renderer renderer;
    
    void Start()
    {
        renderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        PickRandom();
    }

    public void PickRandom()
    {
        Color randomColour = Random.ColorHSV();
        propertyBlock.SetColor("_Color", randomColour);
        renderer.SetPropertyBlock(propertyBlock);
    }

    public void PickBlack()
    {
        Color randomColour = Color.black;
        //"_Colour" is albedo behind the scene's, propertyblock is the 
        propertyBlock.SetColor("_Color", randomColour);
        renderer.SetPropertyBlock(propertyBlock);
    }

    private float H = 0;
    public void SlideColour()
    {
        H += 0.1f * Time.deltaTime;
        if(H >= 1)
        {
            H = 0;
        }
        Color newColor = Color.HSVToRGB(H, 1, 1);
        propertyBlock.SetColor("_Color", newColor);
        renderer.SetPropertyBlock(propertyBlock);
    }

}
