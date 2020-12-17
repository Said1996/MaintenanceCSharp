using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ui.Views
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class MaintenanceView : MvxWpfView
    {
        public MaintenanceView()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            

            if (e.PropertyName == "Id" || e.PropertyName == "DelieviredTime" || e.PropertyName == "DelivererEmployee")
                e.Column = null;

            if (e.PropertyName == "Name" || e.PropertyName == "Price" || e.PropertyName == "ReceivingTime" || e.PropertyName == "RecieverEmployee" || e.PropertyName == "DeviceStatus")
                e.Column.IsReadOnly = true;

        }

    }
}
