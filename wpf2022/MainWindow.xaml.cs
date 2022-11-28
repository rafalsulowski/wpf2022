using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Office.Utils;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraScheduler;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using Python.Runtime;
using static wpf2022.NodeDataWindow;

namespace wpf2022
{
    public partial class MainWindow : Window
    {
#if RELEASE
        const string dllPath = @"C:\Users\01159502\Desktop\plans2\bin\vs2019\Release";
#else
        const string dllPath = @"C:\Users\01159502\Desktop\plans2\bin\vs2019\debug";
#endif


        public dynamic PlansAppObject;
        private dynamic m_model;

        ObservableCollection<NodDTO> nodDataList;
        private bool isInitialized = false;

        public List<Rec> listTest;

        public MainWindow()
        {
            InitializeComponent(); //inicjalizacja okna

            Runtime.PythonDLL = @"C:\Program Files (x86)\Python310-32\python310.dll"; //konfiguracja
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", Runtime.PythonDLL); //konfiguracja

            PythonEngine.Initialize();

            dynamic sys = Py.Import("sys");
            sys.path.append(dllPath); //dodanie sciezki do PlansPy3

            PlansAppObject = Py.Import("PlansPy3");  //import biblioteki PlansPy3
            this.m_model = PlansAppObject.CModelSEE();

        }

        private void OpenNodeDataWindowClick(object sender, RoutedEventArgs e)
        {
            NodeDataWindow nodeDataWindow = new NodeDataWindow(this.m_model, this.labShow1, this.nodDataList);
            nodeDataWindow.Show();
            //nodeDataWindow.ShowDialog(); //zamrozi poprzednie okno do momentu zamkniecia
        }

        private void OpenBranchDataWindowClick(object sender, RoutedEventArgs e)
        {
            BranchDataWindow branchDataWindow = new BranchDataWindow(this.m_model, labShow2);
            branchDataWindow.Show();
        }

