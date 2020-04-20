using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WPF_Lab2_TPR;

namespace TPRLibrary
{
    public class Matrix
    {
        public delegate void Log(string text);

        public Log Logger;

        private readonly List<List<double>> matrix;

        public double[,] values => matrix.To2DArray();

        public static Matrix ReadFromCsv(string path)
        {
            var csv = File
                    .ReadAllLines(path)
                    .Select(a => Array.ConvertAll(a.Split(';'), Double.Parse)).To2DArray();
            return new Matrix(csv);
        }

        ///*<summary>
        ///*Cоздание*матрицы.
        ///*</summary>
        ///*<param*name="rowsCount">Количество*строк.</param>
        ///*<param*name="columnCount">Количество*столбцов.</param>
        public Matrix(int rowsCount = 2, int columnCount = 2)
        {
            ColumnCount = columnCount;
            RowsCount = rowsCount;
            matrix = new List<List<double>>(rowsCount);
            for (int i = 0; i < rowsCount; i++)
            {
                var list = new List<double>(columnCount);
                for (int j = 0; j < columnCount; j++)
                {
                    list.Add(default(double));
                }
                matrix.Add(list);
            }
        }

        ///*<summary>
        ///*Cоздание*матрицы.
        ///*</summary>
        ///*<param*name="data">Исходный*двумерный*массив.</param>
        public Matrix(double[,] data)
        {
            RowsCount = data.GetLength(0);
            ColumnCount = data.GetLength(1);
            matrix = new List<List<double>>(RowsCount);
            for (int i = 0; i < RowsCount; i++)
            {
                var list = new List<double>(ColumnCount);
                for (int j = 0; j < ColumnCount; j++)
                {
                    list.Add(data[i, j]);
                }
                matrix.Add(list);
            }
        }

        public Matrix(List<List<double>> data)
        {
            if (!data.TrueForAll(x => x.Count == data.First().Count))
                throw new Exception("wrong data");

            RowsCount = data.Count;
            ColumnCount = data.First().Count;
            matrix = data;
        }

        ///*<summary>
        ///*Элемент*матрицы.
        ///*</summary>
        ///*<param*name="i">Индекс*строки.</param>
        ///*<param*name="j">Индекс*столбца.</param>
        ///*<returns></returns>
        public double this[int i, int j]
        {
            get { return matrix[i][j]; }
            set { matrix[i][j] = value; }
        }

        ///*<summary>
        ///*Количество*строк.
        ///*</summary>
        public int RowsCount { get; private set; }

        ///*<summary>
        ///*Количество*столбцов.
        ///*</summary>
        public int ColumnCount { get; private set; }

        ///*<summary>
        ///*Добавить*строку.
        ///*</summary>
        ///*<param*name="index">Индекс*вставки*строки.</param>
        public void AddRow(int index, List<double> values)
        {
            if (values.Count != ColumnCount)
            {
                throw new Exception("Wrong values");
            }
            RowsCount++;
            matrix.Insert(index, values);
        }

        ///*<summary>
        ///*Добавить*столбец.
        ///*</summary>
        ///*<param*name="index">Индекс*вставки*столбца.</param>
        public void AddColumn(int index, List<double> values)
        {
            if (values.Count != RowsCount)
            {
                throw new Exception("Wrong values");
            }
            ColumnCount++;
            for (int i = 0; i < RowsCount; i++)
            {
                matrix[i].Insert(index, values[i]);
            }
        }

        ///*<summary>
        ///*Удалить*строку.
        ///*</summary>
        ///*<param*name="index">Индекс*вставки*строки.</param>
        public void RemoveRow(int index)
        {
            RowsCount--;
            matrix.RemoveAt(index);
        }

        ///*<summary>
        /// Удалить столбец.
        ///*</summary>
        ///*<param*name="index">Индекс*вставки*столбца.</param>
        public void RemoveColumn(int index)
        {
            ColumnCount--;
            foreach (var list in matrix)
            {
                list.RemoveAt(index);
            }
        }

        ///*<summary>
        ///*Получить*столбец.
        ///*</summary>
        ///*<param*name="j">Индекс*получаемого*столбца.</param>
        public List<double> Column(int j)
        {
            List<double> ts = new List<double>();

            for (int i = 0; i < RowsCount; i++)
            {
                ts.Add(matrix[i][j]);
            }
            return ts;
        }

        ///*<summary>
        /// Получить строку.
        ///*</summary>
        ///*<param*name="i">Индекс строки.</param>
        public List<double> Row(int i)
        {
            return matrix[i];
        }

        ///*<summary>
        /// Клонирование текущей матрицы.
        ///*</summary>
        public Matrix Clone()
        {
            var mtrx = new Matrix(this.RowsCount, this.ColumnCount);
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    mtrx[i, j] = this[i, j];
                }
            }
            mtrx.Logger = this.Logger;
            return mtrx;
        }
    
        private Matrix _tryRemoveColumn(bool isStrong,out bool IsDeleted)
        {
            var matrix = this;
            var resultMatrix = matrix.Clone();

            IsDeleted = false;
            for (int i = 0; i < matrix.ColumnCount; i++) 
            {
                var column = matrix.Column(i);             

                for (int j = 0; j < matrix.ColumnCount; j++) 
                {
                    if (i == j) 
                        continue;
                    bool isDeletingColumn = true;
                    var anotherColumn = matrix.Column(j); 

                    for (int k = 0; k < column.Count; k++)
                    {
                        if (!isStrong)
                        {
                            if (column[k].CompareTo(anotherColumn[k]) > 0) // > ( =<)
                            {
                                isDeletingColumn = false;
                                break;
                            }
                        }
                        else
                        {
                            if (column[k].CompareTo(anotherColumn[k]) >= 0) // <
                            {
                                isDeletingColumn = false;
                                break;
                            }
                        }
                    }

                    if (isDeletingColumn)
                    {
                        resultMatrix.RemoveColumn(j);
                        Logger?.Invoke($"столбец {i+1} над {j+1}");
                        IsDeleted = true;
                        return resultMatrix;
                    }
                }
            }
            return matrix;
        }

        private Matrix _tryRemoveRow(bool isStrong,out bool IsDeleted)
        {
            var matrix = this;

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                var row = matrix.Row(i);
                             
                for (int j = 0; j < matrix.RowsCount; j++)
                {
                    if (i == j)
                        continue;
                    bool isDeletingRow = true;
                    var anotherRow = matrix.Row(j);

                    for (int k = 0; k < row.Count; k++)
                    {
                        if (!isStrong)
                        {
                            if (row[k].CompareTo(anotherRow[k]) < 0)
                            {
                                isDeletingRow = false;
                                break;
                            }
                        }
                        else
                        {
                            if (row[k].CompareTo(anotherRow[k]) <= 0)
                            {
                                isDeletingRow = false;
                                break;
                            }
                        }
                    }

                    if (isDeletingRow)
                    {
                        var result = matrix.Clone();
                        result.RemoveRow(j);
                        IsDeleted = true;
                        Logger?.Invoke($"строка {i+1} над {j+1}");
                        return result;
                    }
                }
            }
            IsDeleted = false;
            return matrix;
        }

        public Matrix Reduction(bool IsStrong)
        {
            var matrix = this.Clone();
            bool next = true;
            while (next)
            {
                matrix = matrix._tryRemoveColumn(IsStrong,out next);

                bool row = true;
                while (row)
                {
                    matrix = matrix._tryRemoveRow(IsStrong,out row);
                    next |= row;
                }
            }
            return matrix;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    stringBuilder.Append(matrix[i][j]);
                    stringBuilder.Append("*");
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
