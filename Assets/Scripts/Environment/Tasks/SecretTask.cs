using Environment.Tasks;
using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "SecretTask", menuName = "SecretTask")]
public class SecretTask : Task
{
    [SerializeField] int[] ints = {8,2,1,3,9};


    public override void Execute()
    {
        Sort(ints);
    }

    public void Sort(int[] arr) {

        for(int i = 0; i < arr.Length-1; i++) {

            Debug.Log("Compare: " + arr[i] + " With " + arr[i + 1]);
            if(arr[i] > arr[i + 1]) Swap(arr, i, i + 1); 
        }

        for(int i = 0; i < arr.Length; i++) {
            Debug.Log(arr[i]); 
        }
    }

    public void Swap(int[] arr, int i, int j) {

        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
