﻿//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//В итоге получается вот такой массив:
//7 4 2 1
//9 5 3 2
//8 4 4 2

int [,] Array= GetArray(5,5,0,9);
PrintArray(Array);
Console.WriteLine("Отсортированный в строках:");
PrintArray(SortArrayOnRows (Array));


int [,] GetArray (int m, int n, int MinValue, int MaxValue)
{
    int [,] result=new int [m,n];
    for (int i=0; i<m;i++)
    {
        for (int j=0;j<n;j++)
        {
            result[i,j]=new Random().Next(MinValue,MaxValue+1);
        }
    }
    return result;
}

void PrintArray (int [,] arr)
{
 for (int i=0; i<arr.GetLength(0);i++)
    {
        for (int j=0;j<arr.GetLength(1);j++)
        {
           Console.Write ($"{arr[i,j]} ");
        }
        Console.WriteLine();
    }
}

int[] SortI (int [,] array,int i)
{
    int [] result=new int [array.GetLength(1)];
    for (int j=0; j<array.GetLength(1);j++) // Нельзя трогать первоначальное, это не правильно, сделай копию и развлекайся
    {
        result[j]=array[i,j];
    }
    int count=1;// первый вход, похорошему тут repeat.. while или do..while(как тут в с#?) - но мы такое не проходили
    while (count>0){
        count=0;
        for (int j=1; j<array.GetLength(1);j++)
        {
            if (result[j-1]<result[j])
            {
                int temp=result[j-1];
                result[j-1]=result[j];
                result[j]=temp;
                count++;
            }
        }
    }
    return result;
  
    
}

int [,] SortArrayOnRows (int [,] array)
{
    int [,] result=new int [array.GetLength(0),array.GetLength(1)];
    for (int i=0; i<array.GetLength(0);i++)
    {
        int [] tempArray=SortI(array,i);
   
        for (int j=0;j<array.GetLength(1);j++)
        {
            result[i,j]=tempArray[j];
            
        }
    }
    return result;
}