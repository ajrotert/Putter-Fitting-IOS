using System;
using UIKit;
using System.Collections.Generic;

namespace IOSApp
{
    public partial class ViewController : UIViewController
    {

        public int counter;
        public string[] DataCollection = new string[9];
        public int[] ImportanceCollection = new int[9];
        public string[] results;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public OptionsListDataModel OLDM;
        public Algorithm fit;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Background6.png"));

            counter = 0;
            OLDM = new OptionsListDataModel(TitleLabel);
            counter = OLDM.SetData(counter);
            OptionsList.Model = OLDM;
            OneToFiveLabel.RemoveFromSuperview();//cannot find
            ProgressBar.Progress = 0.1F;

            BackButton.Hidden = true;
            ResultsView.Hidden = true;
            ResultsTitleLabel.Hidden = true;
            ShowMoreButton.Hidden = true;
            ShowMyDetailsButton.Hidden = true;
            StartOverButton.Hidden = true;
            ShowMoreLabel.Hidden = true;
            PutterSpecsLabel.Hidden = true;
            BrandButton.Hidden = true;

            PlayPrefLabel.Hidden = true;
            PlayErrorLabel.Hidden = true;

            ImportanceTextBox.ShouldReturn = delegate {
            
                ImportanceTextBox.ResignFirstResponder();
                return true;
            };
            // Perform any additional setup after loading the view, typically from a nib.

        }

        partial void Back_Clicked(UIButton sender)
        {
            counter-=2;
            counter = OLDM.SetData(counter);
            OptionsList.Model = OLDM;
            ImportanceTextBox.Text = "5";
            if (counter == 1)
                BackButton.Hidden = true;
        }

        partial void Next_Clicked(UIButton sender)
        {
            /*if(SelectedButton.Title(UIControlState.Normal) == "Clicked")
            {
                SelectedButton.RemoveFromSuperview();
            }
            SelectedButton.SetTitle("Clicked", UIControlState.Normal);
            OptionsList.Model.Selected(OptionsList, 0, 0);           
            SelectedButton.SetTitle(OLDM.selected, UIControlState.Normal);
            counter = OLDM.SetData(counter);
            OptionsList.Model = OLDM;*/
            OptionsList.Model.Selected(OptionsList, 0, 0);
            DataCollection[counter-1] = OLDM.selected;
            try
            {
                ImportanceCollection[counter - 1] = Convert.ToInt32(ImportanceTextBox.Text);
            }
            catch
            {
                ImportanceCollection[counter - 1] = 0;
            }
            if (DataCollection[counter-1] != "" && ImportanceCollection[counter-1] > 0 && ImportanceCollection[counter-1] <= 5)
            {
                if (counter == 9)
                {
                    Start();
                }
                else
                {
                    counter = OLDM.SetData(counter);
                    OptionsList.Model = OLDM;
                    ImportanceTextBox.Text = "5";
                    ProgressBar.Progress = (counter)/10F;
                    if(ProgressBar.Progress == .4F)
                    {
                        PlayCharLabel.Hidden = true;
                        PlayErrorLabel.Hidden = false;
                    }
                    else if (ProgressBar.Progress == .7F)
                    {
                        PlayErrorLabel.Hidden = true;
                        PlayPrefLabel.Hidden = false;
                    }
                }
            }
            if(counter-1 == 1)
            {
                BackButton.Hidden = false;
            }

        }

        public void Start()
        {
            ProgressBar.Progress = 1F;
            fit = new Algorithm(DataCollection, ImportanceCollection);
            results = fit.FindPutter();
            fit.setCharacteristic();
            //If results are greater than 3 provide question ten
            if (results.Length > 3)
            {
                BrandButton.Hidden = false;
                ImportanceLevelLabel.Hidden = true;
                ImportanceTextBox.Hidden = true;
                OneToFiveLabel2.Hidden = true;
                HighLowLabel.Hidden = true;
                BackButton.Hidden = true;
                SelectedButton.Hidden = true;
                TitleLabel.Text = "Brand";
                OLDM.SetData(fit.putter.PutterBrands());
                OptionsList.Model = OLDM;
            }
            else
            {
                ResultsSetup();
                ResultsTitleLabel.Text = "Results: ( " + results.Length + " )";
                OLDM.SetData(results);
                ResultsView.Model = OLDM;
                PutterSpecsLabel.Text = "Length: " + fit.putter.PutterLength + Environment.NewLine + "Grip: " + fit.putter.PutterGrip;
            }

        }

