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
using Photon.Pun;

[System.Serializable]
public struct SetOfBlock
{
    public int x;
    public int start_y;
    public int end_y;
}

public class Testing : MonoBehaviour {

    public GameObject myPrefab;
    private TrapGrid TrapGrid;
    private float mouseMoveTimer;
    private float mouseMoveTimerMax = .01f;
    private HeatMapVisual heatMapVisual;
    public SetOfBlock[] BlockInUses;

    public int Number_x;
    public int Number_y;
    public float cellSize;

    private Controller GameController;
    private int PR;

    private void Start() {
        GameController = GameObject.Find("Controller").GetComponent<Controller>();
        PR = GameController.PlayerRole;
        if(PR == 1)
        {
            Vector3 NowPosition = this.transform.position;

            TrapGrid = new TrapGrid(Number_x, Number_y, cellSize, NowPosition);

            foreach (SetOfBlock USLK in BlockInUses)
            {  
                for (int i = USLK.start_y; i < USLK.end_y; i++)
                    {
                        TrapGrid.SetBoolValue(USLK.x,i,false);
                    }
            }

            heatMapVisual = new HeatMapVisual(TrapGrid, GetComponent<MeshFilter>());
        }
    }

    private void Update() {
        HandleClickToModifyTrapGrid();
        HandleHeatMapMouseMove();

        if (Input.GetMouseButtonDown(1)) {
            Debug.Log(TrapGrid.GetValue(UtilsClass.GetMouseWorldPosition()));
            TrapGrid = new TrapGrid(0, 0, 0f, new Vector3(0, 0));
            heatMapVisual = new HeatMapVisual(TrapGrid, GetComponent<MeshFilter>());
        }
    }

    private void HandleClickToModifyTrapGrid() {
        if (Input.GetMouseButtonDown(0)) {
            TrapGrid.SetValue(UtilsClass.GetMouseWorldPosition(), 1);
            //Debug.Log(TrapGrid.GetCellCenterPosition(UtilsClass.GetMouseWorldPosition()));
            bool TrapGridValue = TrapGrid.GetBoolValue(UtilsClass.GetMouseWorldPosition());
            if(!TrapGridValue){
                TrapGrid.SetBoolValue(UtilsClass.GetMouseWorldPosition(), true);
                if(myPrefab != null){
                    //if(PhotonNetwork.CurrentRoom == null){}
                    PhotonNetwork.Instantiate(myPrefab.name, TrapGrid.GetCellCenterPosition(UtilsClass.GetMouseWorldPosition()), Quaternion.identity);

                        //Instantiate(myPrefab, TrapGrid.GetCellCenterPosition(UtilsClass.GetMouseWorldPosition()), Quaternion.identity);
                    
                    //PhotonNetwork.Instantiate("MyPrefabName", new Vector3(0, 0, 0), Quaternion.identity, 0);
                }        
            }
        }
        
        
    }
        
    private void HandleHeatMapMouseMove() {
        mouseMoveTimer -= Time.deltaTime;
        if (mouseMoveTimer < 0f) {
            mouseMoveTimer += mouseMoveTimerMax;
            //int TrapGridValue = TrapGrid.GetValue(UtilsClass.GetMouseWorldPosition());
            
            if( TrapGrid.CheckInGrid(UtilsClass.GetMouseWorldPosition()) && ! TrapGrid.GetBoolValue(UtilsClass.GetMouseWorldPosition())){
                TrapGrid.SetValue(UtilsClass.GetMouseWorldPosition(),256);
            }else{
                heatMapVisual.initialMap();
            }         
        }
    }


    private class HeatMapVisual {

        private TrapGrid TrapGrid;
        private Mesh mesh;

        public HeatMapVisual(TrapGrid TrapGrid, MeshFilter meshFilter) {
            this.TrapGrid = TrapGrid;
            
            mesh = new Mesh();
            meshFilter.mesh = mesh;

            UpdateHeatMapVisual();

            TrapGrid.OnGridValueChanged += TrapGrid_OnTrapGridValueChanged;

            TrapGrid.OnGridBoolChanged += TrapGrid_OnTrapGridBoolChanged;
        }

        private void TrapGrid_OnTrapGridValueChanged(object sender, System.EventArgs e) {
            UpdateHeatMapVisual();
        }

        private void TrapGrid_OnTrapGridBoolChanged(object sender, System.EventArgs e) {
            UpdateHeatMapVisual();
        }

        public void UpdateHeatMapVisual() {
            Vector3[] vertices;
            Vector2[] uv;
            int[] triangles;

            MeshUtils.CreateEmptyMeshArrays(TrapGrid.GetWidth() * TrapGrid.GetHeight(), out vertices, out uv, out triangles);

            for (int x = 0; x < TrapGrid.GetWidth(); x++) {
                for (int y = 0; y < TrapGrid.GetHeight(); y++) {
                    int index = x * TrapGrid.GetHeight() + y;
                    Vector3 baseSize = new Vector3(1, 1) * TrapGrid.GetCellSize();
                    int TrapGridValue = 50;
                    if(TrapGrid.CheckXY(UtilsClass.GetMouseWorldPosition(),x,y)){
                        TrapGridValue = 256;
                    }
                    if(TrapGrid.GetBoolValue(x,y)){
                        TrapGridValue = 0;
                    }
                    //int TrapGridValue = TrapGrid.GetValue(UtilsClass.GetMouseWorldPosition());
                    int maxTrapGridValue = 100;
                    float TrapGridValueNormalized = Mathf.Clamp01((float)TrapGridValue / maxTrapGridValue);
                    Vector2 TrapGridCellUV = new Vector2(TrapGridValueNormalized, 0f);
                    MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, TrapGrid.GetWorldPosition(x, y)-TrapGrid.originPosition + baseSize * .5f, 0f, baseSize, TrapGridCellUV, TrapGridCellUV);
                    
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

            MeshUtils.CreateEmptyMeshArrays(TrapGrid.GetWidth() * TrapGrid.GetHeight(), out vertices, out uv, out triangles);

            for (int x = 0; x < TrapGrid.GetWidth(); x++) {
                for (int y = 0; y < TrapGrid.GetHeight(); y++) {
                    int index = x * TrapGrid.GetHeight() + y;
                    Vector3 baseSize = new Vector3(1, 1) * TrapGrid.GetCellSize();
                    int TrapGridValue = 50;
                    int maxTrapGridValue = 100;
                    if(TrapGrid.GetBoolValue(x,y)){
                        TrapGridValue = 0;
                    }
                    float TrapGridValueNormalized = Mathf.Clamp01((float)TrapGridValue / maxTrapGridValue);
                    Vector2 TrapGridCellUV = new Vector2(TrapGridValueNormalized, 0f);
                    MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, TrapGrid.GetWorldPosition(x, y)-TrapGrid.originPosition + baseSize * .5f, 0f, baseSize, TrapGridCellUV, TrapGridCellUV);
                }
            }
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
        }
    }
}
