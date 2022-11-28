using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace wpf2022
{
    /// <summary>
    /// Interaction logic for BranchDataWindow.xaml
    /// </summary>
    public partial class BranchDataWindow : Window
    {
        private dynamic m_model; 
        public BranchDataWindow(dynamic model, Label lab1)
        {
            InitializeComponent();
            m_model = model;


            var watch = new Stopwatch();
            watch.Start();

            int size = (int)m_model.Data.N_Nod;
            for (int i = 1; i < size; i++)
            {
                var nod = m_model.NodArray.Get(i);
                dataGrid1.Items.Add(new NodDTO()
                {
                    Name = nod.Name,
                    Typ = nod.Typ,
                    Vs = nod.Vs,
                    Pl = nod.Pl,
                    Ql = nod.Ql,
                    Pg = nod.Pg,
                    Qg = nod.Qg,
                    Qmin = nod.Qmin,
                    Qmax = nod.Qmax,
                    St = nod.St,
                    Vn = nod.Vn,
                    Vmin = nod.Vmin,
                    Vmax = nod.Vmax,
                    Comp = nod.Comp,
                    Area = nod.Area,
                    Zone = nod.Zone,
                    Regn = nod.Regn,
                    Vi = nod.Vi,
                    Di = nod.Di
                });
            }

            watch.Stop();
            lab1.Content = "Czas otwarcia okna z czytaniem danych kdm i od razu dodwaniem ich do kontrolki datagrid= " + watch.ElapsedMilliseconds.ToString();
        }
    }
}
