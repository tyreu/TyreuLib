using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//Ранг матрицы
//удалить элемент
//удалить строку
//удалить столбец
namespace Tyreu
{
    //class MyClass
    //{
    //    /// <summary>
    //    /// Сортировка матрицы построчная слева направо
    //    /// </summary>
    //    public Matrix Sort(Matrix matrix, bool reverse = false)
    //    {
    //        Matrix matrix2 = matrix.Clone();
    //        int[] retArray = matrix.ToArray();
    //        Array.Sort(retArray);
    //        if (reverse)
    //            Array.Reverse(retArray);
    //        matrix2.SetArray(retArray);
    //        return matrix2;
    //    }
    //    /// <summary>
    //    /// Поэлементное умножение массивов
    //    /// </summary>
    //    public static double[] MulArrayConst(double[] array, double number)
    //    {
    //        double[] ret = (double[])array.Clone();
    //        for (int i = 0; i < ret.Length; i++)
    //            ret[i] *= number;
    //        return ret;
    //    }
    //    /// <summary>
    //    /// Возвращает ранг матрицы.
    //    /// </summary>
    //    public static int Rank(Matrix matrix)
    //    {
    //        Matrix<double> matrix = mA.Clone();
    //        int order = mA.Size.X;
    //        //Приводим к треугольному виду
    //        for (int i = 0; i < order - 1; i++)
    //        {
    //            double[] masterRow = matrix.GetRow(i);
    //            double[] slaveRow = null;
    //            for (int t = i + 1; t < order; t++)
    //            {
    //                slaveRow = matrix.GetRow(t);
    //                double[] tmp = MulArrayConst(masterRow, slaveRow[i] / masterRow[i]);
    //                double[] source = matrix.GetRow(t);
    //                matrix.SetRow(SubArray(source, tmp), t);
    //            }
    //        }
    //        //Вычитаем количество строк нулей из общего количества строк
    //        for (int i = 0; i < matrix.Size.X; i++)
    //        {
    //            double[] row = matrix.GetRow(i);
    //            int countZero = 1;
    //            for (int t = 0; t < row.Length; t++)
    //            {
    //                if (row[t] != 0) break;
    //                countZero++;
    //            }
    //            if (countZero == row.Length) order--;
    //        }

    //        return order;
    //    }
    //    /// <summary>
    //    /// поэлементное вычитание массивов.
    //    /// </summary>
    //    public static int[] SubArray(int[] A, int[] B)
    //    {
    //        int[] ret = (int[])A.Clone();
    //        for (int i = 0; i < (A.Length > B.Length ? A.Length : B.Length); i++)
    //            ret[i] -= B[i];
    //        return ret;
    //    }
    //    #region Сортировка строк (все строки матрицы сортируются по возрастанию)
    //    /// <summary>
    //    /// Сортировка всех строк матрицы независимо друг от друга
    //    /// </summary>
    //    public static Matrix<T><int> SortRow(Matrix<T><int> mA, bool reverse = false)
    //    {
    //        Matrix<T> < int > ret = new Matrix<T>< int > (mA.Size.X, mA.Size.Y);
    //        for (int i = 0; i < mA.Size.X; i++)
    //        {
    //            int[] tmp = mA.GetRow(i);
    //            Array.Sort(tmp);
    //            if (reverse) Array.Reverse(tmp);
    //            ret.SetRow(tmp, i);
    //        }
    //        return ret;
    //    }

    //    /// <summary>
    //    /// Сортировка всех строк матрицы независимо друг от друга
    //    /// </summary>
    //    public static Matrix<T><double> SortRow(Matrix<T><double> mA, bool reverse = false)
    //    {
    //        Matrix<T> < double > ret = new Matrix<T>< double > (mA.Size.X, mA.Size.Y);
    //        for (int i = 0; i < mA.Size.X; i++)
    //        {
    //            double[] tmp = mA.GetRow(i);
    //            Array.Sort(tmp);
    //            if (reverse) Array.Reverse(tmp);
    //            ret.SetRow(tmp, i);
    //        }
    //        return ret;
    //    }

    //    #endregion

