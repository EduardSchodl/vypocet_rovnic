FileStream fs = File.Open("matrix.txt", FileMode.Open);
StreamReader sr = new StreamReader(fs);

int[,] matrix = new int[3, 3];
int[] rigthSide = new int[3];
int[] result = new int[3];
int[] tempColumn = new int[3];

//naplnění matice čísly
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = Int32.Parse(sr.ReadLine());
    }
}

//uložení pravé strany
for(int i = 0; i < rigthSide.GetLength(0); i++)
{
    rigthSide[i] = Int32.Parse(sr.ReadLine());
}

//výpočet determinantu bez pravé strany Sarrusovo pravidlo
int determinant =
    matrix[0, 0] * matrix[1, 1] * matrix[2, 2]
  + matrix[1, 0] * matrix[2, 1] * matrix[0, 2]
  + matrix[2, 0] * matrix[0, 1] * matrix[1, 2]
  - matrix[0, 2] * matrix[1, 1] * matrix[2, 0]
  - matrix[1, 2] * matrix[2, 1] * matrix[0, 0]
  - matrix[2, 2] * matrix[0, 1] * matrix[1, 0];

//postupný výpočet všech determinantů s nahrazenými sloupci za pravou stranu
//pravá nahrazený sloupec se uloží a po vypočítaní determinantu se vloží zpět
//Cramerovo pravidlo
for (int i = 0; i <  matrix.GetLength(0); i++)
{
    for(int j = 0;j < matrix.GetLength(1); j++)
    {
        tempColumn[j] = matrix[j, i];
        matrix[j, i] = rigthSide[j];
    }
   
    result[i] = 
        matrix[0, 0] * matrix[1, 1] * matrix[2, 2]
      + matrix[1, 0] * matrix[2, 1] * matrix[0, 2]
      + matrix[2, 0] * matrix[0, 1] * matrix[1, 2]
      - matrix[0, 2] * matrix[1, 1] * matrix[2, 0]
      - matrix[1, 2] * matrix[2, 1] * matrix[0, 0]
      - matrix[2, 2] * matrix[0, 1] * matrix[1, 0];

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[j, i] = tempColumn[j];
    }
}

Console.WriteLine($"Výsledek: x={result[0]/determinant} y={result[1]/determinant} z={result[2]/determinant}");

sr.Close();
fs.Close();