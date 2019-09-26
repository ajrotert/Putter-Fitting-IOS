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
        UIToolbar generic;
        UIBarButtonItem myButtong;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public OptionsListDataModel OLDM;
        public Algorithm fit;

        partial void ImortanceLevelChanged(UITextField sender)
        {
            myButtong.Title = "Importance Level (1 - 5): " + sender.Text;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            generic = new UIToolbar(new CoreGraphics.CGRect(new nfloat(0.0f), new nfloat(0.0f), this.View.Frame.Size.Width, new nfloat(44.0f)));             generic.TintColor = UIColor.White;             generic.BarStyle = UIBarStyle.Black;             generic.Translucent = true;
            myButtong = new UIBarButtonItem("Importance Level (1 - 5): ",                  UIBarButtonItemStyle.Bordered, AddNull);             generic.Items = new UIBarButtonItem[]{           myButtong,            new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),             new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate             {                 ImportanceTextBox.ResignFirstResponder();             })             };             ImportanceTextBox.KeyboardAppearance = UIKeyboardAppearance.Dark;             ImportanceTextBox.InputAccessoryView = generic; 



            View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Background6.png"));

            counter = 0;
            OLDM = new OptionsListDataModel(TitleLabel);
            //counter = OLDM.SetData(counter);
            //**OptionsList.Model = OLDM;
            ProgressBar.Progress = 0.1F;

            BackButton.Hidden = true;
            ResultsView.Hidden = true;
            ResultsTitleLabel.Hidden = true;
            ShowMoreButton.Hidden = true;
            ShowMyDetailsButton.Hidden = true;
            StartOverButton.Hidden = true;
            ShowMoreLabel.Hidden = true;
            PutterSpecsLabel.Hidden = true;

            PlayPrefLabel.Hidden = true;
            PlayErrorLabel.Hidden = true;

            TitleLabel.Text = TitleNames[counter];

            ImportanceTextBox.ShouldReturn = delegate {
            
                ImportanceTextBox.ResignFirstResponder();
                return true;
            };
            // Perform any additional setup after loading the view, typically from a nib.

        }

        partial void BottomLeft_Button_TouchUpInside(UIButton sender)
        {
            if (counter < 9)
                Next_Clicked(coordinate.BottomLeft);
            else
                Brand_Clicked(coordinate.BottomLeft);
        }

        partial void BottomRight_Button_TouchUpInside(UIButton sender)
        {
            if (counter < 9)
                Next_Clicked(coordinate.BottomRight);
            else
                Brand_Clicked(coordinate.BottomRight);
        }

        partial void TopRight_Button_TouchUpInside(UIButton sender)
        {
            if (counter < 9)
                Next_Clicked(coordinate.TopRight);
            else
                Brand_Clicked(coordinate.TopRight);
        }

        partial void TopLeft_Button_TouchUpInside(UIButton sender)
        {
            if (counter < 9)
                Next_Clicked(coordinate.TopLeft);
            else
                Brand_Clicked(coordinate.TopLeft);
        }

        partial void Back_Clicked(UIButton sender)
        {
            counter-=2;
            SetImages(true);
            //**OptionsList.Model = OLDM;
            ImportanceTextBox.Text = "5";
            if (counter == 0)
                BackButton.Hidden = true;
        }
        public string[] TitleNames = {
        "Dominant Eye",
        "Height",
        "Swing Path",
        "Common L-R Miss",                                         //Used to display titles for the fitting functions
        "Common Distance Miss",
        "Wrist Articulation",
        "Alignment",
        "Grip Perefrence",
        "Putter Head Feel"};

        private string[,] ImagesArray = {
        {"PF-LHLE.png", "PF-RHRE.png", "PF-LHRE.png", "PF-RHLE.png"}, //changed the order here
        {"PF-HG66.png", "PF-HG60.png", "PF-HL60.png", "PF-HL55.png"},
        {"PF-AP.png", "PF-SP.png", "Blank.png", "Blank.png"},
        {"PF-LTM.png", "PF-RTM.png", "PF-IM.png", "PF-AM.png" },  
        {"PF-LM.png", "PF-SM.png", "PF-IM.png", "PF-AM.png"},
        {"PF-WAM.png", "PF-WAL.png", "Blank.png" ,"Blank.png"},
        {"PF-SA.png", "PF-GA.png", "Blank.png", "Blank.png"},
        {"PF-GSS.png", "PF-GSL.png", "Blank.png", "Blank.png"},
        {"PF-FS.png", "PF-FH.png", "Blank.png", "Blank.png"} };

        public string[,] ListNames = {
        {"Left Handed, Left Eye", "Right Handed, Right Eye", "Left Handed, Right Eye", "Right Handed, Left Eye"},
        {"Greater than 6ft 6in", "Greater than 6ft", "Less than 6ft", "Less than 5ft 5in"},
        {"Arcing Path", "Straight Path", "", ""},
        {"Left", "Right", "Not Applicable", "Not Applicable" },                          //Used in the fitting functions to display options
        {"Long", "Short", "Not Applicable", "Not Applicable"},
        {"Minimum", "Lots", "Unsure" ,"Unsure"},
        {"Struggles with Alignment", "Alignment is Okay", "", ""},
        {"Standard Size Grip", "Larger Grip", "Either-Or", ""},
        {"Softer Feel", "Harder Feel", "Either-Or", ""} };

        private void SetImages(bool b)
        {
            if (!b)
            {
                TopLeft_Button.SetBackgroundImage(UIImage.FromFile("Blank.png"), UIControlState.Normal);
                TopRight_Button.SetBackgroundImage(UIImage.FromFile("Blank.png"), UIControlState.Normal);
                BottomLeft_Button.SetBackgroundImage(UIImage.FromFile("Blank.png"), UIControlState.Normal);
                BottomRight_Button.SetBackgroundImage(UIImage.FromFile("Blank.png"), UIControlState.Normal);
            }
            else
            {
                counter++;
                TitleLabel.Text = TitleNames[counter];
                TopLeft_Button.SetBackgroundImage(UIImage.FromFile(ImagesArray[counter, 0]), UIControlState.Normal);
                TopRight_Button.SetBackgroundImage(UIImage.FromFile(ImagesArray[counter, 1]), UIControlState.Normal);
                BottomLeft_Button.SetBackgroundImage(UIImage.FromFile(ImagesArray[counter, 2]), UIControlState.Normal);
                BottomRight_Button.SetBackgroundImage(UIImage.FromFile(ImagesArray[counter, 3]), UIControlState.Normal);
            }
        }
        public void Next_Clicked( coordinate c )
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
            //**OptionsList.Model.Selected(OptionsList, 0, 0);
            if (ImagesArray[counter, (int)c] != "Blank.png")
            {
                DataCollection[counter] = ListNames[counter, (int)c];
                myButtong.Title = "Importance Level (1 - 5): ";
                try
                {
                    ImportanceCollection[counter] = Convert.ToInt32(ImportanceTextBox.Text);
                }
                catch
                {
                    ImportanceCollection[counter] = 0;
                }
                if (ImportanceCollection[counter] > 0 && ImportanceCollection[counter] <= 5)
                {
                    if (counter == 8)
                    {
                        counter++;
                        Start();
                    }
                    else
                    {
                        //counter = OLDM.SetData(counter);
                        //**OptionsList.Model = OLDM;
                        SetImages(true);

                        ImportanceTextBox.Text = "5";
                        ProgressBar.Progress = (counter) / 10F;
                        if (ProgressBar.Progress == .4F)
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
            }
            if(counter == 1)
            {
                BackButton.Hidden = false;
            }

        }

        private string[] ptdata;

        public void Start()
        {
            ProgressBar.Progress = 1F;
            for (int a = 0; a < 9; a++)
                Console.WriteLine(DataCollection[a]);
            fit = new Algorithm(DataCollection, ImportanceCollection);
            results = fit.FindPutter();
            fit.setCharacteristic();
            //If results are greater than 3 provide question ten
            if (results.Length > 3)
            {
                ImportanceLevelLabel.Hidden = true;
                ImportanceTextBox.Hidden = true;
                OneToFiveLabel2.Hidden = true;
                HighLowLabel.Hidden = true;
                BackButton.Hidden = true;
                //**SelectedButton.Hidden = true;
                InfoButton.Hidden = true;
                TitleLabel.Text = "Brand Preference";
                //OLDM.SetData(fit.putter.PutterBrands());
                SetImages(false);
                ptdata = fit.putter.PutterBrands();
                if(ptdata[0] != null && ptdata.Length>0)
                {
                    TopLeft_Button.SetBackgroundImage(UIImage.FromFile(ptdata[0] + ".png"), UIControlState.Normal);
                }
                if (ptdata[0] != null && ptdata.Length > 1)
                {
                    TopRight_Button.SetBackgroundImage(UIImage.FromFile(ptdata[1] + ".png"), UIControlState.Normal);
                }
                if (ptdata[0] != null && ptdata.Length > 2)
                {
                    BottomLeft_Button.SetBackgroundImage(UIImage.FromFile(ptdata[2] + ".png"), UIControlState.Normal);
                }
                if (ptdata[0] != null && ptdata.Length > 3)
                {
                    BottomRight_Button.SetBackgroundImage(UIImage.FromFile(ptdata[3] + ".png"), UIControlState.Normal);
                }
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


        public void Brand_Clicked( coordinate c )
        {
            //**OptionsList.Model.Selected(OptionsList, 0, 0);
            string selected = ptdata[(int)c];
            List<string> BrandResults = new List<string>();
            for(int a = 0; a < results.Length; a++)
            {
                if (results[a].Contains(selected))
                    BrandResults.Add(results[a]);
            }
            //UIAlertView _error = new UIAlertView("My Title Text", "" + BrandResults.Count, null, "Ok", null);
            //_error.Show();

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
            //OptionsList.Hidden = true;
            ImportanceLevelLabel.Hidden = true;
            ImportanceTextBox.Hidden = true;
            OneToFiveLabel2.Hidden = true;
            HighLowLabel.Hidden = true;
            BackButton.Hidden = true;
            //**SelectedButton.Hidden = true;
            ProgressBar.Hidden = true;
            InfoButton.Hidden = true;

            PlayCharLabel.Hidden = true;
            PlayPrefLabel.Hidden = true;
            PlayErrorLabel.Hidden = true;


            TopLeft_Button.Hidden = true;
            TopRight_Button.Hidden = true;
            BottomLeft_Button.Hidden = true;
            BottomRight_Button.Hidden = true;


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
            //**OptionsList.Hidden = false;
            ImportanceLevelLabel.Hidden = false;
            ImportanceTextBox.Hidden = false;
            OneToFiveLabel2.Hidden = false;
            HighLowLabel.Hidden = false;
            BackButton.Hidden = false;
            //**SelectedButton.Hidden = false;
            ProgressBar.Hidden = false;
            PlayCharLabel.Hidden = false;
            InfoButton.Hidden = false;

            TopLeft_Button.Hidden = false;
            TopRight_Button.Hidden = false;
            BottomLeft_Button.Hidden = false;
            BottomRight_Button.Hidden = false;

            counter = -1;
            //OLDM = new OptionsListDataModel(TitleLabel);
            //counter = OLDM.SetData(counter);
            //**OptionsList.Model = OLDM;

            SetImages(true);

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

        partial void Info_Clicked(UIButton sender)
        {
        
            string[] TitleNames = new string[9] {
            "Dominant Eye",
            "Height",
            "Swing Path",
            "Common L-R Miss",
            "Common Distance Miss",
            "Wrist Articulation",
            "Alignment",
            "Grip Perefrence",
            "Putter Head Feel"};

            string[] infoHelp = new string[9]{
            "The dominant eye affects alignment, select the appropriate option for the best results, if you are not sure what your dominant eye is, select \"Right Hand, Right Eye\".",
            "The length of the putter is loosely based on height. Select the closest option.",
            "An arcing swing path happens when the putter head arcs around the target line.\n Straight Back and Straight Through swing paths happen when the putter head stays square on the target line.",
            "If you have a consistent miss, left or right, select the appropriate option, otherwise select \"Not Applicable\". If you are not sure or your misses are not consistent select \"Not Applicable\".",
            "If you have a consistent miss, short or long, select the appropriate option, otherwise select \"Not Applicable\". If you are not sure or your misses are not consistent select \"Not Applicable\".",
            "Wrist articulation is the amount of bend in your wrists. Bending wrists causes extra putter head movement. This can happen by leading the stroke with the hands. Select the appropriate options, if you are not sure select \"Unsure\".",
            "Some putters will provide alignment aid, select the appropriate option. If you are not sure select \"Alignment is Okay\". ",
            "If you have a preference on grip size, select the appropriate option. If you are not sure select \"Either-Or\".",
            "Softer feeling putters will have less feedback, harder feeling putters will have more feedback. If you are not sure select \"Either-Or\"."};

            UIAlertView alert = new UIAlertView()
                {
                    Title = TitleNames[counter],
                    Message = infoHelp[counter]
                };
                alert.AddButton("OK");
                alert.Show();
        }
        private void AddNull(object sender, EventArgs e)
        {
            return;
        }
    }
}



public class OptionsListDataModel : UIPickerViewModel
{
    public string[,] listItems = new string[9, 4] {
        {"Right Handed, Right Eye", "Right Handed, Left Eye", "Left Handed, Left Eye", "Left Handed, Right Eye"},
        {"Greater than 6ft 6in", "Greater than 6ft", "Less than 6ft", "Less than 5ft 5in"},
        {"Arcing Path", "Straight Path", "", ""},
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