    //    #region Сортировка столбцов (все столбцы сортируются по возрастанию)
    //    /// <summary>
    //    /// Сортировка всех столбцов(полей) матрицы независимо друг от друга
    //    /// </summary>
    //    public static Matrix<T><int> SortColumn(Matrix<T><int> mA, bool reverse = false)
    //    {
    //        Matrix<T> < int > ret = new Matrix<T>< int > (mA.Size.X, mA.Size.Y);
    //        for (int i = 0; i < mA.Size.Y; i++)
    //        {
    //            int[] tmp = mA.GetColumn(i);
    //            Array.Sort(tmp);
    //            if (reverse) Array.Reverse(tmp);
    //            ret.SetColumn(tmp, i);
    //        }
    //        return ret;
    //    }

    //    /// <summary>
    //    /// Сортировка всех столбцов(полей) матрицы независимо друг от друга
    //    /// </summary>
    //    public static Matrix<T><double> SortColumn(Matrix<T><double> mA, bool reverse = false)
    //    {
    //        Matrix<T> < double > ret = new Matrix<T>< double > (mA.Size.X, mA.Size.Y);
    //        for (int i = 0; i < mA.Size.Y; i++)
    //        {
    //            double[] tmp = mA.GetColumn(i);
    //            Array.Sort(tmp);
    //            if (reverse) Array.Reverse(tmp);
    //            ret.SetColumn(tmp, i);
    //        }
    //        return ret;
    //    }

    //    #endregion

    //    #region Сортировка столбцов по строке (столбцы\поля располагаются в порядке возрастания указанной строки)
    //    /// <summary>
    //    /// Сортировка матрицы относительно строки
    //    /// </summary>
    //    public static Matrix<T><int> SortColumnOfRow(Matrix<T><int> mA, int row, bool reverse = false)
    //    {
    //        Matrix<T> < int > ret = new Matrix<T>< int > (mA.Size.X, mA.Size.Y);
    //        Dictionary<int, int> dict = new Dictionary<int, int>();
    //        int[] source = mA.GetRow(row);

    //        for (int i = 0; i < source.Length; i++)
    //            dict.Add(i, source[i]);

    //        Array.Sort(source);
    //        if (reverse) Array.Reverse(source);

    //        for (int i = 0; i < source.Length; i++)
    //        {
    //            int index = GetKeyByValue(dict, source[i]);
    //            ret.SetColumn(mA.GetColumn(index), i);
    //            dict.Remove(index);
    //        }

    //        return ret;
    //    }

    //    /// <summary>
    //    /// Сортировка матрицы относительно строки
    //    /// </summary>
    //    public static Matrix<T><double> SortColumnOfRow(Matrix<T><double> mA, int row, bool reverse = false)
    //    {
    //        Matrix<T> < double > ret = new Matrix<T>< double > (mA.Size.X, mA.Size.Y);
    //        Dictionary<int, double> dict = new Dictionary<int, double>();
    //        double[] source = mA.GetRow(row);

    //        for (int i = 0; i < source.Length; i++)
    //            dict.Add(i, source[i]);

    //        Array.Sort(source);
    //        if (reverse) Array.Reverse(source);

    //        for (int i = 0; i < source.Length; i++)
    //        {
    //            int index = GetKeyByValue(dict, source[i]);
    //            ret.SetColumn(mA.GetColumn(index), i);
    //            dict.Remove(index);
    //        }

    //        return ret;
    //    }
    //    #endregion

    //    #region Сортировка строк по столбцу (строки располагаются в порядке возрастания указанного столбца\поля)
    //    /// <summary>
    //    /// Сортировка матрицы относительно столбца
    //    /// </summary>
    //    public static Matrix<T><int> SortRowOfColumn(Matrix<T><int> mA, int column, bool reverse = false)
    //    {
    //        Matrix<T> < int > ret = new Matrix<T>< int > (mA.Size.X, mA.Size.Y);
    //        Dictionary<int, int> dict = new Dictionary<int, int>();
    //        int[] source = mA.GetColumn(column);

    //        for (int i = 0; i < source.Length; i++)
    //            dict.Add(i, source[i]);

    //        Array.Sort(source);
    //        if (reverse) Array.Reverse(source);

    //        for (int i = 0; i < source.Length; i++)
    //        {
    //            int index = GetKeyByValue(dict, source[i]);
    //            ret.SetRow(mA.GetRow(index), i);
    //            dict.Remove(index);
    //        }

    //        return ret;
    //    }

    //    /// <summary>
    //    /// Сортировка матрицы относительно столбца
    //    /// </summary>
    //    public static Matrix<T><double> SortRowOfColumn(Matrix<T><double> mA, int column, bool reverse = false)
    //    {
    //        Matrix<T> < double > ret = new Matrix<T>< double > (mA.Size.X, mA.Size.Y);
    //        Dictionary<int, double> dict = new Dictionary<int, double>();
    //        double[] source = mA.GetColumn(column);

