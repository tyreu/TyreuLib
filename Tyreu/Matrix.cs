using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tyreu
{
    public class Matrix : IEnumerator, IEnumerable
    {
        //Fields
        int currentRow = 0, currentColumn = 0;
        //Properties
        /// <summary>
        /// 
        /// </summary>
        double[,] Array { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ColumnCount { get => Array.GetLength(1); }
        object IEnumerator.Current { get => Array[currentRow, currentColumn]; }
        /// <summary>
        /// 
        /// </summary>
        public double Determinant
        {
            get
            {
                if (RowCount != ColumnCount) return -1;
                double[,] mas = CopyArray(Array, RowCount, ColumnCount);
                double det = 1; // Хранит определитель, который вернёт функция
                int n = Size; // Размерность матрицы
                int k = 0;
                const double E = 0.00001; // Погрешность вычислений
                for (int i = 0; i < n; i++)
                {
                    k = i;
                    for (int j = i + 1; j < n; j++)
                        if (Math.Abs(mas[j, k]) > Math.Abs(mas[k, i]))
                            k = j;
                    if (Math.Abs(mas[k, i]) < E) return Number.NaN;
                    SwapRow(mas, i, k);
                    if (i != k)
                        det *= -1;
                    det *= mas[i, i];
                    for (int j = i + 1; j < n; mas[i, j] /= mas[i, i], j++) ;
                    for (int j = 0; j < n; j++)
                        if (j != i && Math.Abs(mas[j, i]) > E)
                            for (k = i + 1; k < n; mas[j, k] -= mas[i, k] * mas[j, i], k++) ;
                }
                return det;
            }
        }
        /// <summary>
        /// Возвращает ранг матрицы.
        /// </summary>
        public int Rank
        {
            get
            {
                Matrix matrix = new Matrix(Array);
                int order = RowCount;
                //Приводим к треугольному виду
                for (int i = 0; i < order - 1; i++)
                {
                    double[] masterRow = matrix.GetRow(i);
                    double[] slaveRow = null;
                    for (int t = i + 1; t < order; t++)
                    {
                        slaveRow = matrix.GetRow(t);
                        double[] tmp = MulArray(masterRow, slaveRow[i] / masterRow[i]);
                        double[] source = matrix.GetRow(t);
                        matrix.SetRow(SubArray(source, tmp), t);
                    }
                }
                //Вычитаем количество строк нулей из общего количества строк
                for (int i = 0; i < matrix.RowCount; i++)
                {
                    double[] row = matrix.GetRow(i);
                    int countZero = 1;
                    for (int t = 0; t < row.Length; t++)
                    {
                        if (row[t] != 0)
                            break;
                        countZero++;
                    }
                    if (countZero == row.Length)
                        order--;
                }
                return order;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RowCount { get => Array.GetLength(0); }
        /// <summary>
        /// Порядок матрицы, если она квадратна, иначе -1
        /// </summary>
        public int Size { get => Array.GetLength(0) == Array.GetLength(1) ? Array.GetLength(0) : -1; }
        //Constructors
        /// <summary>
        /// 
        /// </summary>
        public Matrix()
        {
            Array = new double[1, 1];
            currentRow = currentColumn = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ColCount"></param>
        public Matrix(int ColCount = 1)
        {
            Array = new double[1, ColCount];
            currentRow = currentColumn = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Col"></param>
        public Matrix(int Row = 1, int Col = 1)
        {
            Array = new double[Row, Col];
            currentRow = currentColumn = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public Matrix(double[,] array)
        {
            Array = array;
            currentRow = currentColumn = 0;
        }
        //Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
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
        /// <summary>
        /// 
        /// </summary>
        void AddColumn() => Array = CopyArray(Array, RowCount, ColumnCount + 1);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public void AddRange(params double[] array)
        {
            foreach (var item in array)
                Add(item);
        }
        /// <summary>
        /// 
        /// </summary>
        void AddRow() => Array = CopyArray(Array, RowCount + 1, ColumnCount);
        /// <summary>
        /// 
        /// </summary>
        public void Clear() => Array = new double[0, 0];
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(double item) => Array.OfType<double>().Contains(item);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceArray"></param>
        /// <param name="newRowSize"></param>
        /// <param name="newColSize"></param>
        /// <returns></returns>
        T[,] CopyArray<T>(T[,] sourceArray, int newRowSize, int newColSize)
        {
            T[,] newArray = new T[newRowSize, newColSize];
            for (int i = 0; i < sourceArray.GetLength(0); i++)
                for (int j = 0; j < sourceArray.GetLength(1); j++)
                    newArray[i, j] = sourceArray[i, j];
            return newArray;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        /// Возвращает матрицу без указанных строки и столбца. Исходная матрица не изменяется.
        /// </summary>
        public Matrix Exclude(int row, int column)
        {
            if (row > RowCount || column > ColumnCount) throw new IndexOutOfRangeException("Строка или столбец не принадлежат матрице.");
            Matrix result = new Matrix(RowCount - 1, ColumnCount - 1);
            for (int i = 0, x = 0; i < RowCount; i++)
            {
                if (i != row)
                {
                    for (int j = 0, y = 0; j < ColumnCount; j++)
                        if (j != column)
                            result[x, y++] = this[i, j];
                    x++;
                }
            }
            return result;
        }
        /// <summary>
        /// Возвращает матрицу без указанного столбца. Исходная матрица не изменяется.
        /// </summary>
        public Matrix ExcludeColumn(int ColumnNumber)
        {
            Matrix result = new Matrix(RowCount, ColumnCount - 1);
            for (int i = 0, x = 0; i < ColumnCount; i++)
                if (i != ColumnNumber)
                    result.SetColumn(GetColumn(i), x++);
            return result;
        }
        /// <summary>
        /// Возвращает матрицу без указанной строки. Исходная матрица не изменяется.
        /// </summary>
        public Matrix ExcludeRow(int RowNumber)
        {
            Matrix result = new Matrix(RowCount - 1, ColumnCount);
            for (int i = 0, x = 0; i < RowCount; i++)
                if (i != RowNumber)
                    result.SetRow(GetRow(i), x++);
            return result;
        }
        /// <summary>
        /// Возвращает массив соответствующий указанной строке матрицы. Отсчет строк идет с 0.
        /// </summary>
        public double[] GetRow(int row)
        {
            if (row >= RowCount) throw new IndexOutOfRangeException("Индекс строки не принадлежит массиву.");
            double[] result = new double[ColumnCount];
            for (int i = 0; i < ColumnCount; i++)
                result[i] = this[row, i];
            return result;
        }
        /// <summary>
        /// Возвращает массив соответствующий указанному столбцу матрицы. Отсчет столбцов идет с 0.
        /// </summary>
        public double[] GetColumn(int column)
        {
            if (column >= ColumnCount) throw new IndexOutOfRangeException("Индекс столбца(поля) не принадлежит массиву.");
            double[] result = new double[RowCount];
            for (int i = 0; i < RowCount; i++)
                result[i] = this[i, column];
            return result;
        }
        /// <summary>
        /// Поэлементное умножение массивов
        /// </summary>
        public static double[] MulArray(double[] array, double number)
        {
            double[] ret = (double[])array.Clone();
            for (int i = 0; i < ret.Length; ret[i] *= number, i++) ;
            return ret;
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
            double[,] A = CopyArray(Array, RowCount, ColumnCount);
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
        /// <summary>
        /// Меняет местами диагонали матрицы. Исходная матрица не изменяется.
        /// </summary>
        /// <returns></returns>
        public Matrix ReverseDiagonal()
        {
            Matrix result = this;
            if (RowCount != ColumnCount) throw new ArgumentException("Матрица не является квадратной.");

            int length = RowCount;
            double[] tmp = new double[length];
            for (int i = 0; i < length; i++)
                tmp[i] = result[i, i];
            for (int i = length - 1; i >= 0; i--)
            {
                result[length - i - 1, length - i - 1] = result[length - i - 1, i];
                result[length - i - 1, i] = tmp[length - i - 1];
            }
            return result;
        }
        /// <summary>
        /// Заполняет указанный столбец значениями из массива. Если размеры столбца и массива не совпадают - столбец либо будет заполнен не полностью, либо "лишние" значения массива будут проигнорированы.
        /// </summary>
        public void SetColumn(double[] columnValues, int column)
        {
            if (column >= ColumnCount) throw new IndexOutOfRangeException("Индекс столбца(поля) не принадлежит массиву.");
            for (int i = 0; i < (RowCount > columnValues.Length ? columnValues.Length : RowCount); i++)
                this[i, column] = columnValues[i];
        }
        /// <summary>
        /// Заполняет указанную строку матрицы значениями из массива. Если размер массива и размер строки не совпадают, то строка будет - либо заполнена не полностью, либо "лишние" значения массива будут проигнорированы.
        /// </summary>
        public void SetRow(double[] rowValues, int row)
        {
            if (row >= RowCount) throw new IndexOutOfRangeException("Индекс строки не принадлежит массиву.");
            for (int i = 0; i < (ColumnCount > rowValues.Length ? rowValues.Length : ColumnCount); i++)
                this[row, i] = rowValues[i];
        }
        /// <summary>
        /// Сортировка всех столбцов(полей) матрицы независимо друг от друга
        /// </summary>
        public static Matrix SortColumn(Matrix mA, bool reverse = false)
        {
            Matrix ret = new Matrix(mA.RowCount, mA.ColumnCount);
            for (int i = 0; i < mA.ColumnCount; i++)
            {
                double[] tmp = mA.GetColumn(i);
                System.Array.Sort(tmp);
                if (reverse) System.Array.Reverse(tmp);
                ret.SetColumn(tmp, i);
            }
            return ret;
        }
        /// <summary>
        /// Сортировка всех строк матрицы независимо друг от друга
        /// </summary>
        public static Matrix SortRow(Matrix mA, bool reverse = false)
        {
            Matrix ret = new Matrix(mA.RowCount, mA.ColumnCount);
            for (int i = 0; i < mA.RowCount; i++)
            {
                double[] tmp = mA.GetRow(i);
                System.Array.Sort(tmp);
                if (reverse) System.Array.Reverse(tmp);
                ret.SetRow(tmp, i);
            }
            return ret;
        }
        /// <summary>
        /// Поэлементное вычитание массивов.
        /// </summary>
        public static double[] SubArray(double[] A, double[] B)
        {
            double[] ret = (double[])A.Clone();
            for (int i = 0; i < (A.Length > B.Length ? A.Length : B.Length); ret[i] -= B[i], i++) ;
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="FirstRow"></param>
        /// <param name="SecondRow"></param>
        public void SwapRow(double[,] mas, int FirstRow, int SecondRow)
        {
            double s = 0;
            for (int i = 0; i < this[FirstRow].Count(); i++)
            {
                s = mas[FirstRow, i];
                mas[FirstRow, i] = mas[SecondRow, i];
                mas[SecondRow, i] = s;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = string.Empty;
            result += $"Matrix: {RowCount} rows, {ColumnCount} columns, Det = {Determinant}\n";
            for (int i = 0; i < RowCount; result += '\n', i++)
                for (int j = 0; j < ColumnCount; result += string.Format("{0:0.##}\t", this[i, j]), j++) ;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Matrix Transpose()
        {
            double[,] arr = new double[ColumnCount, RowCount];
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    arr[j, i] = Array[i, j];
            Array = CopyArray(arr, ColumnCount, RowCount);
            return this;
        }
        //Indexers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public double this[int row, int column]
        {
            get { return Array[row, column]; }
            set { Array[row, column] = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public IEnumerable<double> this[int row]
        {
            get
            {
                for (int i = 0; i < ColumnCount; i++)
                    yield return Array[row, i];
            }
        }
        //Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix A, int B)
        {
            Matrix C = new Matrix(A.RowCount, A.ColumnCount);
            for (int i = 0; i < A.RowCount; i++)
                for (int j = 0; j < A.ColumnCount; j++)
                    C[i, j] = A[i, j] * B;
            return C;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="B"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static Matrix operator *(int B, Matrix A)
        {
            Matrix C = new Matrix(A.RowCount, A.ColumnCount);
            for (int i = 0; i < A.RowCount; i++)
                for (int j = 0; j < A.ColumnCount; j++)
                    C[i, j] = A[i, j] * B;
            return C;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
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