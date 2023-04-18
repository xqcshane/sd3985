/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour {

    public GameObject myPrefab;
    private Grid grid;
    private float mouseMoveTimer;
    private float mouseMoveTimerMax = .01f;
    private HeatMapVisual heatMapVisual;

    private void Start() {
        grid = new Grid(10, 10, 1f, new Vector3(0, 0));
        
        heatMapVisual = new HeatMapVisual(grid, GetComponent<MeshFilter>());

        
    }

    private void Update() {
        HandleClickToModifyGrid();
        HandleHeatMapMouseMove();

        if (Input.GetMouseButtonDown(1)) {
            //Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
            grid = new Grid(0, 0, 0f, new Vector3(0, 0));
            heatMapVisual = new HeatMapVisual(grid, GetComponent<MeshFilter>());
        }
        Debug.Log(GetPositionOfMouse());
    }

    private void HandleClickToModifyGrid() {
        if (Input.GetMouseButtonDown(0)) {
            //grid.SetValue(UtilsClass.GetMouseWorldPosition(), 1);
            grid.SetValue(GetPositionOfMouse(), 1);
            //Debug.Log(grid.GetCellCenterPosition(UtilsClass.GetMouseWorldPosition()));
            //bool gridValue = grid.GetBoolValue(UtilsClass.GetMouseWorldPosition());
            bool gridValue = grid.GetBoolValue(GetPositionOfMouse());
            if(!gridValue){
                //grid.SetBoolValue(UtilsClass.GetMouseWorldPosition(), true);
                grid.SetBoolValue(GetPositionOfMouse(), true);
                if(myPrefab != null){
                    //Instantiate(myPrefab, grid.GetCellCenterPosition(UtilsClass.GetMouseWorldPosition()), Quaternion.identity);
                    Instantiate(myPrefab, grid.GetCellCenterPosition(GetPositionOfMouse()), Quaternion.identity);
                }        
            }
        }
        
        
    }
        
    private void HandleHeatMapMouseMove() {
        mouseMoveTimer -= Time.deltaTime;
        if (mouseMoveTimer < 0f) {
            mouseMoveTimer += mouseMoveTimerMax;
            //int gridValue = grid.GetValue(UtilsClass.GetMouseWorldPosition());
            /*
            if( grid.CheckInGrid(UtilsClass.GetMouseWorldPosition()) && ! grid.GetBoolValue(UtilsClass.GetMouseWorldPosition())){
                grid.SetValue(UtilsClass.GetMouseWorldPosition(),256);
            }else{
                heatMapVisual.initialMap();
            }     
            */    
            if( grid.CheckInGrid(GetPositionOfMouse()) && ! grid.GetBoolValue(GetPositionOfMouse())){
                grid.SetValue(GetPositionOfMouse(),256);
            }else{
                heatMapVisual.initialMap();
            }     
        }
    }


    private class HeatMapVisual {

        private Grid grid;
        private Mesh mesh;

        public HeatMapVisual(Grid grid, MeshFilter meshFilter) {
            this.grid = grid;
            
            mesh = new Mesh();
            meshFilter.mesh = mesh;

            UpdateHeatMapVisual();

            grid.OnGridValueChanged += Grid_OnGridValueChanged;

            grid.OnGridBoolChanged += Grid_OnGridBoolChanged;
        }

        private void Grid_OnGridValueChanged(object sender, System.EventArgs e) {
            UpdateHeatMapVisual();
        }

        private void Grid_OnGridBoolChanged(object sender, System.EventArgs e) {
            UpdateHeatMapVisual();
        }

        public void UpdateHeatMapVisual() {
            Vector3[] vertices;
            Vector2[] uv;
            int[] triangles;

            MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out vertices, out uv, out triangles);

            for (int x = 0; x < grid.GetWidth(); x++) {
                for (int y = 0; y < grid.GetHeight(); y++) {
                    int index = x * grid.GetHeight() + y;
                    Vector3 baseSize = new Vector3(1, 1) * grid.GetCellSize();
                    int gridValue = 50;
                    /*
                    if(grid.CheckXY(UtilsClass.GetMouseWorldPosition(),x,y)){
                        gridValue = 256;
                    }
                    */
                    if(grid.CheckXY(GetPositionOfMouse(),x,y)){
                        gridValue = 256;
                    }
                    
                    //int gridValue = grid.GetValue(UtilsClass.GetMouseWorldPosition());
                    int maxGridValue = 100;
                    float gridValueNormalized = Mathf.Clamp01((float)gridValue / maxGridValue);
                    Vector2 gridCellUV = new Vector2(gridValueNormalized, 0f);
                    MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + baseSize * .5f, 0f, baseSize, gridCellUV, gridCellUV);
                }
            }

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
                       
        }
        
        public void initialMap() {
            Vector3[] vertices;
            Vector2[] uv;
            int[] triangles;

            MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out vertices, out uv, out triangles);

            for (int x = 0; x < grid.GetWidth(); x++) {
                for (int y = 0; y < grid.GetHeight(); y++) {
                    int index = x * grid.GetHeight() + y;
                    Vector3 baseSize = new Vector3(1, 1) * grid.GetCellSize();
                    int gridValue = 50;
                    int maxGridValue = 100;
                    float gridValueNormalized = Mathf.Clamp01((float)gridValue / maxGridValue);
                    Vector2 gridCellUV = new Vector2(gridValueNormalized, 0f);
                    MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + baseSize * .5f, 0f, baseSize, gridCellUV, gridCellUV);
                }
            }
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
        }

        public Vector3 GetPositionOfMouse()
        {
            Vector3 screenPosition=Input.mousePosition;
            //allow the crosshair to be seen by the camera to let it topper than the nearclip
            screenPosition.z = Camera.main.nearClipPlane;
            //Vector3 newPos = new Vector3(Camera.main.ScreenToWorldPoint(screenPosition).x, Camera.main.ScreenToWorldPoint(screenPosition).y , 0.0f);
            return(Camera.main.ScreenToWorldPoint(screenPosition));          
        }

    }

    public Vector3 GetPositionOfMouse()
    {
        Vector3 screenPosition=Input.mousePosition;
        //allow the crosshair to be seen by the camera to let it topper than the nearclip
        screenPosition.z = Camera.main.nearClipPlane;
        //Vector3 newPos = new Vector3(Camera.main.ScreenToWorldPoint(screenPosition).x, Camera.main.ScreenToWorldPoint(screenPosition).y , 0.0f);
        return(Camera.main.ScreenToWorldPoint(screenPosition));       
    }

}
