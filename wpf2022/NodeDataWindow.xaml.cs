using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Python.Runtime;

namespace wpf2022
{
    public partial class NodeDataWindow : Window
    {
        private dynamic m_model; //zmienna przechowujaca model

        public NodeDataWindow(Label lab1, List<NodDTO> list)
        {
            InitializeComponent();
            
            var watch = new Stopwatch();
            watch.Start();
            this.dataGrid1.ItemsSource = list;
            watch.Stop();

            lab1.Content = "Czas otwarcia okna= " + watch.ElapsedMilliseconds.ToString();

        }
        public NodeDataWindow(dynamic model, Label lab1, ObservableCollection<NodDTO> list)
        {
            InitializeComponent();
            this.m_model = model;

            var watch = new Stopwatch();
            watch.Start();

           // this.dataGrid1.ItemsSource = list;
            
            watch.Stop();
            lab1.Content = "Czas otwarcia okna z wczytanymi danymi kdm wczesniej, podpiecie danych do kontrolki= " + watch.ElapsedMilliseconds.ToString();


            //using (Py.GIL())
            //{
            //for (int i = 0; i < (int)m_model.Data.N_Nod; i++)
            //{
            //    var nod = m_model.NodArray.Get(i);
            //    ListView1.Items.Add("Name = " + nod.Name + " Typ= " + nod.Typ + " Vn= " + nod.Vn);
            //}

            //    ObservableCollection<NodDTO> list = new ObservableCollection<NodDTO>();
            //    for (int i = 1; i < (int)m_model.Data.N_Nod; i++)
            //    {
            //        var nod = m_model.NodArray.Get(i);
            //        list.Add(new NodDTO()
            //        {
            //            Name = nod.Name,
            //            Typ = nod.Typ,
            //            Vs = nod.Vs,
            //            Pl = nod.Pl,
            //            Ql = nod.Ql,
            //            Pg = nod.Pg,
            //            Qg = nod.Qg,
            //            Qmin = nod.Qmin,
            //            Qmax = nod.Qmax,
            //            St = nod.St,
            //            Vn = nod.Vn,
            //            Vmin = nod.Vmin,
            //            Vmax = nod.Vmax,
            //            Comp = nod.Comp,
            //            Area = nod.Area,
            //            Zone = nod.Zone,
            //            Regn = nod.Regn,
            //            Vi = nod.Vi,
            //            Di = nod.Di
            //        });
            //    }
            //    this.dataGrid1.ItemsSource = list;          
            //}

            //watch.Stop();
            //lab1.Content = watch.ElapsedMilliseconds;
        }
    }
}
