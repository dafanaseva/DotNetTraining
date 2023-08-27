namespace Task4.WinForm;

public partial class Form1 : Form
{
    public Form1()
    {
        var enableLogButton = new CheckBox();

        var accessoriesSupplierRateBar = new TrackBar();
        var carBodiesSupplierRateBar = new TrackBar();
        var enginesSupplierRateBar = new TrackBar();


        Controls.Add(enableLogButton);

        Controls.Add(accessoriesSupplierRateBar);
        Controls.Add(carBodiesSupplierRateBar);
        Controls.Add(enginesSupplierRateBar);
    }
}