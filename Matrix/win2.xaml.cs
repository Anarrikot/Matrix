using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace Matrix
{
    /// <summary>
    /// Логика взаимодействия для win2.xaml
    /// </summary>
    public partial class win2 : Window
    {
        private int x1, y1, x2, y2, type;
        private MatClass.IMat matrixA, matrixB, matrixC;

        private void Button_To_Solve(object sender, RoutedEventArgs e)
        {

            matrixA = SetType(x1, y1);
            matrixB = SetType(x2, y2);
            if (cb.SelectedIndex == 0)
            {
                matrixC = SetType(x1, y1);
                Solve_Plus();
            }
            else if (cb.SelectedIndex == 1)
            {
                matrixC = SetType(x1, y2);
                Solve_Multiply();
            }
            mat3.Visibility = Visibility.Visible;
            var dt3 = new DataTable();
            for (var i = 0; i < y2; i++)
                dt3.Columns.Add(new DataColumn("c" + (i + 1), typeof(string)));
            for (var i = 0; i < x1; i++)
            {
                var r = dt3.NewRow();
                for (var j = 0; j < y2; j++)
                {
                    if (type == 0)
                        r[j] = (matrixC as MatClass.Mat<Int32>).Arr[i, j];
                    else if (type == 1)
                        r[j] = (matrixC as MatClass.Mat<float>).Arr[i, j];
                    else
                        r[j] = (matrixC as MatClass.Mat<Double>).Arr[i, j];
                }
                dt3.Rows.Add(r);
            }
            mat3.ItemsSource = dt3.DefaultView;
            btnSave.Visibility = Visibility.Visible;
        }
        private void Solve_Plus()
        {
            if (type == 0)
            {
                SetValeInt(matrixA as MatClass.Mat<Int32>, 1);
                SetValeInt(matrixB as MatClass.Mat<Int32>, 2);
                matrixC = matrixC as MatClass.Mat<Int32>;
                matrixC = (matrixA as MatClass.Mat<Int32>) + (matrixB as MatClass.Mat<Int32>);
            }
            else if (type == 1)
            {
                SetValeFloat(matrixA as MatClass.Mat<float>, 1);
                SetValeFloat(matrixB as MatClass.Mat<float>, 2);
                matrixC = matrixC as MatClass.Mat<float>;
                matrixC = (matrixA as MatClass.Mat<float>) + (matrixB as MatClass.Mat<float>);
            }
            else
            {
                SetValeDouble(matrixA as MatClass.Mat<Double>, 1);
                SetValeDouble(matrixB as MatClass.Mat<Double>, 2);
                matrixC = matrixC as MatClass.Mat<Double>;
                matrixC = (matrixA as MatClass.Mat<Double>) + (matrixB as MatClass.Mat<Double>);
            }
        }

        private void Solve_Multiply()
        {
            if (type == 0)
            {
                SetValeInt(matrixA as MatClass.Mat<Int32>, 1);
                SetValeInt(matrixB as MatClass.Mat<Int32>, 2);
                matrixC = matrixC as MatClass.Mat<Int32>;
                matrixC = (matrixA as MatClass.Mat<Int32>) * (matrixB as MatClass.Mat<Int32>);
            }
            else if (type == 1)
            {
                SetValeFloat(matrixA as MatClass.Mat<float>, 1);
                SetValeFloat(matrixB as MatClass.Mat<float>, 2);
                matrixC = matrixC as MatClass.Mat<float>;
                matrixC = (matrixA as MatClass.Mat<float>) * (matrixB as MatClass.Mat<float>);
            }
            else
            {
                SetValeDouble(matrixA as MatClass.Mat<Double>, 1);
                SetValeDouble(matrixB as MatClass.Mat<Double>, 2);
                matrixC = matrixC as MatClass.Mat<Double>;
                matrixC = (matrixA as MatClass.Mat<Double>) * (matrixB as MatClass.Mat<Double>);
            }
        }

        private void Button_Random(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            var dt1 = new DataTable();
            for (var i = 0; i < y1; i++)
                dt1.Columns.Add(new DataColumn("c" + (i + 1), typeof(string)));
            for (var i = 0; i < x1; i++)
            {
                var r = dt1.NewRow();
                for (var j = 0; j < y1; j++)
                    r[j] = rnd.Next(0,100);
                dt1.Rows.Add(r);
            }
            mat1.ItemsSource = dt1.DefaultView;
            var dt2 = new DataTable();
            for (var i = 0; i < y2; i++)
                dt2.Columns.Add(new DataColumn("c" + (i + 1), typeof(string)));
            for (var i = 0; i < x2; i++)
            {
                var r = dt2.NewRow();
                for (var j = 0; j < y2; j++)
                    r[j] = rnd.Next(0, 100);
                dt2.Rows.Add(r);
            }
            mat2.ItemsSource = dt2.DefaultView;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (type == 0)
                System.IO.File.WriteAllText("E://matric.csv", (matrixC as MatClass.Mat<Int32>).Save());
            else if (type == 1)
                System.IO.File.WriteAllText("E://matric.csv", (matrixC as MatClass.Mat<float>).Save());
            else
                System.IO.File.WriteAllText("E://matric.csv", (matrixC as MatClass.Mat<Double>).Save());
        }

        private void SetValeInt(MatClass.Mat<Int32> mat, int tab)
        {
            if (tab == 1)
                for (int i = 0; i < mat.Row; i++)
                    foreach (DataRowView row in mat1.Items)
                    {
                        for (int j = 0; j < mat.Column; j++)
                            mat.Arr[i, j] = Convert.ToInt32(row.Row.ItemArray[j]);
                        i++;
                    }
            else
                for (int i = 0; i < mat.Row; i++)
                    foreach (DataRowView row in mat2.Items)
                    {
                        for (int j = 0; j < mat.Column; j++)
                            mat.Arr[i, j] = Convert.ToInt32(row.Row.ItemArray[j]);
                        i++;
                    }
        }
        private void SetValeFloat(MatClass.Mat<float> mat, int tab)
        {
            if (tab == 1)
                for (int i = 0; i < mat.Row; i++)
                    foreach (DataRowView row in mat1.Items)
                    {
                        for (int j = 0; j < mat.Column; j++)
                            mat.Arr[i, j] = Convert.ToSingle(row[j]);
                        i++;
                    }
            else
                for (int i = 0; i < mat.Row; i++)
                    foreach (DataRowView row in mat2.Items)
                    {
                        for (int j = 0; j < mat.Column; j++)
                            mat.Arr[i, j] = Convert.ToSingle(row[j]);
                        i++;
                    }
        }
        private void SetValeDouble(MatClass.Mat<Double> mat, int tab)
        {
            if (tab == 1)
                for (int i = 0; i < mat.Row; i++)
                    foreach (DataRowView row in mat1.Items)
                    {
                        for (int j = 0; j < mat.Column; j++)
                            mat.Arr[i, j] = Convert.ToDouble(row[j]);
                        i++;
                    }
            else
                for (int i = 0; i < mat.Row; i++)
                    foreach (DataRowView row in mat2.Items)
                    {
                        for (int j = 0; j < mat.Column; j++)
                            mat.Arr[i, j] = Convert.ToDouble(row[j]);
                        i++;
                    }
        }

        public MatClass.IMat SetType(int row, int colown)
        {
            if (type == 0)
                return new MatClass.Mat<Int32>(row, colown);
            else if (type == 1)
                return new MatClass.Mat<float>(row, colown);
            else
                return new MatClass.Mat<Double>(row, colown);
        }

        public win2(int x1, int y1, int x2, int y2, int type)
        {
            InitializeComponent();
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.type = type;
            FillDG();
        }

        public void FillDG()
        {
            var dt1 = new DataTable();
            for (var i = 0; i < y1; i++)
                dt1.Columns.Add(new DataColumn("c" + (i + 1), typeof(string)));
            for (var i = 0; i < x1; i++)
            {
                var r = dt1.NewRow();
                for (var c = 0; c < y1; c++)
                    r[c] = 1;
                dt1.Rows.Add(r);
            }
            mat1.ItemsSource = dt1.DefaultView;
            var dt2 = new DataTable();
            for (var i = 0; i < y2; i++)
                dt2.Columns.Add(new DataColumn("c" + (i + 1), typeof(string)));
            for (var i = 0; i < x2; i++)
            {
                var r = dt2.NewRow();
                for (var j = 0; j < y2; j++)
                    r[j] = 1;
                dt2.Rows.Add(r);
            }
            mat2.ItemsSource = dt2.DefaultView;
        }
    }
}
