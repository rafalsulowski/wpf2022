using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for LineCharacteristicDataWindow.xaml
    /// </summary>
    public partial class LineCharacteristicDataWindow : Window
    {
        private dynamic m_model;
        public LineCharacteristicDataWindow(dynamic model, Label lab1, ObservableCollection<NodDTO> list)
        {
            InitializeComponent();
            m_model = model;

            foreach(var el in list)
            {
                listName.Items.Add(el.Name);
                listName2.Items.Add(el.Name);
                listTyp.Items.Add(el.Typ);
                listVs.Items.Add(el.Vs);
                listPl.Items.Add(el.Pl);

            }


        }
    }
}
