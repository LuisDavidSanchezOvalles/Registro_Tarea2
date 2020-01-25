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
using Registro.Entidades;
using Registro.BLL;
using Registro.DAL;

namespace Registro.UI.Registro
{
    /// <summary>
    /// Interaction logic for RegistroPersona.xaml
    /// </summary>
    public partial class RegistroPersona : Window
    {
        public RegistroPersona()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            TextBoxId.Text = string.Empty;
            TextBoxNombre.Text = string.Empty;
            TextBoxTelefono.Text = string.Empty;
            TextBoxCedula.Text = string.Empty;
            TextBoxDireccion.Text = string.Empty;
            DatePickerFecha.SelectedDate = DateTime.Now;
        }

        private void BotonNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void LlenaCampo(Personas Persona)
        {
            string Entrada;
            int Valor;

            try
            {
                Entrada = TextBoxId.Text;
                Valor = Convert.ToInt32(Entrada);
                Valor = Persona.PersonaId;
            }
            catch (Exception)
            {
                MessageBox.Show("Solo se permiten Numeros");
                TextBoxId.Text = string.Empty;
            }

            TextBoxNombre.Text = Persona.Nombre;
            TextBoxTelefono.Text = Persona.Telefono;
            TextBoxCedula.Text = Persona.Cedula;
            TextBoxDireccion.Text = Persona.Direccion;
            DatePickerFecha.SelectedDate = Persona.FechaNacimiento;
        }

        private Personas LlenaClase()
        {
            Personas Persona = new Personas();
            Persona.PersonaId = Convert.ToInt32(TextBoxId.Text);
            Persona.Nombre = TextBoxNombre.Text;
            Persona.Telefono = TextBoxTelefono.Text;
            Persona.Cedula = TextBoxCedula.Text;
            Persona.Direccion = TextBoxDireccion.Text;
            Persona.FechaNacimiento = Convert.ToDateTime(DatePickerFecha.SelectedDate);

            return Persona;
        }
        /// <summary>
        /// Tengo que terminar de arreglar la logica de esto
        /// </summary>
        /// <returns></returns>
        private bool Validar()
        {
            bool Paso = true;

            if(TextBoxNombre.Text == string.Empty)
            {
                MessageBox.Show("El Campo Nombre No Puede estar Vacio");
                TextBoxNombre.Focus();
                Paso = false;
            }

            if(string.IsNullOrWhiteSpace(TextBoxDireccion.Text))
            {
                MessageBox.Show("El Campo Direccion No puede estar Vacio");
                TextBoxDireccion.Focus();
                Paso = false;
            }
            if(string.IsNullOrWhiteSpace(TextBoxCedula.Text))
            {
                MessageBox.Show("El Campo Cedula No puede estar Vacio");
                TextBoxCedula.Focus();
                Paso = false;
            }

            return Paso;
        }

        private bool ExisteEnLaBasedeDatos()
        {
            string Entrada;
            int Valor;

            Entrada = TextBoxId.Text;
            Valor = Convert.ToInt32(Entrada);

            Personas Persona = PersonasBLL.Buscar((int)Valor);

            return (Persona != null);
        }

        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Personas Persona;
            bool Paso = false;
            string Entrada;
            int Valor;

            //validar tomara el valor del textboxid
            Entrada = TextBoxId.Text;
            Valor = Convert.ToInt32(Entrada);

            if (!Validar())
                return;

            Persona = LlenaClase();

            //determina si es guardar o modificar
            if (Valor == 0)
                Paso = PersonasBLL.Guardar(Persona);
            else
            {
                if (!ExisteEnLaBasedeDatos())
                {
                    MessageBox.Show("No se Puede Modificar Una Persona que no existe");
                }
                Paso = PersonasBLL.Modificar(Persona);
            }
            //para informar el resultado
            if (Paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!");
            }
            else
            {
                MessageBox.Show("No es Posible Guardar");
            }
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int Valor;
            string Entrada;

            try
            {
                Entrada = TextBoxId.Text;
                Valor = Convert.ToInt32(Entrada);
                
                Personas Persona = new Personas();
                int.TryParse(TextBoxId.Text, out id);

                Limpiar();

                PersonasBLL.Buscar(id);

                if(Persona != null)
                {
                    MessageBox.Show("Persona Encontrada");
                    LlenaCampo(Persona);
                }
                else
                {
                    MessageBox.Show("Persona No encontrada");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("letra en ves de numero en la busqueda");
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id;
           
            int.TryParse(TextBoxId.Text, out id);

            Limpiar();

            if (PersonasBLL.Eliminar(id))
                MessageBox.Show("Exito, se Elimino");
            else
            {
                MessageBox.Show("No se Puede Eliminar a una Persona que no existe...");
            }
        }
    }
}
