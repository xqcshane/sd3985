/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class TrapGrid {

    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs {
        public int x;
        public int y;
    }
     
    public event EventHandler<OnGridBoolChangedEventArgs> OnGridBoolChanged;
    public class OnGridBoolChangedEventArgs : EventArgs {
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private float cellSize;
    public Vector3 originPosition;
    private int[,] gridArray;
    private bool[,] gridBoolArray;

    public TrapGrid(int width, int height, float cellSize, Vector3 originPosition) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.gridBoolArray = new bool[width, height];
        //gridBoolArray = true;

        gridArray = new int[width, height];

        bool showDebug = true;
        if (showDebug) {
            TextMesh[,] debugTextArray = new TextMesh[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++) {
                for (int y = 0; y < gridArray.GetLength(1); y++) {
                    //debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 30, Color.white, TextAnchor.MiddleCenter);
                    //debugTextArray[x, y] = UtilsClass.CreateWorldText(gridBoolArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 30, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                    this.SetBoolValue(x,y,true);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

            OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) => {
                //debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y].ToString();
            };
            
            OnGridBoolChanged += (object sender, OnGridBoolChangedEventArgs eventArgs) => {
               //debugTextArray[eventArgs.x, eventArgs.y].text = gridBoolArray[eventArgs.x, eventArgs.y].ToString();
            };
        }
    }

    public int GetWidth() {
        return width;
    }

    public int GetHeight() {
        return height;
    }

    public float GetCellSize() {
        return cellSize;
    }

    public Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }
    
    public bool CheckXY(Vector3 worldPosition, int nowx, int nowy) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        if(x == nowx&&y==nowy){
            return true;
        }else{
            return false;
        }
    }

    public bool CheckInGrid(Vector3 worldPosition) {
        bool myb = CheckInGrid(worldPosition.x,worldPosition.y);
        return myb;
    }

    public bool CheckInGrid(float x, float y) {
        if (x >= originPosition.x && y >= originPosition.y && x < originPosition.x+width*cellSize && y < originPosition.y+height*cellSize) {
            return true;
        }else{
            return false;
        }
       
    }

    public void SetValue(int x, int y, int value) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            gridArray[x, y] = value;
            if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
        }
    }

    public void SetValue(Vector3 worldPosition, int value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return gridArray[x, y];
        } else {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

    public Vector3 GetCellCenterPosition(int x, int y) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return (new Vector3((float)(x+0.5)*cellSize, (float)(y+0.5)*cellSize, 0) + originPosition);
        } else {
            return (new Vector3(0,0,0));
        }
    }
        
    public Vector3 GetCellCenterPosition(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetCellCenterPosition(x, y);
    }


    public void SetBoolValue(int x, int y, bool value) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            gridBoolArray[x, y] = value;
            if (OnGridBoolChanged != null) OnGridBoolChanged(this, new OnGridBoolChangedEventArgs { x = x, y = y });
        }
    }

    public void SetBoolValue(Vector3 worldPosition, bool value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetBoolValue(x, y, value);
    }

    public bool GetBoolValue(int x, int y) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return gridBoolArray[x, y];
        } else {
            return true;
        }
    }

    public bool GetBoolValue(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetBoolValue(x, y);
    }

}