    //        for (int i = 0; i < source.Length; i++)
    //            dict.Add(i, source[i]);

    //        Array.Sort(source);
    //        if (reverse) Array.Reverse(source);

    //        for (int i = 0; i < source.Length; i++)
    //        {
    //            int index = GetKeyByValue(dict, source[i]);
    //            ret.SetRow(mA.GetRow(index), i);
    //            dict.Remove(index);
    //        }

    //        return ret;
    //    }
    //    #endregion
    //    /// <summary>
    //    /// Возвращает матрицу без указанных строки и столбца. Исходная матрица не изменяется.
    //    /// </summary>
    //    public Matrix<T><T> Exclude(int row, int column)
    //    {
    //        if (row > Size.X || column > Size.Y) throw new IndexOutOfRangeException("Строка или столбец не принадлежат матрице.");
    //        Matrix<T> < T > ret = new Matrix<T>< T > ();
    //        ret.InitMatrix<T>(new SizeMatrix<T>(Size.X - 1, Size.Y - 1), TypeM);
    //        int offsetX = 0;
    //        for (int i = 0; i < Size.X; i++)
    //        {
    //            int offsetY = 0;
    //            if (i == row) { offsetX++; continue; }
    //            for (int t = 0; t < Size.Y; t++)
    //            {
    //                if (t == column) { offsetY++; continue; }
    //                ret[i - offsetX, t - offsetY] = this[i, t];
    //            }
    //        }
    //        return ret;
    //    }

    //    /// <summary>
    //    /// Возвращает матрицу без указанной строки. Исходная матрица не изменяется.
    //    /// </summary>
    //    public Matrix<T><T> ExcludeRow(params int[] row)
    //    {
    //        Matrix<T> < T > ret = new Matrix<T>< T > (Size.X - row.Length, Size.Y);
    //        int offset = 0;
    //        for (int i = 0; i < Size.X; i++)
    //        {
    //            if (!row.Contains(i))
    //            {
    //                T[] rows = this.GetRow(i);
    //                ret.SetRow(rows, i - offset);
    //            }
    //            else
    //                offset++;
    //        }
    //        if (ret.Size.X == ret.Size.Y) ret.TypeM = TypeMatrix<T>.Square;
    //        else
    //            ret.TypeM = TypeMatrix<T>.Rectangle;

    //        return ret;
    //    }

    //    /// <summary>
    //    /// Возвращает матрицу без указанного столбца. Исходная матрица не изменяется.
    //    /// </summary>
    //    public Matrix<T><T> ExcludeColumn(params int[] column)
    //    {
    //        Matrix<T> < T > ret = new Matrix<T>< T > (Size.X, Size.Y - column.Length);
    //        int offset = 0;
    //        for (int i = 0; i < Size.Y; i++)
    //        {
    //            if (!column.Contains(i))
    //            {
    //                T[] columns = this.GetColumn(i);
    //                ret.SetColumn(columns, i - offset);
    //            }
    //            else
    //                offset++;
    //        }
    //        if (ret.Size.X == ret.Size.Y) ret.TypeM = TypeMatrix<T>.Square;
    //        else
    //            ret.TypeM = TypeMatrix<T>.Rectangle;

    //        return ret;
    //    }

    //    /// <summary>
    //    /// Меняет местами диагонали матрицы. Исходная матрица не изменяется.
    //    /// </summary>
    //    /// <returns></returns>
    //    public Matrix<T><T> ReversDiagonal()
    //    {
    //        Matrix<T> < T > ret = Clone();
    //        if (ret.TypeM == TypeMatrix<T>.RandomRectangle || ret.TypeM == TypeMatrix<T>.Rectangle) throw new ArgumentException("Матрица не является квадратной.");

    //        int lenght = ret.Size.X;
    //        T[] tmp = new T[lenght];

    //        for (int i = 0; i < lenght; i++)
    //            tmp[i] = ret[i, i];

    //        for (int i = lenght - 1; i >= 0; i--)
    //        {
    //            ret[lenght - i - 1, lenght - i - 1] = ret[lenght - i - 1, i];
    //            ret[lenght - i - 1, i] = tmp[lenght - i - 1];
    //        }

