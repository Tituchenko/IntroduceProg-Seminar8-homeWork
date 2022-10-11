﻿//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//В итоге получается вот такой массив:
//7 4 2 1
//9 5 3 2
//8 4 4 2

/*
int [,] Array= GetArray(5,5,0,9);
PrintArray(Array);
Console.WriteLine("Отсортированный в строках:");
PrintArray(SortArrayOnRows (Array));
*/

//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//5 2 6 7
//Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

/*
int [,] Array= GetArray(5,3,0,9);
PrintArray(Array);
Console.WriteLine($"{GetIndexOfMinimum(GetSumOfRows(Array))} строка");
*/

//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
//Например, даны 2 матрицы:
//2 4 | 3 4
//3 2 | 3 3
//Результирующая матрица будет:
//18 20
//15 18


int [,] Array1= GetArray(4,4,0,9); // пусть квадратные обе, вроде разрешили
int [,] Array2= GetArray(4,4,0,9);
//int[,] Array1={{2,4},{3,2}}; //- проверка примера
//int[,] Array2={{3,4},{3,3}};

Print2Array(Array1,Array2);
Console.WriteLine("Произведение:");
PrintArray(MultiplyArray(Array1,Array2));


//Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
//Массив размером 2 x 2 x 2
//66(0,0,0) 25(0,1,0)
//34(1,0,0) 41(1,1,0)
//27(0,0,1) 90(0,1,1)
//26(1,0,1) 55(1,1,1)
/*
bool inArray(int [] arr, int value)
{
bool res=false;
for (int i=0; i<arr.Length;i++)
{
    if ()
}
}

int [,,] Get3DArray (int m, int n, int z, int MinValue, int MaxValue)
{
    int [,] result=new int [m,n,z];
    int [] hasNum=new int [m*n*z];
    for (int i=0; i<(m*n*z);i++)
    {
        hasNum=MinValue-1; // нули не пойдут
    }
    for (int i=0; i<m;i++)
    {
        for (int j=0;j<n;j++)
        {
            for (int k=0;k<z;k++)

                result[i,j,z]=new Random().Next(MinValue,MaxValue+1);
            }
        }
    }
    return result;
}
*/

int GetMultipleArrayElement (int [,] a,int [,] b,int i,int j) // вынесем, вдруг Wikipedia врет и правило другое, легче будет править
{
    int sum=0;
    for (int k=0; k<a.GetLength(0);k++)
    {
        sum+=a[i,k]*b[k,j];
    }
    return sum;
}


int [,] MultiplyArray (int [,] array1,int [,] array2)
{
    int [,] result=new int [array1.GetLength(0),array1.GetLength(1)];
    for (int i=0; i<array1.GetLength(0);i++)
    {
        for (int j=0;j<array1.GetLength(1);j++)
        {
            result[i,j]=GetMultipleArrayElement(array1,array2,i,j);
            
        }
    }
    return result;
}


int[] GetSumOfRows (int [,] array)
{
    int [] result=new int [array.GetLength(0)];
    for (int i=0; i<array.GetLength(0);i++)
    {
        for (int j=0;j<array.GetLength(1);j++)
        {
            result[i]+=array[i,j];// на лекции говорили что массивы создаются с 0, так что без лишних действий
        }
    }
    return result;
}

int GetIndexOfMinimum (int [] arr)
{
    int min = arr[0];
    int result=0;
    for (int i=0; i<arr.Length;i++)
    {
        if (arr[i]<min)
        {
           min=arr[i];
           result=i;         
        }
    }
    return result+1;// зато с 0 начинаются элементы
}

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

void Print2Array (int [,] arr1,int [,] arr2)
{
 for (int i=0; i<arr1.GetLength(0);i++)
    {
        for (int j=0;j<arr1.GetLength(1);j++)
        {
           Console.Write ($"{arr1[i,j]} ");
        }
        Console.Write ("| ");
        for (int j=0;j<arr1.GetLength(1);j++)
        {
           Console.Write ($"{arr2[i,j]} ");
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