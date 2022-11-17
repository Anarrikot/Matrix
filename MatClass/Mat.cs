using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MatClass
{
    public class Mat<T>: IMat
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public T [,] Arr { get; set; }

        public Mat(int Row, int Column)
        {
            if (Row > 0 && Column > 0)
            {
                this.Row = Row;
                this.Column = Column;
                this.Arr = new T[Row, Column];
            }
            else
                throw new Exception("Неправильно введены количества столбцов и строк!");
        }
        public static T Add<U>(U x, U y)
        {
            dynamic x1 = x, y1 = y;
            return x1 + y1;
        }
        public static T Mult<U>(U x, U y)
        {
            dynamic x1 = x, y1 = y;
            return x1 * y1;
        }

        public static Mat<T> operator +(Mat<T> MatrixA, Mat<T> MatrixB)
        {
            Mat<T> MatrixResult = new Mat<T>(MatrixA.Row, MatrixA.Column);
            if (MatrixA.Row == MatrixB.Row && MatrixA.Column == MatrixB.Column)
            {
                for (int i = 0; i < MatrixA.Row; i++)
                    for (int j = 0; j < MatrixA.Column; j++)
                         MatrixResult.Arr[i, j] =  Add(MatrixA.Arr[i, j],MatrixB.Arr[i, j]);
            }
            else
                throw new Exception("Число столбцов не равно числу строк");
            return MatrixResult;
        }

        public static Mat<T> operator *(Mat<T> MatrixA, Mat<T> MatrixB)
        {
            Mat<T> MatrixResult = new Mat<T>(MatrixA.Row, MatrixB.Column);
            if (MatrixA.Column == MatrixB.Row)
            {
                for (int i = 0; i < MatrixA.Row; i++)
                    for (int j = 0; j < MatrixB.Column; j++)
                        for (int k = 0; k < MatrixB.Row; k++)
                        {
                            MatrixResult.Arr[i, j] = Add(MatrixResult.Arr[i, j], Mult(MatrixA.Arr[i, k], MatrixB.Arr[k, j]));
                        }
            }
            else
                throw new Exception("Число столбцов не равно числу строк");
            return MatrixResult;
        }

        public string Save()
        {
            StringBuilder save = new StringBuilder();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    save.Append(Arr[i, j]);
                    save.Append(";");
                }
                save.Append("\n");
            }
            return save.ToString();
        }
    }
}
