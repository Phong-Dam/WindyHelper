using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Config
{
    public partial class Form1 : Form
    {
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }
        bool AddKey=false;
        string FetchString(string section,string key,int defaultValue)
        {
            int number = Profile.ProfileFetchInt(section, key, defaultValue);
            char character = (char)number;
            if (number == 27)
            {
                return "";
            }
            return character.ToString();
        }
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick; 
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            cb_Skill_Enable.Checked = Profile.ProfileFetchBool("Hotkey Skill", "Enable", true);
            cb_Item_Enable.Checked = Profile.ProfileFetchBool("Hotkey Item", "Enable", true);
            cb_Shop_Enable.Checked = Profile.ProfileFetchBool("Shop", "Enable", true);
            //
            skill_0.Text = FetchString("Hotkey Skill", "0", 27);
            skill_1.Text = FetchString("Hotkey Skill", "1", 27);
            skill_2.Text = FetchString("Hotkey Skill", "2", 27);
            skill_3.Text = FetchString("Hotkey Skill", "3", 27);
            skill_4.Text = FetchString("Hotkey Skill", "4", 27);
            skill_5.Text = FetchString("Hotkey Skill", "5", 27);
            skill_6.Text = FetchString("Hotkey Skill", "6", 27);
            skill_7.Text = FetchString("Hotkey Skill", "7", 27);
            skill_8.Text = FetchString("Hotkey Skill", "8", 27);
            skill_9.Text = FetchString("Hotkey Skill", "9", 27);
            skill_10.Text = FetchString("Hotkey Skill", "10", 27);
            skill_11.Text = FetchString("Hotkey Skill", "11", 27);
            //
            item_0.Text = FetchString("Hotkey Item", "12", 27);
            item_1.Text = FetchString("Hotkey Item", "13", 27);
            item_2.Text = FetchString("Hotkey Item", "14", 27);
            item_3.Text = FetchString("Hotkey Item", "15", 27);
            item_4.Text = FetchString("Hotkey Item", "16", 27);
            item_5.Text = FetchString("Hotkey Item", "17", 27);
            //
            shop_0.Text = FetchString("Shop", "0", 27);
            shop_1.Text = FetchString("Shop", "1", 27);
            shop_2.Text = FetchString("Shop", "2", 27);
            shop_3.Text = FetchString("Shop", "3", 27);
            shop_4.Text = FetchString("Shop", "4", 27);
            shop_5.Text = FetchString("Shop", "5", 27);
            shop_6.Text = FetchString("Shop", "6", 27);
            shop_7.Text = FetchString("Shop", "7", 27);
            shop_8.Text = FetchString("Shop", "8", 27);
            shop_9.Text = FetchString("Shop", "9", 27);
            shop_10.Text = FetchString("Shop", "10", 27);
            shop_11.Text = FetchString("Shop", "11", 27);
            //
            cb_skillqc_0.Checked = Profile.ProfileFetchBool("Quick Cast", "0", false);
            cb_skillqc_1.Checked = Profile.ProfileFetchBool("Quick Cast", "1", false);
            cb_skillqc_2.Checked = Profile.ProfileFetchBool("Quick Cast", "2", false);
            cb_skillqc_3.Checked = Profile.ProfileFetchBool("Quick Cast", "3", false);
            cb_skillqc_4.Checked = Profile.ProfileFetchBool("Quick Cast", "4", false);
            cb_skillqc_5.Checked = Profile.ProfileFetchBool("Quick Cast", "5", false);
            cb_skillqc_6.Checked = Profile.ProfileFetchBool("Quick Cast", "6", false);
            cb_skillqc_7.Checked = Profile.ProfileFetchBool("Quick Cast", "7", false);
            cb_skillqc_8.Checked = Profile.ProfileFetchBool("Quick Cast", "8", false);
            cb_skillqc_9.Checked = Profile.ProfileFetchBool("Quick Cast", "9", false);
            cb_skillqc_10.Checked = Profile.ProfileFetchBool("Quick Cast", "10", false);
            cb_skillqc_11.Checked = Profile.ProfileFetchBool("Quick Cast", "11", false);

            cb_skillsc_0.Checked = Profile.ProfileFetchBool("Self Click", "0", false);
            cb_skillsc_1.Checked = Profile.ProfileFetchBool("Self Click", "1", false);
            cb_skillsc_2.Checked = Profile.ProfileFetchBool("Self Click", "2", false);
            cb_skillsc_3.Checked = Profile.ProfileFetchBool("Self Click", "3", false);
            cb_skillsc_4.Checked = Profile.ProfileFetchBool("Self Click", "4", false);
            cb_skillsc_5.Checked = Profile.ProfileFetchBool("Self Click", "5", false);
            cb_skillsc_6.Checked = Profile.ProfileFetchBool("Self Click", "6", false);
            cb_skillsc_7.Checked = Profile.ProfileFetchBool("Self Click", "7", false);
            cb_skillsc_8.Checked = Profile.ProfileFetchBool("Self Click", "8", false);
            cb_skillsc_9.Checked = Profile.ProfileFetchBool("Self Click", "9", false);
            cb_skillsc_10.Checked = Profile.ProfileFetchBool("Self Click", "10", false);
            cb_skillsc_11.Checked = Profile.ProfileFetchBool("Self Click", "11", false);
            //
            cb_itemqc_0.Checked = Profile.ProfileFetchBool("Quick Cast", "12", false);
            cb_itemqc_1.Checked = Profile.ProfileFetchBool("Quick Cast", "13", false);
            cb_itemqc_2.Checked = Profile.ProfileFetchBool("Quick Cast", "14", false);
            cb_itemqc_3.Checked = Profile.ProfileFetchBool("Quick Cast", "15", false);
            cb_itemqc_4.Checked = Profile.ProfileFetchBool("Quick Cast", "16", false);
            cb_itemqc_5.Checked = Profile.ProfileFetchBool("Quick Cast", "17", false);

            cb_itemsc_0.Checked = Profile.ProfileFetchBool("Self Click", "12", false);
            cb_itemsc_1.Checked = Profile.ProfileFetchBool("Self Click", "13", false);
            cb_itemsc_2.Checked = Profile.ProfileFetchBool("Self Click", "14", false);
            cb_itemsc_3.Checked = Profile.ProfileFetchBool("Self Click", "15", false);
            cb_itemsc_4.Checked = Profile.ProfileFetchBool("Self Click", "16", false);
            cb_itemsc_5.Checked = Profile.ProfileFetchBool("Self Click", "17", false);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Profile.ProfileInit("WindyHelper.txt");

            skill_0.Text = FetchString("Hotkey Skill", "0", 27);
            skill_1.Text = FetchString("Hotkey Skill", "1", 27);
            skill_2.Text = FetchString("Hotkey Skill", "2", 27);
            skill_3.Text = FetchString("Hotkey Skill", "3", 27);
            skill_4.Text = FetchString("Hotkey Skill", "4", 27);
            skill_5.Text = FetchString("Hotkey Skill", "5", 27);
            skill_6.Text = FetchString("Hotkey Skill", "6", 27);
            skill_7.Text = FetchString("Hotkey Skill", "7", 27);
            skill_8.Text = FetchString("Hotkey Skill", "8", 27);
            skill_9.Text = FetchString("Hotkey Skill", "9", 27);
            skill_10.Text = FetchString("Hotkey Skill", "10", 27);
            skill_11.Text = FetchString("Hotkey Skill", "11", 27);
            //
            item_0.Text = FetchString("Hotkey Item", "12", 27);
            item_1.Text = FetchString("Hotkey Item", "13", 27);
            item_2.Text = FetchString("Hotkey Item", "14", 27);
            item_3.Text = FetchString("Hotkey Item", "15", 27);
            item_4.Text = FetchString("Hotkey Item", "16", 27);
            item_5.Text = FetchString("Hotkey Item", "17", 27);
            //
            shop_0.Text = FetchString("Shop", "0", 27);
            shop_1.Text = FetchString("Shop", "1", 27);
            shop_2.Text = FetchString("Shop", "2", 27);
            shop_3.Text = FetchString("Shop", "3", 27);
            shop_4.Text = FetchString("Shop", "4", 27);
            shop_5.Text = FetchString("Shop", "5", 27);
            shop_6.Text = FetchString("Shop", "6", 27);
            shop_7.Text = FetchString("Shop", "7", 27);
            shop_8.Text = FetchString("Shop", "8", 27);
            shop_9.Text = FetchString("Shop", "9", 27);
            shop_10.Text = FetchString("Shop", "10", 27);
            shop_11.Text = FetchString("Shop", "11", 27);
            //
            cb_skillqc_0.Checked = Profile.ProfileFetchBool("Quick Cast", "0", false);
            cb_skillqc_1.Checked = Profile.ProfileFetchBool("Quick Cast", "1", false);
            cb_skillqc_2.Checked = Profile.ProfileFetchBool("Quick Cast", "2", false);
            cb_skillqc_3.Checked = Profile.ProfileFetchBool("Quick Cast", "3", false);
            cb_skillqc_4.Checked = Profile.ProfileFetchBool("Quick Cast", "4", false);
            cb_skillqc_5.Checked = Profile.ProfileFetchBool("Quick Cast", "5", false);
            cb_skillqc_6.Checked = Profile.ProfileFetchBool("Quick Cast", "6", false);
            cb_skillqc_7.Checked = Profile.ProfileFetchBool("Quick Cast", "7", false);
            cb_skillqc_8.Checked = Profile.ProfileFetchBool("Quick Cast", "8", false);
            cb_skillqc_9.Checked = Profile.ProfileFetchBool("Quick Cast", "9", false);
            cb_skillqc_10.Checked = Profile.ProfileFetchBool("Quick Cast", "10", false);
            cb_skillqc_11.Checked = Profile.ProfileFetchBool("Quick Cast", "11", false);

            cb_skillsc_0.Checked = Profile.ProfileFetchBool("Self Click", "0", false);
            cb_skillsc_1.Checked = Profile.ProfileFetchBool("Self Click", "1", false);
            cb_skillsc_2.Checked = Profile.ProfileFetchBool("Self Click", "2", false);
            cb_skillsc_3.Checked = Profile.ProfileFetchBool("Self Click", "3", false);
            cb_skillsc_4.Checked = Profile.ProfileFetchBool("Self Click", "4", false);
            cb_skillsc_5.Checked = Profile.ProfileFetchBool("Self Click", "5", false);
            cb_skillsc_6.Checked = Profile.ProfileFetchBool("Self Click", "6", false);
            cb_skillsc_7.Checked = Profile.ProfileFetchBool("Self Click", "7", false);
            cb_skillsc_8.Checked = Profile.ProfileFetchBool("Self Click", "8", false);
            cb_skillsc_9.Checked = Profile.ProfileFetchBool("Self Click", "9", false);
            cb_skillsc_10.Checked = Profile.ProfileFetchBool("Self Click", "10", false);
            cb_skillsc_11.Checked = Profile.ProfileFetchBool("Self Click", "11", false);
            //
            cb_itemqc_0.Checked = Profile.ProfileFetchBool("Quick Cast", "12", false);
            cb_itemqc_1.Checked = Profile.ProfileFetchBool("Quick Cast", "13", false);
            cb_itemqc_2.Checked = Profile.ProfileFetchBool("Quick Cast", "14", false);
            cb_itemqc_3.Checked = Profile.ProfileFetchBool("Quick Cast", "15", false);
            cb_itemqc_4.Checked = Profile.ProfileFetchBool("Quick Cast", "16", false);
            cb_itemqc_5.Checked = Profile.ProfileFetchBool("Quick Cast", "17", false);

            cb_itemsc_0.Checked = Profile.ProfileFetchBool("Self Click", "12", false);
            cb_itemsc_1.Checked = Profile.ProfileFetchBool("Self Click", "13", false);
            cb_itemsc_2.Checked = Profile.ProfileFetchBool("Self Click", "14", false);
            cb_itemsc_3.Checked = Profile.ProfileFetchBool("Self Click", "15", false);
            cb_itemsc_4.Checked = Profile.ProfileFetchBool("Self Click", "16", false);
            cb_itemsc_5.Checked = Profile.ProfileFetchBool("Self Click", "17", false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void skill_0_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_0.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "0", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_0.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "0", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_1.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "1", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_1.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "1", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_2.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "2", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_2.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "2", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_3.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "3", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_3.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "3", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_4_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_4.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "4", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_4.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "4", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_5.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "5", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_5.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "5", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_6_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_6.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "6", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_6.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "6", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_7_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_7.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "7", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_7.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "7", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_8_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_8.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "8", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_8.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "8", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_9_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_9.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "9", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_9.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "9", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_10_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_10.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "10", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_10.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "10", 27);
                this.ActiveControl = null;
            }
        }

        private void skill_11_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                skill_11.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Skill", "11", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                skill_11.Text = "";
                Profile.ProfileSetInt("Hotkey Skill", "11", 27);
                this.ActiveControl = null;
            }
        }

        private void item_0_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                item_0.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Item", "12", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                item_0.Text = "";
                Profile.ProfileSetInt("Hotkey Item", "12", 27);
                this.ActiveControl = null;
            }
        }

        private void item_1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                item_1.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Item", "13", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                item_1.Text = "";
                Profile.ProfileSetInt("Hotkey Item", "13", 27);
                this.ActiveControl = null;
            }
        }

        private void item_2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                item_2.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Item", "14", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                item_2.Text = "";
                Profile.ProfileSetInt("Hotkey Item", "14", 27);
                this.ActiveControl = null;
            }
        }

        private void item_3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                item_3.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Item", "15", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                item_3.Text = "";
                Profile.ProfileSetInt("Hotkey Item", "15", 27);
                this.ActiveControl = null;
            }
        }

        private void item_4_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                item_4.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Item", "16", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                item_4.Text = "";
                Profile.ProfileSetInt("Hotkey Item", "16", 27);
                this.ActiveControl = null;
            }
        }

        private void item_5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                item_5.Text = keyChar.ToString();
                Profile.ProfileSetInt("Hotkey Item", "17", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                item_5.Text = "";
                Profile.ProfileSetInt("Hotkey Item", "17", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_0_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_0.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "0", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_0.Text = "";
                Profile.ProfileSetInt("Shop", "0", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_1.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "1", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_1.Text = "";
                Profile.ProfileSetInt("Shop", "1", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_2.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "2", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_2.Text = "";
                Profile.ProfileSetInt("Shop", "2", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_3.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "3", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_3.Text = "";
                Profile.ProfileSetInt("Shop", "3", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_4_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_4.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "4", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_4.Text = "";
                Profile.ProfileSetInt("Shop", "4", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_5.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "5", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_5.Text = "";
                Profile.ProfileSetInt("Shop", "5", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_6_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_6.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "6", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_6.Text = "";
                Profile.ProfileSetInt("Shop", "6", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_7_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_7.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "7", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_7.Text = "";
                Profile.ProfileSetInt("Shop", "7", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_8_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_8.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "8", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_8.Text = "";
                Profile.ProfileSetInt("Shop", "8", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_9_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_9.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "9", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_9.Text = "";
                Profile.ProfileSetInt("Shop", "9", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_10_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_10.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "10", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_10.Text = "";
                Profile.ProfileSetInt("Shop", "10", 27);
                this.ActiveControl = null;
            }
        }

        private void shop_11_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                char keyChar = (char)(e.KeyValue);
                shop_11.Text = keyChar.ToString();
                Profile.ProfileSetInt("Shop", "11", e.KeyValue);
                this.ActiveControl = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                shop_11.Text = "";
                Profile.ProfileSetInt("Shop", "11", 27);
                this.ActiveControl = null;
            }
        }

        private void cb_skillqc_0_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_0.Checked == true)
            {
                cb_skillsc_0.Checked = false;
                Profile.ProfileSetBool("Self Click", "0", false);
                Profile.ProfileSetBool("Quick Cast", "0", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "0", false);
        }

        private void cb_skillqc_1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_1.Checked == true)
            {
                cb_skillsc_1.Checked = false;
                Profile.ProfileSetBool("Self Click", "1", false);
                Profile.ProfileSetBool("Quick Cast", "1", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "1", false);
        }

        private void cb_skillqc_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_2.Checked == true)
            {
                cb_skillsc_2.Checked = false;
                Profile.ProfileSetBool("Self Click", "2", false);
                Profile.ProfileSetBool("Quick Cast", "2", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "2", false);
        }

        private void cb_skillqc_3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_3.Checked == true)
            {
                cb_skillsc_3.Checked = false;
                Profile.ProfileSetBool("Self Click", "3", false);
                Profile.ProfileSetBool("Quick Cast", "3", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "3", false);
        }

        private void cb_skillqc_4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_4.Checked == true)
            {
                cb_skillsc_4.Checked = false;
                Profile.ProfileSetBool("Self Click", "4", false);
                Profile.ProfileSetBool("Quick Cast", "4", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "4", false);
        }

        private void cb_skillqc_5_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_5.Checked == true)
            {
                cb_skillsc_5.Checked = false;
                Profile.ProfileSetBool("Self Click", "5", false);
                Profile.ProfileSetBool("Quick Cast", "5", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "5", false);
        }

        private void cb_skillqc_6_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_6.Checked == true)
            {
                cb_skillsc_6.Checked = false;
                Profile.ProfileSetBool("Self Click", "6", false);
                Profile.ProfileSetBool("Quick Cast", "6", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "6", false);
        }

        private void cb_skillqc_7_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_7.Checked == true)
            {
                cb_skillsc_7.Checked = false;
                Profile.ProfileSetBool("Self Click", "7", false);
                Profile.ProfileSetBool("Quick Cast", "7", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "7", false);
        }

        private void cb_skillqc_8_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_8.Checked == true)
            {
                cb_skillsc_8.Checked = false;
                Profile.ProfileSetBool("Self Click", "8", false);
                Profile.ProfileSetBool("Quick Cast", "8", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "8", false);
        }

        private void cb_skillqc_9_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_9.Checked == true)
            {
                cb_skillsc_9.Checked = false;
                Profile.ProfileSetBool("Self Click", "9", false);
                Profile.ProfileSetBool("Quick Cast", "9", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "9", false);
        }

        private void cb_skillqc_10_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_10.Checked == true)
            {
                cb_skillsc_10.Checked = false;
                Profile.ProfileSetBool("Self Click", "10", false);
                Profile.ProfileSetBool("Quick Cast", "10", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "10", false);
        }

        private void cb_skillqc_11_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillqc_11.Checked == true)
            {
                cb_skillsc_11.Checked = false;
                Profile.ProfileSetBool("Self Click", "11", false);
                Profile.ProfileSetBool("Quick Cast", "11", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "11", false);
        }

        private void cb_itemqc_0_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemqc_0.Checked == true)
            {
                cb_itemsc_0.Checked = false;
                Profile.ProfileSetBool("Self Click", "12", false);
                Profile.ProfileSetBool("Quick Cast", "12", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "12", false);
        }

        private void cb_itemqc_1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemqc_1.Checked == true)
            {
                cb_itemsc_1.Checked = false;
                Profile.ProfileSetBool("Self Click", "13", false);
                Profile.ProfileSetBool("Quick Cast", "13", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "13", false);
        }

        private void cb_itemqc_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemqc_2.Checked == true)
            {
                cb_itemsc_2.Checked = false;
                Profile.ProfileSetBool("Self Click", "14", false);
                Profile.ProfileSetBool("Quick Cast", "14", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "14", false);
        }

        private void cb_itemqc_3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemqc_3.Checked == true)
            {
                cb_itemsc_3.Checked = false;
                Profile.ProfileSetBool("Self Click", "15", false);
                Profile.ProfileSetBool("Quick Cast", "15", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "15", false);
        }

        private void cb_itemqc_4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemqc_4.Checked == true)
            {
                cb_itemsc_4.Checked = false;
                Profile.ProfileSetBool("Self Click", "16", false);
                Profile.ProfileSetBool("Quick Cast", "16", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "16", false);
        }

        private void cb_itemqc_5_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemqc_5.Checked == true)
            {
                cb_itemsc_5.Checked = false;
                Profile.ProfileSetBool("Self Click", "17", false);
                Profile.ProfileSetBool("Quick Cast", "17", true);
            }
            else
                Profile.ProfileSetBool("Quick Cast", "17", false);
        }

        private void cb_skillsc_0_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_0.Checked == true)
            {
                cb_skillqc_0.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "0", false);
                Profile.ProfileSetBool("Self Click", "0", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "0", false);
        }


        private void cb_skillsc_1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_1.Checked == true)
            {
                cb_skillqc_1.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "1", false);
                Profile.ProfileSetBool("Self Click", "1", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "1", false);
        }

        private void cb_skillsc_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_2.Checked == true)
            {
                cb_skillqc_2.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "2", false);
                Profile.ProfileSetBool("Self Click", "2", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "2", false);
        }

        private void cb_skillsc_3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_3.Checked == true)
            {
                cb_skillqc_3.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "3", false);
                Profile.ProfileSetBool("Self Click", "3", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "3", false);
        }

        private void cb_skillsc_4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_4.Checked == true)
            {
                cb_skillqc_4.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "4", false);
                Profile.ProfileSetBool("Self Click", "4", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "4", false);
        }

        private void cb_skillsc_5_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_5.Checked == true)
            {
                cb_skillqc_5.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "5", false);
                Profile.ProfileSetBool("Self Click", "5", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "5", false);
        }

        private void cb_skillsc_6_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_6.Checked == true)
            {
                cb_skillqc_6.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "6", false);
                Profile.ProfileSetBool("Self Click", "6", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "6", false);
        }

        private void cb_skillsc_7_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_7.Checked == true)
            {
                cb_skillqc_7.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "7", false);
                Profile.ProfileSetBool("Self Click", "7", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "7", false);
        }

        private void cb_skillsc_8_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_8.Checked == true)
            {
                cb_skillqc_8.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "8", false);
                Profile.ProfileSetBool("Self Click", "8", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "8", false);
        }

        private void cb_skillsc_9_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_9.Checked == true)
            {
                cb_skillqc_9.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "9", false);
                Profile.ProfileSetBool("Self Click", "9", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "9", false);
        }

        private void cb_skillsc_10_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_10.Checked == true)
            {
                cb_skillqc_10.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "10", false);
                Profile.ProfileSetBool("Self Click", "10", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "10", false);
        }

        private void cb_skillsc_11_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_skillsc_11.Checked == true)
            {
                cb_skillqc_11.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "11", false);
                Profile.ProfileSetBool("Self Click", "11", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "11", false);
        }

        private void cb_itemsc_0_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemsc_0.Checked == true)
            {
                cb_itemqc_0.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "12", false);
                Profile.ProfileSetBool("Self Click", "12", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "12", false);
        }

        private void cb_itemsc_1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemsc_1.Checked == true)
            {
                cb_itemqc_1.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "13", false);
                Profile.ProfileSetBool("Self Click", "13", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "13", false);
        }

        private void cb_itemsc_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemsc_2.Checked == true)
            {
                cb_itemqc_2.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "14", false);
                Profile.ProfileSetBool("Self Click", "14", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "14", false);
        }

        private void cb_itemsc_3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemsc_3.Checked == true)
            {
                cb_itemqc_3.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "15", false);
                Profile.ProfileSetBool("Self Click", "15", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "15", false);
        }

        private void cb_itemsc_4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemsc_4.Checked == true)
            {
                cb_itemqc_4.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "16", false);
                Profile.ProfileSetBool("Self Click", "16", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "16", false);
        }

        private void cb_itemsc_5_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_itemsc_5.Checked == true)
            {
                cb_itemqc_5.Checked = false;
                Profile.ProfileSetBool("Quick Cast", "17", false);
                Profile.ProfileSetBool("Self Click", "17", true);
            }
            else
                Profile.ProfileSetBool("Self Click", "17", false);
        }

        private void cb_Skill_Enable_CheckedChanged(object sender, EventArgs e)
        {
            Profile.ProfileSetBool("Hotkey Skill", "Enable", cb_Skill_Enable.Checked);
        }

        private void cb_Item_Enable_CheckedChanged(object sender, EventArgs e)
        {
            Profile.ProfileSetBool("Hotkey Item", "Enable", cb_Item_Enable.Checked);
        }

        private void cb_Shop_Enable_CheckedChanged(object sender, EventArgs e)
        {
            Profile.ProfileSetBool("Shop", "Enable", cb_Shop_Enable.Checked);
        }
    }
}
