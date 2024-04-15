namespace dquicaliquinS2T1.Views;

public partial class Calificaciones : ContentPage
{
	public Calificaciones()
	{
		InitializeComponent();
	}

    private void CalcularNota_Clicked(object sender, EventArgs e)
    {
        if (
            pkEstudiantes.SelectedItem == null ||
            string.IsNullOrWhiteSpace(txtDeberesMomento1.Text) ||
            string.IsNullOrWhiteSpace(txtExamenMomento1.Text) ||
            string.IsNullOrWhiteSpace(txtDeberesMomento2.Text) ||
            string.IsNullOrWhiteSpace(txtExamenMomento2.Text))
        {
            DisplayAlert("Alerta", "Completar todos los campos.", "Aceptar");
        }
        else
        {
            double seguimiento1 = Convert.ToDouble(txtDeberesMomento1.Text);
            double examen1 = Convert.ToDouble(txtExamenMomento1.Text);
            double seguimiento2 = Convert.ToDouble(txtDeberesMomento2.Text);
            double examen2 = Convert.ToDouble(txtExamenMomento2.Text);

            double notaParcial1 = (seguimiento1 * 0.3) + (examen1 * 0.2);
            double notaParcial2 = (seguimiento2 * 0.3) + (examen2 * 0.2);

            double notaFinal = notaParcial1 + notaParcial2;

            string estado;

            if (notaFinal >= 7)
            {
                estado = "Aprobado";
            }
            else if (notaFinal >= 5 && notaFinal <= 6.9)
            {
                estado = "Complementario";
            }
            else
            {
                estado = "Reprobado";
            }

            String estudiante = pkEstudiantes.Items[pkEstudiantes.SelectedIndex].ToString();
            String fecharegistro = FechaDatePicker.Date.ToString("dd/MM/yyyy");

            DisplayAlert("Resultados", "Estudiante: " + estudiante + "\nFecha: " +fecharegistro+ 
                "\nNota Parcial 1: "+ notaParcial1 + "\nNota Parcial 2: "+ notaParcial1 +
                "\nNota Final: "+ notaFinal + "\nEstado: "+ estado, "Aceptar");
        }
    }
}