        partial void Brand_Clicked(UIButton sender)
        {
            OptionsList.Model.Selected(OptionsList, 0, 0);
            string selected = OLDM.selected;
            List<string> BrandResults = new List<string>();
            for(int a = 0; a < results.Length; a++)
            {
                if (results[a].Contains(selected))
                    BrandResults.Add(results[a]);
            }
            //UIAlertView _error = new UIAlertView("My Title Text", "" + BrandResults.Count, null, "Ok", null);
            //_error.Show();
            BrandButton.Hidden = true;

            ResultsSetup();
            ResultsTitleLabel.Text = "Results: ( " + BrandResults.Count + " )";
            OLDM.SetData(BrandResults.ToArray());
            ResultsView.Model = OLDM;
            PutterSpecsLabel.Text = "Length: " + fit.putter.PutterLength + Environment.NewLine + "Grip: " + fit.putter.PutterGrip;
        }

        public void ResultsSetup()
        {
            PCTitle.Hidden = true;
            TitleLabel.Hidden = true;
            OptionsList.Hidden = true;
            ImportanceLevelLabel.Hidden = true;
            ImportanceTextBox.Hidden = true;
            OneToFiveLabel2.Hidden = true;
            HighLowLabel.Hidden = true;
            BackButton.Hidden = true;
            SelectedButton.Hidden = true;
            ProgressBar.Hidden = true;

            PlayCharLabel.Hidden = true;
            PlayPrefLabel.Hidden = true;
            PlayErrorLabel.Hidden = true;

            ResultsView.Hidden = false;
            ResultsTitleLabel.Hidden = false;
            ShowMoreButton.Hidden = false;
            ShowMyDetailsButton.Hidden = false;
            StartOverButton.Hidden = false;
            ShowMoreLabel.Hidden = false;
            PutterSpecsLabel.Hidden = false;
        }

        partial void StartOver_Clicked(UIButton sender)
        {
            ProgressBar.Progress = 0.1F;
            PCTitle.Hidden = false;
            TitleLabel.Hidden = false;
            OptionsList.Hidden = false;
            ImportanceLevelLabel.Hidden = false;
            ImportanceTextBox.Hidden = false;
            OneToFiveLabel2.Hidden = false;
            HighLowLabel.Hidden = false;
            BackButton.Hidden = false;
            SelectedButton.Hidden = false;
            ProgressBar.Hidden = false;
            PlayCharLabel.Hidden = false;

            counter = 0;
            OLDM = new OptionsListDataModel(TitleLabel);
            counter = OLDM.SetData(counter);
            OptionsList.Model = OLDM;

            BackButton.Hidden = true;

            ShowMoreLabel.Text = "";

            ResultsView.Hidden = true;
            ResultsTitleLabel.Hidden = true;
            ShowMoreButton.Hidden = true;
            ShowMyDetailsButton.Hidden = true;
            StartOverButton.Hidden = true;
            ShowMoreLabel.Hidden = true;
            PutterSpecsLabel.Hidden = true;
        }

        partial void MyDetails_Clicked(UIButton sender)
        {
            ResultsView.Model.Selected(ResultsView, 0, 0);
            string selected = OLDM.selected;
            ShowMoreLabel.Font = ShowMoreLabel.Font.WithSize(16);
            if (selected != "")
            {
                fit.putter.setCharacteristic(selected);
                string putterShapeBool = "*No Match";
                string putterBalanceBool = "*No Match";
                string putterHoselBool = "*No Match";
                string putterWeightBool = "*No Match";
                string putterFeelBool = "*No Match";
                if (fit.putter.putterShape == fit.putterShape)
                    putterShapeBool = "Match";
                if (fit.putter.putterBalance == fit.putterBalance)
                    putterBalanceBool = "Match";
                if (fit.putter.putterHosel == fit.putterHosel)
                    putterHoselBool = "Match";
                if (fit.putter.putterWeight == fit.putterWeight)
                    putterWeightBool = "Match";
                if (fit.putter.putterFeel == fit.putterFeel)
                    putterFeelBool = "Match";

                ShowMoreLabel.Text = "Putter: " + selected +
                    Environment.NewLine + "Putter Head Shape: " + fit.putterShape + " (" + putterShapeBool + ")" +
                    Environment.NewLine + "Putter Balance: " + fit.putterBalance + " (" + putterBalanceBool + ")" +
                    Environment.NewLine + "Putter Hosel: " + fit.putterHosel + " (" + putterHoselBool + ")" +
                    Environment.NewLine + "Putter Weight: " + fit.putterWeight + " (" + putterWeightBool + ")" +
                    Environment.NewLine + "Putter Feel: " + fit.putterFeel + " (" + putterFeelBool + ")" +
                    Environment.NewLine + fit.Matching().ToString("0.##") + "% Matching";
            }
            else
            {
                ShowMoreLabel.Text = "Putter Head Shape: " + fit.putterShape +
                    Environment.NewLine + "Putter Balance: " + fit.putterBalance +
                    Environment.NewLine + "Putter Hosel: " + fit.putterHosel +
                    Environment.NewLine + "Putter Weight: " + fit.putterWeight +
                    Environment.NewLine + "Putter Feel: " + fit.putterFeel;
            }
        }

