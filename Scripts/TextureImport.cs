using UnityEngine;
using UnityEditor;

public class TextureImport : AssetPostprocessor {

    public Material templateMaterial;

	void OnPreprocessTexture() {
        // if we dumped a png in the _texture folder...
        if (assetPath.Contains("_texture")) {
            
            // set up the texture defaults
            TextureImporter textureImporter = (TextureImporter) assetImporter;
            textureImporter.filterMode = FilterMode.Point;
            textureImporter.wrapMode = TextureWrapMode.Repeat;
            textureImporter.textureType = TextureImporterType.Image;
            
            // parse out the name of the texture
            int a = assetPath.LastIndexOf('/')+1;
            int b = assetPath.LastIndexOf('.');
            string name = assetPath.Substring(a,b-a);
            
            AssetDatabase.Refresh();
            
            // create a material for it
            Material material = new Material(templateMaterial);
            Texture2D t = (Texture2D)AssetDatabase.LoadAssetAtPath(assetPath, typeof(Texture2D));
            material.SetTexture("_MainTex",t);
            AssetDatabase.CreateAsset(material, "Assets/Materials/"+name+".mat");
        }
    }
}
