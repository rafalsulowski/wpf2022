using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace wpf2022
{
    public partial class Test : Window
    {
        
        public Test(MainWindow parent)
        {
            InitializeComponent();

            
            //List<Rec> list = new List<Rec>();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(new Rec()
            //    {
            //        m1 = i.ToString() + ",1",
            //        m2 = i.ToString() + ",2",
            //        m3 = i.ToString() + ",3",
            //        m4 = i.ToString() + ",4",
            //        m5 = i.ToString() + ",5",
            //        m6 = i.ToString() + ",6",
            //        m7 = i.ToString() + ",7",
            //        m8 = i.ToString() + ",8",
            //        m9 = i.ToString() + ",9",
            //        m10 = i.ToString() + ",10"
            //    });
            //}

            this.dataGrid1.ItemsSource = parent.listTest;



            //for (int i = 0; i < 1000; i++)
            //{
            //    dataGrid1.Items.Add(new Rec()
            //    {
            //        m1 = i.ToString() + ",1",
            //        m2 = i.ToString() + ",2",
            //        m3 = i.ToString() + ",3",
            //        m4 = i.ToString() + ",4",
            //        m5 = i.ToString() + ",5",
            //        m6 = i.ToString() + ",6",
            //        m7 = i.ToString() + ",7",
            //        m8 = i.ToString() + ",8",
            //        m9 = i.ToString() + ",9",
            //        m10 = i.ToString() + ",10"
            //    });
            //}
        }



    }

    public class Rec
    {
        public string m1 {get;set;}
        public string m2 {get;set;}
        public string m3 {get;set;}
        public string m4 {get;set;}
        public string m5 {get;set;}
        public string m6 {get;set;}
        public string m7 {get;set;}
        public string m8 {get;set;}
        public string m9 { get; set; }
        public string m10 { get; set; }

    }

}