        partial void ShowMore_Clicked(UIButton sender)
        {
            ResultsView.Model.Selected(ResultsView, 0, 0);
            string selected = OLDM.selected;
            ShowMoreLabel.Font = ShowMoreLabel.Font.WithSize(18);
            if (selected != "")
            {
                fit.putter.setCharacteristic(selected);
                ShowMoreLabel.Text = "Putter: " + selected +
                    Environment.NewLine + "Putter Head Shape: " + fit.putter.putterShape +
                    Environment.NewLine + "Putter Balance: " + fit.putter.putterBalance +
                    Environment.NewLine + "Putter Hosel: " + fit.putter.putterHosel +
                    Environment.NewLine + "Putter Weight: " + fit.putter.putterWeight +
                    Environment.NewLine + "Putter Feel: " + fit.putter.putterFeel;
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}



public class OptionsListDataModel : UIPickerViewModel
{
    public string[,] listItems = new string[9, 4] {
        {"Right Handed, Right Eye", "Right Handed, Left Eye", "Left Handed, Left Eye", "Left Handed, Right Eye"},
        {"Greater than 6ft 6in", "Greater than 6ft", "Less than 6ft", "Less than 5ft 5in"},
        {"Arcing Path", "Straight Back Straight Through", "", ""},
        {"Left", "Right", "Not Applicable", "" },                          //Used in the fitting functions to display options
        {"Long", "Short", "Not Applicable", ""},
        {"Minimum", "Lots", "Unsure" ,""},
        {"Struggles with Alignment", "Alignment is Okay", "", ""},
        {"Standard Size Grip", "Larger Grip", "Either-Or", ""},
        {"Softer Feel", "Harder Feel", "Either-Or", ""} };

    public string[] listNames = new string[9] {
        "Dominant Eye",
        "Height",
        "Swing Path",
        "Common L-R Miss",                                         //Used to display titles for the fitting functions
        "Common Distance Miss",
        "Wrist Articulation",
        "Alignment",
        "Grip Perefrence",
        "Putter Head Feel"};

    private UILabel title;

    public OptionsListDataModel(UILabel title)
    {
        this.title = title;
    }
    public string[] data;
    public string selected;
    public int SetData(int counter)
    {
        data = new string[4];
        if (counter >= 9)
            counter = 0;
        for(int a = 0; a<4; a++)
        {
            data[a] = listItems[counter, a];
        }
        title.Text = listNames[counter];
        counter++;
        return counter;
    }
    public void SetData(string[] data)
    {
        this.data = data;
    }

    public override nint GetComponentCount(UIPickerView pickerView)
    {
        return 1;
    }

    public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
    {
        return data.Length;
    }

    public override string GetTitle(UIPickerView pickerView, nint row, nint component)
    {
        if (component == 0)
            return data[row];
        else
            return row.ToString();
    }

    public override void Selected(UIPickerView pickerView, nint row, nint component)
    {
        //personLabel.Text = $"This person is: {names[pickerView.SelectedRowInComponent(0)]},\n they are number {pickerView.SelectedRowInComponent(1)}";
        selected = data[pickerView.SelectedRowInComponent(0)]; //0 is text, 1 is integer
    }

    public override nfloat GetComponentWidth(UIPickerView pickerView, nint component) //not sure what these do
    {
        if (component == 0)
            return 240f;
        else
            return 40f;
    }

    public override nfloat GetRowHeight(UIPickerView pickerView, nint component)
    {
        return 40f;
    }

}