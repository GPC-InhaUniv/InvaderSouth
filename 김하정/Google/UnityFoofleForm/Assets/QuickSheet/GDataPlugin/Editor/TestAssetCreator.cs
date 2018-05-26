using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Test")]
    public static void CreateTestAssetFile()
    {
        Test asset = CustomAssetUtility.CreateAsset<Test>();
        asset.SheetName = "FormUnity(Responses)";
        asset.WorksheetName = "Test";
        EditorUtility.SetDirty(asset);        
    }
    
}