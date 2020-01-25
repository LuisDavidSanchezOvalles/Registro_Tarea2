using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Registro.BLL;
using Registro.DAL;
using Registro.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Registro.UI.Consulta
{
    /// <summary>
    /// Interaction logic for Consulta.xaml
    /// </summary>
    public partial class Consulta : Window
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void BotonConsultar_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Personas>();

            if (TextBoxCriterio.Text.Trim().Length > 0)
            {
                switch (ComboBoxFiltrar.SelectedIndex)
                {
                    case 0://Todo
                        Listado = PersonasBLL.GetList(p => true);
                        break;
                    case 1://Id
                        int Id = Convert.ToInt32(TextBoxCriterio.Text);
                        Listado = PersonasBLL.GetList(p => p.PersonaId == Id);
                        break;
                    case 2://Nombre
                        Listado = PersonasBLL.GetList(p => p.Nombre.Contains(TextBoxCriterio.Text));
                        break;
                    case 3://Cedula
                        Listado = PersonasBLL.GetList(p => p.Cedula.Contains(TextBoxCriterio.Text));
                        break;
                    case 4://Direccion
                        Listado = PersonasBLL.GetList(p => p.Direccion.Contains(TextBoxCriterio.Text));
                        break;
                }

                Listado = Listado.Where(c => c.FechaNacimiento.Date >= DesdeDataPicker.SelectedDate && c.FechaNacimiento.Date <= HastaDataPicker.SelectedDate).ToList();
            }
            else
            {
                Listado = PersonasBLL.GetList(p => true);
            }

            DataGridConsulta.ItemsSource = Listado;
            DataGridConsulta.ItemsSource = null;
        }
    }
}