namespace TipCalculator;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		//Nesse contexto, o +=
		BillInput.TextChanged += (s, e) => CalculateTip(false, false);
		roundDown.Clicked += (s, e) => CalculateTip(false, true);
		roundUp.Clicked += (s, e) => CalculateTip(true, false);


        tipPercenteSlider.ValueChanged += (s, e) =>
		{
			double pct = Math.Round(e.NewValue);
			tipPercent.Text = pct + "%";
			CalculateTip(false, false);
		};


		void CalculateTip(bool roundUp, bool roundDown)
		{
			double t;
			if (Double.TryParse(BillInput.Text, out t) && t > 0)
			{
				double pct = Math.Round(tipPercenteSlider.Value);
				double tip = Math.Round(t * (pct / 100.0), 2);

				double final = t + tip;

				if (roundUp)
				{
					final = Math.Ceiling(final);
					tip = final - t;
				}
				else if (roundDown)
				{
					final = Math.Floor(final);
					tip = final - t;
				}

				tipOutput.Text = tip.ToString("C");
				totalOutput.Text = final.ToString("C");
			}
		}
	}

	void OnNormalTip(object sender, EventArgs e)
	{
		tipPercenteSlider.Value = 15;
	}

	void OnGenerousTip(object sender, EventArgs e)
	{
		tipPercenteSlider.Value = 20;
	}
}