        private void OpenLodDataWindowClick(object sender, RoutedEventArgs e)
        {
            LodDataWindow lodDataWindow = new LodDataWindow(this.m_model, this.nodDataList.ToList(), this.labShow3);
            lodDataWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MakroClick(object sender, RoutedEventArgs e)
        {
            var watch = new Stopwatch();
            watch.Start();

            listTest = new List<Rec>();
            for (int i = 0; i < 1000; i++)
            {
                listTest.Add(new Rec()
                {
                    m1 = i.ToString() + ",1",
                    m2 = i.ToString() + ",2",
                    m3 = i.ToString() + ",3",
                    m4 = i.ToString() + ",4",
                    m5 = i.ToString() + ",5",
                    m6 = i.ToString() + ",6",
                    m7 = i.ToString() + ",7",
                    m8 = i.ToString() + ",8",
                    m9 = i.ToString() + ",9",
                    m10 = i.ToString() + ",10"
                });
            }

            watch.Stop();
            labShow6.Content = "Czas tworzenia list= " + watch.ElapsedMilliseconds.ToString();

            Test test = new Test(this);

            test.Show();
        }

        private void OpenLineCharacteristicDataWindowClick(object sender, RoutedEventArgs e)
        {
            LineCharacteristicDataWindow lineCharacteristicDataWindow = new LineCharacteristicDataWindow(this.m_model, this.labShow4, this.nodDataList);
            lineCharacteristicDataWindow.Show();
        }

        private void testClick(object sender, RoutedEventArgs e)
        {
            var filePath = String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\01159502\Desktop\plans2\workdir";
            openFileDialog.Filter = "KDM files (*.kdm)|*.kdm";

            if (openFileDialog.ShowDialog() == true)
                filePath = openFileDialog.FileName;

            dynamic model = PlansAppObject.CModelSEE();

            var watch = new Stopwatch();
            watch.Start();
            model.ReadDataKDM(filePath);  //odczyt
            watch.Stop();
            labShow7.Content = "Czas czytania modelu= " + watch.ElapsedMilliseconds.ToString();

            watch.Start();
            double sum = 0;
            int nodCount = (int)model.Data.N_Nod;
            for (int i = 1; i < nodCount; i++)
            {
                var nod = model.NodArray.Get(i);

                var Name = nod.Name;
                var Typ = nod.Typ;
                var Vs = nod.Vs;
                var Pl = nod.Pl;
                var Ql = nod.Ql;
                var Pg = nod.Pg;
                var Qg = nod.Qg;
                var Qmin = nod.Qmin;
                var Qmax = nod.Qmax;
                var St = nod.St;
                var Vn = nod.Vn;
                var Vmin = nod.Vmin;
                var Vmax = nod.Vmax;
                var Comp = nod.Comp;
                var Area = nod.Area;
                var Zone = nod.Zone;
                var Regn = nod.Regn;
                var Vi = nod.Vi;
                var Di = nod.Di;

                //nod.Pl = 2;

                //sum += a + b;
            }
            watch.Stop();

            labShow8.Content = "Sum= " + sum.ToString();
            labShow9.Content = "Czas petli= " + watch.ElapsedMilliseconds.ToString();


        }



        private void testClickDLL(object sender, RoutedEventArgs e)
        {
            var filePath = String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\01159502\Desktop\plans2\workdir";
            openFileDialog.Filter = "KDM files (*.kdm)|*.kdm";

            if (openFileDialog.ShowDialog() == true)
                filePath = openFileDialog.FileName;


            CModelSEE_cszarp model = new CModelSEE_cszarp();


            var watch = new Stopwatch();
            watch.Start();
            int res = model.readDataKDM(filePath);
            watch.Stop();
            labShow10.Content = "Czas czytania modelu KDM= " + watch.ElapsedMilliseconds.ToString();

            List<NodDTO> list = new List<NodDTO>();
            int size = model.N_Nod();
            watch.Start();
            for (int i = 1; i < size; i++)
            {
                list.Add(new NodDTO()
                {
                    Name = "",
                    Typ = model.NodTyp(i),
                    Vs = model.NodVs(i),
                    Pl = model.NodPl(i),
                    Ql = model.NodQl(i),
                    Pg = model.NodPg(i),
                    Qg = model.NodQg(i),
                    Qmin = model.NodQmin(i),
                    Qmax = model.NodQmax(i),
                    St = model.NodSt(i),
                    Vn = model.NodVn(i),
                    Vmin = model.NodVmin(i),
                    Vmax = model.NodVmax(i),
                    Comp = model.NodComp(i),
                    Area = model.NodArea(i),
                    Zone = model.NodZone(i),
                    Regn = model.NodRegn(i),
                    Vi = model.NodVi(i),
                    Di = model.NodDi(i)
                });
            }
            watch.Stop();
            labShow11.Content = "Czas tworzenia listy = " + watch.ElapsedMilliseconds.ToString();

            NodeDataWindow nodeDataWindow = new NodeDataWindow(labShow12, list);
            nodeDataWindow.Show();

        }



        private async void ReadDataKdmClick(object sender, RoutedEventArgs e)
        {
            var filePath = String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\01159502\Desktop\plans2\workdir";
            openFileDialog.Filter = "KDM files (*.kdm)|*.kdm";

            if (openFileDialog.ShowDialog() == true)
                filePath = openFileDialog.FileName;


            this.m_model.ReadDataKDM(filePath);  //odczyt danych KDM za pomoca interfejsu pythona

            labConfirm.Content = "Busy";

            if (isInitialized == false)
            {
                PythonEngine.BeginAllowThreads();
                isInitialized = true;
            }

            labConfirm.Content = "";
            var watch = new Stopwatch();
            watch.Start();

            Task<ObservableCollection<NodDTO>> task = readDataAsync();
            this.nodDataList = await task;

            watch.Stop();
            labRead.Content = "Czas wczytywania modelu KDM= " + watch.ElapsedMilliseconds.ToString();
            labConfirm.Content = "Wczytano model KDM!";


            //Thread.CurrentThread.IsBackground = true;
            //new Thread(() =>
            //{
            //    using (Py.GIL())
            //    {
            //        PythonEngine.BeginAllowThreads();
            //        for (int i = 1; i < (int)m_model.Data.N_Bra; i++)
            //        {
            //            Console.WriteLine("Bra");
            //            //PyObject bra = m_model.BraArray.Get(i);
            //        }
            //    }
            //}).Start();

            //new Thread(() =>
            //{
            //    using (Py.GIL())
            //    {
            //        PythonEngine.BeginAllowThreads();
            //        for (int i = 1; i < (int)m_model.Data.N_Nod; i++)
            //        {
            //            Console.WriteLine("nod");
            //           // PyObject nod = m_model.NodArray.Get(i);
            //        }
            //    }
            //}).Start();

        }

        private async Task<ObservableCollection<NodDTO>> readDataAsync()
        {
            ObservableCollection<NodDTO> nodList;
            var tasks = new List<Task<ObservableCollection<NodDTO>>>();

            bool debug = false;
            tasks.Add(braAsyncRead(debug));
            tasks.Add(linAsyncRead(debug));
            tasks.Add(lchAsyncRead(debug));
            tasks.Add(lodAsyncRead(debug));
            tasks.Add(genAsyncRead(debug));
            tasks.Add(trfAsyncRead(debug));
            tasks.Add(nodAsyncRead(debug));
            tasks.Add(zonAsyncRead(debug));

            nodList = await tasks.ElementAt(6);

            await Task.WhenAll(tasks);

            return nodList;
        } //readDataAsync

        private async Task<ObservableCollection<NodDTO>> braAsyncRead(bool debug)
        {
            int braCount = m_model.Data.N_Bra;
            for (int i = 1; i < braCount; i++)
            {
                if (debug)
                    Console.WriteLine("Bra");
                PyObject bra = m_model.BraArray.Get(i);
            }

            return null;
        }

        private async Task<ObservableCollection<NodDTO>> linAsyncRead(bool debug)
        {
            int linCount = m_model.Data.N_Lin;
            for (int i = 1; i < linCount; i++)
            {
                if (debug)
                    Console.WriteLine("lin");
                PyObject lin = m_model.LinArray.Get(i);
            }

            return null;
        }

        private async Task<ObservableCollection<NodDTO>> lchAsyncRead(bool debug)
        {
            int lchCount = m_model.Data.N_LCh;
            for (int i = 1; i < lchCount; i++)
            {
                if (debug)
                    Console.WriteLine("lch");
                PyObject Lch = m_model.LChArray.Get(i);
            }
            return null;
        }

        private async Task<ObservableCollection<NodDTO>> lodAsyncRead(bool debug)
        {
            int lodCount = m_model.Data.N_Lod;
            for (int i = 1; i < lodCount; i++)
            {
                if (debug)
                    Console.WriteLine("lod");
                PyObject lod = m_model.LodArray.Get(i);
            }
            return null;
        }

        private async Task<ObservableCollection<NodDTO>> genAsyncRead(bool debug)
        {
            int genCount = m_model.Data.N_Gen;
            for (int i = 1; i < genCount; i++)
            {
                if (debug)
                    Console.WriteLine("gen");
                PyObject gen = m_model.GenArray.Get(i);
            }
            return null;
        }

        private async Task<ObservableCollection<NodDTO>> trfAsyncRead(bool debug)
        {
            int trfCount = m_model.Data.N_Trf;
            for (int i = 1; i < trfCount; i++)
            {
                if (debug)
                    Console.WriteLine("trf");
                PyObject trf = m_model.TrfArray.Get(i);

            }
            return null;
        }

        private async Task<ObservableCollection<NodDTO>> nodAsyncRead(bool debug)
        {
            ObservableCollection<NodDTO> list = new ObservableCollection<NodDTO>();
            int nodCount = m_model.Data.N_Nod;

            for (int i = 1; i < nodCount; i++)
            {
                if (debug)
                    Console.WriteLine("nod");
                var nod = m_model.NodArray.Get(i);

                list.Add(new NodDTO()
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
            return list;
        }

        private async Task<ObservableCollection<NodDTO>> zonAsyncRead(bool debug)
        {
            int zonCount = m_model.Data.N_Zon;
            for (int i = 1; i < zonCount; i++)
            {
                if (debug)
                    Console.WriteLine("zon");
                PyObject zon = m_model.ZonArray.Get(i);
            }
            return null;
        }
    }
}

