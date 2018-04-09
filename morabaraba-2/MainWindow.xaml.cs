using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace morabaraba_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            shoot.Visibility = Visibility.Hidden;
            gun.Visibility = Visibility.Hidden;
            target.Visibility = Visibility.Hidden;
            tolab.Visibility = Visibility.Hidden;
            moveCow.Visibility = Visibility.Hidden;
            movecow.Visibility = Visibility.Hidden;
            from.Visibility = Visibility.Hidden;
            to.Visibility = Visibility.Hidden;
        }
        new List<string> XMoves = new List<string>(); // ine mamoves atambwa na X
        new List<string> OMoves = new List<string>(); // inochengeta mamoves atambwa na O
        int Xcows = 3; // mombe dza X
        int Ocows = 3;// mombe dza O
        new List<string[]> Xmills = new List<string[]>(); // mamills ayitwa na X
        new List<string[]> Omills = new List<string[]>(); // mamills ayitwa na O
        int player = 0; //nhamba inosarudza mutambi

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            string Input = Convert.ToString(input.Text);
            if (checkIfValid(Input) == false)
            {
                input.Text = "";
                info.Text = ("Invalid Input!");
            }
            else
            {
                try
                {
                    if (player == 0)
                    {
                        mombeDzaX.Text = Convert.ToString(--Xcows); //inoisa mombe dzasara paboard
                        placeMove(Input, "X");
                        if (isMill(XMoves, "X") == true)
                        {
                            info.Text = ("X Mill Found!\n Choose Cow to shoot");
                            shoot.Visibility = Visibility.Visible;
                            gun.Visibility = Visibility.Visible;
                            target.Visibility = Visibility.Visible;
                            play.Visibility = Visibility.Hidden;
                        }
                        player++; //kushandura mutambi
                        input.Text = "";
                        xCowsOnBoard.Text = Convert.ToString(XMoves.Count);
                        oCowsOnBoard.Text = Convert.ToString(OMoves.Count);
                        return; //kuitira kuti kana mutambi X atamba, Y haatambi
                    }
                }
                catch (Exception)
                {
                    mombeDzaX.Text = Convert.ToString(++Xcows);
                    player = 0; //kutangidza futi kuti ayise pasina kuiswa 
                }
                try
                {

                    if (player == 1)
                    {
                        mombeDzaO.Text = Convert.ToString(--Ocows);
                        placeMove(Input, "O");
                        if (isMill(OMoves, "O") == true)
                        {
                            info.Text = ("O Mill Found!\n Choose Cow to shoot");
                            target.Visibility = Visibility.Visible;
                            shoot.Visibility = Visibility.Visible;
                            gun.Visibility = Visibility.Visible;
                            play.Visibility = Visibility.Hidden;

                        }
                        input.Text = "";
                        xCowsOnBoard.Text = Convert.ToString(XMoves.Count);
                        oCowsOnBoard.Text = Convert.ToString(OMoves.Count);
                        player--; //kushandura mutambi
                    }
                    //return;
                }
                catch (Exception)
                {
                    mombeDzaO.Text = Convert.ToString(++Ocows);
                    player = 1; //kutangidza futi kuti ayise pasina kuiswa 
                }

            }
            if (Xcows == 0 && Ocows == 0)
            {
                info.Text = ("Out of Cows to place");
                tolab.Visibility = Visibility.Visible;
                moveCow.Visibility = Visibility.Visible;
                movecow.Visibility = Visibility.Visible;
                from.Visibility = Visibility.Visible;
                to.Visibility = Visibility.Visible;
                inputlogo.Visibility = Visibility.Hidden;
                input.Visibility = Visibility.Hidden;
                play.Visibility = Visibility.Hidden;
                x_c.Visibility = Visibility.Hidden;
                o_c.Visibility = Visibility.Hidden;
                mombeDzaO.Visibility = Visibility.Hidden;
                mombeDzaX.Visibility = Visibility.Hidden;
            }
        }

        private bool isMill(List<string> PlayerMoves, string player)
        {
            // possible mills
            string[] mill = { "a1", "a2", "a3" };
            string[] mill1 = { "b1", "b2", "b3" };
            string[] mill2 = { "c1", "c2", "c3" };
            string[] mill3 = { "d1", "d2", "d3" };
            string[] mill4 = { "d4", "d5", "d6" };
            string[] mill5 = { "e1", "e2", "e3" };
            string[] mill6 = { "f1", "f2", "f3" };
            string[] mill7 = { "g1", "g2", "g3" };
            string[] mill8 = { "a1", "d1", "g1" };
            string[] mill9 = { "b1", "d2", "f1" };
            string[] mill10 = { "c1", "d3", "e1" };
            string[] mill11 = { "a2", "b2", "c2" };
            string[] mill12 = { "e2", "f2", "g2" };
            string[] mill13 = { "c3", "d4", "e3" };
            string[] mill14 = { "b3", "d5", "f3" };
            string[] mill15 = { "a3", "d6", "g3" };
            string[] mill16 = { "a3", "b3", "c3" };
            string[] mill17 = { "g1", "f1", "e1" };
            string[] mill18 = { "g3", "f3", "e3" };
            string[] mill19 = { "a1", "b1", "c1" };

            //kutarisa mamiri kuty afomwa here kana kuti kwete
            //bool f = checkIsMill(Xmills,mill);

            if (((PlayerMoves.Contains("a1") == true) && (PlayerMoves.Contains("a2") == true) && (PlayerMoves.Contains("a3") == true) && (checkIsMill(Xmills,mill) == false) && (checkIsMill(Omills,mill) == false)) == true)
            {//kutarira kuti mill ratawana hariwanikwi futi kana rawanikwa kare
                if (player == "X")
                {
                    Xmills.Add(mill);
                }
                else
                {
                    Omills.Add(mill);
                }

                return true;
            }
            else if (((PlayerMoves.Contains("b1") == true) && (PlayerMoves.Contains("b2") == true) && (PlayerMoves.Contains("b3") == true) && (checkIsMill(Xmills,mill1) != true) && (checkIsMill(Omills,mill1) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill1);
                }
                else
                {
                    string[] x = { "b1", "b2", "b3" };
                    Omills.Add(x);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("c1") == true) && (PlayerMoves.Contains("c2") == true) && (PlayerMoves.Contains("c3") == true) && (checkIsMill(Xmills,mill2) != true) && (checkIsMill(Omills,mill2) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill2);
                }
                else
                {
                    Omills.Add(mill2);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("d1") == true) && (PlayerMoves.Contains("d2") == true) && (PlayerMoves.Contains("d3") == true) && (checkIsMill(Xmills,mill3) != true) && (checkIsMill(Omills,mill3) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill3);
                }
                else
                {
                    Omills.Add(mill3);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("d4") == true) && (PlayerMoves.Contains("d5") == true) && (PlayerMoves.Contains("d6") == true) && (checkIsMill(Xmills,mill4) != true) && (checkIsMill(Omills,mill4) != true)) == true)
            {

                if (player == "X")
                {
                    Xmills.Add(mill4);
                }
                else
                {
                    Omills.Add(mill4);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("e1") == true) && (PlayerMoves.Contains("e2") == true) && (PlayerMoves.Contains("e3") == true) && (checkIsMill(Xmills,mill5) != true) && (checkIsMill(Omills,mill5) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill5);
                }
                else
                {
                    Omills.Add(mill5);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("f1") == true) && (PlayerMoves.Contains("f2") == true) && (PlayerMoves.Contains("f3") == true) && (checkIsMill(Xmills,mill6) != true) && (checkIsMill(Omills,mill6) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill6);
                }
                else
                {
                    Omills.Add(mill6);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("g1") == true) && (PlayerMoves.Contains("g2") == true) && (PlayerMoves.Contains("g3") == true) && (checkIsMill(Xmills,mill7) != true) && (checkIsMill(Omills,mill7) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill7);
                }
                else
                {
                    Omills.Add(mill7);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("a1") == true) && (PlayerMoves.Contains("d1") == true) && (PlayerMoves.Contains("g1") == true) && (checkIsMill(Xmills,mill8) != true) && (checkIsMill(Omills,mill8) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill8);
                }
                else
                {
                    Omills.Add(mill8);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("b1") == true) && (PlayerMoves.Contains("d2") == true) && (PlayerMoves.Contains("f1") == true) && (checkIsMill(Xmills,mill9) != true) && (checkIsMill(Omills,mill9) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill9);
                }
                else
                {
                    Omills.Add(mill9);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("c1") == true) && (PlayerMoves.Contains("d3") == true) && (PlayerMoves.Contains("e1") == true) && (checkIsMill(Xmills,mill10) != true) && (checkIsMill(Omills,mill10) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill10);
                }
                else
                {
                    Omills.Add(mill10);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("a2") == true) && (PlayerMoves.Contains("b2") == true) && (PlayerMoves.Contains("c2") == true) && (checkIsMill(Xmills,mill11) != true) && (checkIsMill(Omills,mill11) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill11);
                }
                else
                {
                    Omills.Add(mill11);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("e2") == true) && (PlayerMoves.Contains("f2") == true) && (PlayerMoves.Contains("g2") == true) && (checkIsMill(Xmills,mill12) != true) && (checkIsMill(Omills,mill12) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill12);
                }
                else
                {
                    Omills.Add(mill12);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("c3") == true) && (PlayerMoves.Contains("d4") == true) && (PlayerMoves.Contains("e3") == true) && (checkIsMill(Xmills,mill13) != true) && (checkIsMill(Omills,mill13) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill13);
                }
                else
                {
                    Omills.Add(mill13);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("b3") == true) && (PlayerMoves.Contains("d5") == true) && (PlayerMoves.Contains("f3") == true) && (checkIsMill(Xmills,mill14) != true) && (checkIsMill(Omills,mill14) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill14);
                }
                else
                {
                    Omills.Add(mill14);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("a3") == true) && (PlayerMoves.Contains("d6") == true) && (PlayerMoves.Contains("g3") == true) && (checkIsMill(Xmills,mill15) != true) && (checkIsMill(Omills,mill15) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill15);
                }
                else
                {
                    Omills.Add(mill15);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("a3") == true) && (PlayerMoves.Contains("b3") == true) && (PlayerMoves.Contains("c3") == true) && (checkIsMill(Xmills,mill16) != true) && (checkIsMill(Omills,mill16) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill16);
                }
                else
                {
                    Omills.Add(mill16);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("g1") == true) && (PlayerMoves.Contains("f1") == true) && (PlayerMoves.Contains("e1") == true) && (checkIsMill(Xmills,mill17) != true) && (checkIsMill(Omills,mill17) != true)) == true)
            {
                if (player == "X")
                {
                    Xmills.Add(mill17);
                }
                else
                {
                    Omills.Add(mill17);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("g3") == true) && (PlayerMoves.Contains("f3") == true) && (PlayerMoves.Contains("e3") == true) && (checkIsMill(Xmills,mill18) != true) && (checkIsMill(Omills,mill18) != true)) == true)
            {
                if (player == "X")
                {

                    Xmills.Add(mill18);
                }
                else
                {
                    Omills.Add(mill18);
                }
                return true;
            }
            else if (((PlayerMoves.Contains("a1") == true) && (PlayerMoves.Contains("b1") == true) && (PlayerMoves.Contains("c1") == true) && (checkIsMill(Xmills,mill19) != true) && (checkIsMill(Omills,mill19) != true)) == true)
            {
                if (player == "X")
                {

                    Xmills.Add(mill19);
                }
                else
                {
                    Omills.Add(mill19);
                }
                return true;
            }

            return false;
        }

        bool checkIsMill(List<string[]> mills, string[] mill)
        {
            foreach (string[] x in mills)
            {
                if ((x[0] == mill[0]) && (x[1] == mill[1]) && (x[2] == mill[2]))
                    return true;
            }
            return false;
        }
        //method iri pazasi inoisa move yemutambi paboard 
        private void placeMove(string inpt, string mutambi)
        {
            if (SpotIsBlank(inpt) == false) // kutarisa kuona kuti parikuda kuiswa panechunhu here
            {
                if (mutambi == "X") //kutarisa mutambi arikuisa tsoro
                    XMoves.Add(inpt); //inoisa move rachuziwa nemutambi
                if (mutambi == "O")
                    OMoves.Add(inpt);
                switch (inpt)
                {
                    case "a1":
                        a1.Text = mutambi;
                        return;
                    case "a2":
                        a2.Text = mutambi;
                        return;
                    case "a3":
                        a3.Text = mutambi;
                        return;
                    case "b1":
                        b1.Text = mutambi;
                        return;
                    case "b2":
                        b2.Text = mutambi;
                        return;
                    case "b3":
                        b3.Text = mutambi;
                        return;
                    case "c1":
                        c1.Text = mutambi;
                        return;
                    case "c2":
                        c2.Text = mutambi;
                        return;
                    case "c3":
                        c3.Text = mutambi;
                        return;
                    case "d1":
                        d1.Text = mutambi;
                        return;
                    case "d2":
                        d2.Text = mutambi;
                        return;
                    case "d3":
                        d3.Text = mutambi;
                        return;
                    case "d4":
                        d4.Text = mutambi;
                        return;
                    case "d5":
                        d5.Text = mutambi;
                        return;
                    case "d6":
                        d6.Text = mutambi;
                        return;
                    case "e1":
                        e1.Text = mutambi;
                        return;
                    case "e2":
                        e2.Text = mutambi;
                        return;
                    case "e3":
                        e3.Text = mutambi;
                        return;
                    case "f1":
                        f1.Text = mutambi;
                        return;
                    case "f2":
                        f2.Text = mutambi;
                        return;
                    case "f3":
                        f3.Text = mutambi;
                        return;
                    case "g1":
                        g1.Text = mutambi;
                        return;
                    case "g2":
                        g2.Text = mutambi;
                        return;
                    case "g3":
                        g3.Text = mutambi;
                        return;

                }
            }
            else
            {
                info.Text = ("Spot occupied choose another spot");
                throw new Exception();
            }
        }

        private bool SpotIsBlank(string inpt)
        {
            return XMoves.Contains(inpt) || OMoves.Contains(inpt);
        }

        private bool checkIfValid(string inpt)
        {
            switch (inpt)
            {
                case "a1":
                    return true;
                case "a2":
                    return true;
                case "a3":
                    return true;
                case "b1":
                    return true;
                case "b2":
                    return true;
                case "b3":
                    return true;
                case "c1":
                    return true;
                case "c2":
                    return true;
                case "c3":
                    return true;
                case "d1":
                    return true;
                case "d2":
                    return true;
                case "d3":
                    return true;
                case "d4":
                    return true;
                case "d5":
                    return true;
                case "d6":
                    return true;
                case "e1":
                    return true;
                case "e2":
                    return true;
                case "e3":
                    return true;
                case "f1":
                    return true;
                case "f2":
                    return true;
                case "f3":
                    return true;
                case "g1":
                    return true;
                case "g2":
                    return true;
                case "g3":
                    return true;
                default:
                    return false;
            }

        }

        private void c1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void gun_Click(object sender, RoutedEventArgs e)
        {
            
                string remove = target.Text;
                if (checkIfValid(remove) == false)
                {
                info.Text = ("Enter Valid Position");
                    return;
                }
                if (SpotIsBlank(remove) == true)
                {
                info.Text = ("Spot is blank buddy");
                    return;
                }
               
                if (player == 1)
                {
                    if (XMoves.Contains(remove))
                    {
                    info.Text = ("You can not shoot your own cow choose another");
                        return;
                    }
                    else
                    {
                        RemoveSpot(remove, "");
                        DestroyMill(Omills, remove);
                        shoot.Visibility = Visibility.Hidden;
                        gun.Visibility = Visibility.Hidden;
                        target.Visibility = Visibility.Hidden;
                        play.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    if (OMoves.Contains(remove))
                    {
                    info.Text = ("You can not shoot your own cow choose another");
                        return;
                    }
                    else
                    {
                        RemoveSpot(remove, "");
                        DestroyMill(Xmills, remove);
                        shoot.Visibility = Visibility.Hidden;
                        gun.Visibility = Visibility.Hidden;
                        target.Visibility = Visibility.Hidden;
                        play.Visibility = Visibility.Visible;
                    }
                }
            xCowsOnBoard.Text = Convert.ToString(XMoves.Count);
            oCowsOnBoard.Text = Convert.ToString(OMoves.Count);


        }

        private void DestroyMill(List<string[]> Opponetmills, string remove) 
        {
            List<int> targets = new List<int>();
            for(int i =0; i < Opponetmills.Count; i++)
            {
                string[] x = Opponetmills[i];
                for (int j = 0; j < Opponetmills[i].Length; j++)
                {
                    
                    if (x[j] == remove)
                    {
                        targets.Add(i);
                    }
                }
            }
            int scaler = 0;
            for(int index = 0; index < targets.Count; index++)
            {
                Opponetmills.RemoveAt(index + scaler);
                scaler++;
            }
            xCowsOnBoard.Text = Convert.ToString(XMoves.Count);
            oCowsOnBoard.Text = Convert.ToString(OMoves.Count);
        }

        private void RemoveSpot(string inpt, string mutambi)
        {
            if (SpotIsBlank(inpt) == true) // kutarisa kuona kuti parikuda kuiswa panechunhu here
            {
                if (player == 1) //kutarisa mutambi arikuisa tsoro
                    OMoves.Remove(inpt); //inoisa move rachuziwa nemutambi
                if (player == 0)
                    XMoves.Remove(inpt);
                switch (inpt)
                {
                    case "a1":
                        a1.Text = mutambi;
                        return;
                    case "a2":
                        a2.Text = mutambi;
                        return;
                    case "a3":
                        a3.Text = mutambi;
                        return;
                    case "b1":
                        b1.Text = mutambi;
                        return;
                    case "b2":
                        b2.Text = mutambi;
                        return;
                    case "b3":
                        b3.Text = mutambi;
                        return;
                    case "c1":
                        c1.Text = mutambi;
                        return;
                    case "c2":
                        c2.Text = mutambi;
                        return;
                    case "c3":
                        c3.Text = mutambi;
                        return;
                    case "d1":
                        d1.Text = mutambi;
                        return;
                    case "d2":
                        d2.Text = mutambi;
                        return;
                    case "d3":
                        d3.Text = mutambi;
                        return;
                    case "d4":
                        d4.Text = mutambi;
                        return;
                    case "d5":
                        d5.Text = mutambi;
                        return;
                    case "d6":
                        d6.Text = mutambi;
                        return;
                    case "e1":
                        e1.Text = mutambi;
                        return;
                    case "e2":
                        e2.Text = mutambi;
                        return;
                    case "e3":
                        e3.Text = mutambi;
                        return;
                    case "f1":
                        f1.Text = mutambi;
                        return;
                    case "f2":
                        f2.Text = mutambi;
                        return;
                    case "f3":
                        f3.Text = mutambi;
                        return;
                    case "g1":
                        g1.Text = mutambi;
                        return;
                    case "g2":
                        g2.Text = mutambi;
                        return;
                    case "g3":
                        g3.Text = mutambi;
                        return;

                }
            }
        }

        private void moveCow_Click(object sender, RoutedEventArgs e)
        {
            string takeThisCow = from.Text;
            string toThisPlace = to.Text;
            if (checkIfValid(takeThisCow) == false && checkIfValid(toThisPlace) == false)
            {
                info.Text = ("invalid choices");
                return;
            }
            if (SpotIsBlank(takeThisCow) == false)
            {
                info.Text = ("Spot is blank");
                return;
            }

            //.................Pano......................................

            //uncomment the if statement when you complete the isNotNextToSpot
            //which checks the adjaustent 



            //if (IsNotNextToSpot(takeThisCow, toThisPlace)==false)
            //{
            //    info.Text=("Cow Can not fly");
            //    return;
            //}

            //.................................................................
            if (SpotIsBlank(toThisPlace) == true)
            {
                info.Text = (toThisPlace + " is occupied");

                return;
            }
            if (player == 1) //means X since O was the last person to play
            {
                // MessageBox.Show("O is playing");
                if (OMoves.Contains(takeThisCow) == false)
                {
                    info.Text = ("Can't move a cow thats not yours");
                    return;
                }
                RemoveSpot(takeThisCow, "");
                DestroyMill(Omills, takeThisCow);
                placeMove(toThisPlace, "O");
                if (isMill(OMoves, "O") == true)
                {
                    info.Text = ("O Mill Found!\n Choose Cow to shoot");
                    shoot.Visibility = Visibility.Visible;
                    gun.Visibility = Visibility.Visible;
                    target.Visibility = Visibility.Visible;
                    // movecow.Visibility = Visibility.Hidden;
                }
                player--;
            }
            if (player == 0)
            {
                //MessageBox.Show("X is playing");
                if (XMoves.Contains(takeThisCow) == false)
                {
                    info.Text = ("Can't move a cow thats not yours");
                    return;
                }
                RemoveSpot(takeThisCow, "");
                DestroyMill(Xmills, takeThisCow);
                placeMove(toThisPlace, "X");
                if (isMill(XMoves, "X") == true)
                {
                    info.Text = ("X Mill Found!\n Choose Cow to shoot");
                    shoot.Visibility = Visibility.Visible;
                    gun.Visibility = Visibility.Visible;
                    target.Visibility = Visibility.Visible;
                    // movecow.Visibility = Visibility.Hidden;
                }
                player++;
            }
        }

        private bool IsNotNextToSpot(string original, string moved)
        {
            if (original == "a1")
            {
                return moved == "a2" || moved == "b1" || moved == "d1";
            }
            return false;
        }
    }
}