    //        return ret;
    //    }
    //    public override string ToString()
    //    {
    //        StringBuilder ret = new StringBuilder();
    //        if (this.Size == SizeMatrix<T>.Zero) return ret.ToString();
    //        for (int i = 0; i < Size.X; i++)
    //        {
    //            for (int t = 0; t < Size.Y; t++)
    //            {
    //                ret.Append(matrix[i, t]);
    //                ret.Append("\t");
    //            }
    //            ret.Append("\n");
    //        }
    //        return ret.ToString();
    //    }

    //    /// <summary>
    //    /// Возвращает массив соответствующий указанной строке матрицы. Отсчет строк идет с 0.
    //    /// </summary>
    //    public T[] GetRow(int row)
    //    {
    //        if (row >= Size.X) throw new IndexOutOfRangeException("Индекс строки не принадлежит массиву.");
    //        T[] ret = new T[Size.Y];
    //        for (int i = 0; i < Size.Y; i++)
    //            ret[i] = (T)matrix[row, i];

    //        return ret;
    //    }

    //    /// <summary>
    //    /// Возвращает массив соответствующий указанному столбцу матрицы. Отсчет столбцов идет с 0.
    //    /// </summary>
    //    public T[] GetColumn(int column)
    //    {
    //        if (column >= Size.Y) throw new IndexOutOfRangeException("Индекс столбца(поля) не принадлежит массиву.");
    //        T[] ret = new T[Size.X];
    //        for (int i = 0; i < Size.X; i++)
    //            ret[i] = (T)matrix[i, column];

    //        return ret;
    //    }

    //    /// <summary>
    //    /// Заполняет указанную строку матрицы значениями из массива. Если размер массива и размер строки не совпадают, то строка будет - либо заполнена не полностью, либо "лишние" значения массива будут проигнорированы.
    //    /// </summary>
    //    public void SetRow(T[] rowValues, int row)
    //    {
    //        if (row >= Size.X) throw new IndexOutOfRangeException("Индекс строки не принадлежит массиву.");
    //        for (int i = 0; i < (Size.Y > rowValues.Length ? rowValues.Length : Size.Y); i++)
    //            matrix[row, i] = rowValues[i];
    //    }

    //    /// <summary>
    //    /// Заполняет указанный столбец значениями из массива. Если размеры столбца и массива не совпадают - столбец либо будет заполнен не полностью, либо "лишние" значения массива будут проигнорированы.
    //    /// </summary>
    //    public void SetColumn(T[] columnValues, int column)
    //    {
    //        if (column >= Size.Y) throw new IndexOutOfRangeException("Индекс столбца(поля) не принадлежит массиву.");
    //        for (int i = 0; i < (Size.X > columnValues.Length ? columnValues.Length : Size.X); i++)
    //            matrix[i, column] = columnValues[i];
    //    }
    //    /// <summary>
    //    /// Возвращает Matrix<T><int> преобразованную в Matrix<T><double>
    //    /// </summary>
    //    public static Matrix<T><double> ToDouble(Matrix<T><int> mA)
    //    {
    //        Matrix<T> < double > convertMatrix < T > = new Matrix<T>< double > (mA.Size.X, mA.Size.Y);
    //        double[] array = new double[mA.Size.X * mA.Size.Y];

    //        int i = 0;
    //        foreach (var item in mA)
    //            array[i++] = (double)item;

    //        convertMatrix<T>.SetArray(array);
    //        return convertMatrix<T>;
    //    }

    //    /// <summary>
    //    /// Возвращает Matrix<T><double> преобразованную в Matrix<T><int>
    //    /// </summary>
    //    public static Matrix<T><int> ToInt32(Matrix<T><double> mA)
    //    {
    //        Matrix<T> < int > matrix = new Matrix<T>< int > (mA.Size.X);
    //        int[] arrayint = new int[mA.Size.X * mA.Size.Y];

    //        int i = 0;
    //        foreach (var item in mA)
    //            arrayint[i++] = (int)item;

    //        matrix.SetArray(arrayint);

