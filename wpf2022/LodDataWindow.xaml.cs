using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    public partial class LodDataWindow : Window
    {
        private dynamic m_model;
        public LodDataWindow(dynamic model, List<NodDTO> list, Label lab1)
        {
            InitializeComponent();
            m_model = model;

            listview1.ItemsSource = list.GetRange(0, 1000);
        }
    }
}