    //        return matrix;
    //    }
    //}
    public class Matrix : IEnumerator, IEnumerable
    {
        //Fields
        int currentRow = 0, currentColumn = 0;
        //Properties
        double[,] Array { get; set; }
        public int ColumnCount { get { return Array.GetLength(1); } }
        object IEnumerator.Current { get { return Array[currentRow, currentColumn]; } }
        public double Determinant
        {
            get
            {
                if (RowCount != ColumnCount) return -1;
                double[,] mas = Copy(Array, RowCount, ColumnCount);
                double det = 1; // Хранит определитель, который вернёт функция
                int n = Size; // Размерность матрицы
                int k = 0;
                const double E = 0.00000001; // Погрешность вычислений
                for (int i = 0; i < n; i++)
                {
                    k = i;
                    for (int j = i + 1; j < n; j++)
                        if (Math.Abs(mas[j, k]) > Math.Abs(mas[k, i]))
                            k = j;
                    if (Math.Abs(mas[k, i]) < E)
                        return -2;
                    SwapRow(mas, i, k);
                    if (i != k)
                        det *= -1;
                    det *= mas[i, i];
                    for (int j = i + 1; j < n; j++)
                        mas[i, j] /= mas[i, i];
                    for (int j = 0; j < n; j++)
                        if (j != i && Math.Abs(mas[j, i]) > E)
                            for (k = i + 1; k < n; k++)
                                mas[j, k] -= mas[i, k] * mas[j, i];
                }
                return det;
            }
        }
        public int RowCount { get { return Array.GetLength(0); } }
        /// <summary>
        /// Порядок матрицы, если она квадратна, иначе -1
        /// </summary>
        public int Size { get { return Array.GetLength(0) == Array.GetLength(1) ? Array.GetLength(0) : -1; } }
        //Constructors
        public Matrix()
        {
            Array = new double[1, 1];
            currentRow = currentColumn = 0;
        }
        public Matrix(int ColCount = 1)
        {
            Array = new double[1, ColCount];
            currentRow = currentColumn = 0;
        }
        public Matrix(int Row = 1, int Col = 1)
        {
            Array = new double[Row, Col];
            currentRow = currentColumn = 0;
        }
        public Matrix(double[,] array)
        {
            Array = Copy(array, array.GetLength(0), array.GetLength(0));
            currentRow = currentColumn = 0;
        }
        //Methods
        public void Add(double item)
        {
            if (currentRow == RowCount)
                AddRow();
            if (currentColumn < ColumnCount && currentRow < RowCount)
            {
                Array[currentRow, currentColumn] = item;
                currentColumn++;
                if (currentColumn == ColumnCount)
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }
        }
        void AddColumn() => Array = Copy(Array, RowCount, ColumnCount + 1);
        public void AddRange(params double[] array)
        {
            foreach (var item in array)
                Add(item);
        }
        void AddRow() => Array = Copy(Array, RowCount + 1, ColumnCount);
        public void Clear() => Array = new double[0, 0];
        public bool Contains(double item) => Array.OfType<double>().Contains(item);
        T[,] Copy<T>(T[,] sourceArray, int newRowSize, int newColSize)
        {
            T[,] newArray = new T[newRowSize, newColSize];
            for (int i = 0; i < sourceArray.GetLength(0); i++)
                for (int j = 0; j < sourceArray.GetLength(1); j++)
                    newArray[i, j] = sourceArray[i, j];
            return newArray;
        }
        public new bool Equals(object obj)
        {
            if (obj != null && GetType() == obj.GetType())
            {
                Matrix A = obj as Matrix;
                if (A.RowCount != RowCount && ColumnCount != A.ColumnCount)
                    return false;
                for (int i = 0; i < A.RowCount; i++)
                    for (int j = 0; j < A.ColumnCount; j++)
                        if (A[i, j] != this[i, j])
                            return false;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Возвращает матрицу обратную данной. 
        /// Обратная матрица существует только для квадратных, невырожденных, матриц. 
        /// </summary>
        public Matrix Inverse()
        {
            if (RowCount != ColumnCount) throw new ArgumentException("Кол-во строк не равно кол-ву столбцов!");
            double temp;
            double[,] E = new double[RowCount, ColumnCount];
            double[,] A = Copy(Array, RowCount, ColumnCount);
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < RowCount; j++)
                    if (i == j)
                        E[i, j] = 1.0;
            for (int k = 0; k < RowCount; k++)
            {
                temp = A[k, k];
                for (int j = 0; j < RowCount; j++)
                {
                    A[k, j] /= temp;
                    E[k, j] /= temp;
                }
                for (int i = k + 1; i < RowCount; i++)
                {
                    temp = A[i, k];
                    for (int j = 0; j < RowCount; j++)
                    {
                        A[i, j] -= A[k, j] * temp;
                        E[i, j] -= E[k, j] * temp;
                    }
                }
            }
            for (int k = RowCount - 1; k > 0; k--)
            {
                for (int i = k - 1; i >= 0; i--)
                {
                    temp = A[i, k];
                    for (int j = 0; j < RowCount; j++)
                    {
                        A[i, j] -= A[k, j] * temp;
                        E[i, j] -= E[k, j] * temp;
                    }
                }
            }
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < RowCount; j++)
                    A[i, j] = E[i, j];
            return new Matrix(A.GetLength(0), A.GetLength(1)) { Array = A };
        }
        #region foreach
        IEnumerator IEnumerable.GetEnumerator() => Array.GetEnumerator();
        bool IEnumerator.MoveNext()
        {
            if (currentColumn < ColumnCount && currentRow < RowCount)
            {
                currentColumn++;
                if (currentColumn == ColumnCount)
                {
                    currentColumn = 0;
                    currentRow++;
                }
                return true;
            }
            ((IEnumerator)this).Reset();
            return false;
        }
        void IEnumerator.Reset() => currentRow = currentColumn = 0;
        #endregion
        public Matrix Power(int exponent)
        {
            Matrix result = this;
            int j = 1;
            for (; j * 2 <= exponent; result *= result, j *= 2) ;
            for (; j < exponent; result *= this, j++) ;
            return result;
        }
        void SwapRow(double[,] mas, int row1, int row2)
        {
            double s = 0;
            for (int i = 0; i < this[row1].Count(); i++)
            {
                s = mas[row1, i];
                mas[row1, i] = mas[row2, i];
                mas[row2, i] = s;
            }
        }
        public override string ToString()
        {
            string result = string.Empty;
            result += "Matrix: " + RowCount + " rows, " + ColumnCount + " columns, " + "Det = " + Determinant;
            for (int i = 0; i < RowCount; result += '\n', i++)
                for (int j = 0; j < ColumnCount; result += string.Format("{0:0.##}\t", this[i, j]), j++) ;
            return result;
        }
        public Matrix Transpose()
        {
            double[,] arr = Copy(Array, RowCount, ColumnCount);
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    arr[j, i] = Array[i, j];
            Array = Copy(arr, RowCount, ColumnCount);
            return this;
        }
        //Indexers
        public double this[int row, int column]
        {
            get { return Array[row, column]; }
            set { Array[row, column] = value; }
        }
        public IEnumerable<double> this[int row]
        {
            get
            {
                for (int i = 0; i < ColumnCount; i++)
                    yield return Array[row, i];
            }
        }
        //Operators
        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.RowCount != B.RowCount || A.ColumnCount != B.ColumnCount)
                throw new ArgumentException("Складывать можно только матрицы одинакового размера.");
            Matrix C = new Matrix(A.RowCount, B.ColumnCount);
            for (int i = 0; i < A.RowCount; i++)
                for (int j = 0; j < B.ColumnCount; j++)
                    C[i, j] = A[i, j] + B[i, j];
            return C;
        }
        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.RowCount != B.RowCount || A.ColumnCount != B.ColumnCount)
                throw new ArgumentException("Вычитать можно только матрицы одинакового размера.");
            Matrix C = new Matrix(A.RowCount, B.ColumnCount);
            for (int i = 0; i < A.RowCount; i++)
                for (int j = 0; j < B.ColumnCount; j++)
                    C[i, j] = A[i, j] - B[i, j];
            return C;
        }
        public static Matrix operator *(Matrix A, int B)
        {
            Matrix C = new Matrix(A.RowCount, A.ColumnCount);
            for (int i = 0; i < A.RowCount; i++)
                for (int j = 0; j < A.ColumnCount; j++)
                    C[i, j] = A[i, j] * B;
            return C;
        }
        public static Matrix operator *(int B, Matrix A)
        {
            Matrix C = new Matrix(A.RowCount, A.ColumnCount);
            for (int i = 0; i < A.RowCount; i++)
                for (int j = 0; j < A.ColumnCount; j++)
                    C[i, j] = A[i, j] * B;
            return C;
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.ColumnCount != B.RowCount)
                throw new ArgumentException("Умножать матрицы можно тогда и только тогда, когда количество столбцов первой матрицы равно количеству строк второй матрицы.");
            Matrix C = new Matrix(A.RowCount, B.ColumnCount);
            for (int i = 0; i < A.RowCount; i++)
                for (int j = 0; j < B.ColumnCount; j++)
                    for (int k = 0; k < B.RowCount; k++)
                        C[i, j] += A[i, k] * B[k, j];
            return C;
        }
    }
}