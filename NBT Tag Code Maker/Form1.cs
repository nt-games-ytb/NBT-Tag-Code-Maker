#region Not used usings
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.Reflection;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.CodeDom;
using System.Collections;
using System.Configuration;
using System.Deployment;
using System.Dynamic;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Resources;
using System.Runtime;
using System.Security;
using System.Timers;
using System.Web;
using System.Windows;
using System.Xml;
using System.Runtime.ConstrainedExecution;
using System.Runtime.DesignerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Hosting;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Windows.Markup;
using System.Windows.Input;
using System.Net.Cache;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO.Compression;
using NBT_Tag_Code_Maker;
using NBT_Tag_Code_Maker.Properties;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
#endregion

#region Used usings
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Net.Sockets;
using MetroFramework.Forms;
using DiscordRpcDemo;
using MamiesModGecko;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
#endregion

namespace NBT_Tag_Code_Maker
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        private TCPConn Connection;
        private TCPGecko MamiesModGecko;
        private BeforeConnect BeforeConnect = new BeforeConnect();
        public string nintendoNetwork;
        public string code;
        public List<uint> codesList = new List<uint> { };
        private uint tagAddress = 0x12000000;

        #region Tag type address
        string CoupoundTag = "1058FA54";
        string ListTag = "1067DAF0";
        string StringTag = "10783144";
        string IntArrayTag = "1065985C";
        string ByteArrayTag = "105640F4";
        string DoubleTag = "105C76B4";
        string FloatTag = "10623F60";
        string LongTag = "10680298";
        string IntTag = "1065993C";
        string ShortTag = "10748CF8";
        string ByteTag = "1056415C";
        string EndTag = "106021FC";
        #endregion

        #region Explanation of tag types
        /*
            ===================================================================
                                Explanation of tag types :
            - Pre-tag :
            Description : 
            11B0D430 | 0000AFB8 | 00000000 | 00000000
            11B0D430 | Tag name address | 00000000 | 00000017
            Tag data address | Next tag address or 00000000 if nothing | 00000000 | 0000003B
            Tag name in UTF16 | 00000000



            - Coupound tag : 1058FA54 -> 0221A808
            Description : 
            Tag address | 00A8A598 | 00000011 | 00000001
            3F800000 | 00000011 | Address + 0x18 | 00000000
            Other : Si c'est dans une liste il faut 0x10 d'écart entre chaque tag



            - List tag : 1067DAF0 -> 0258EA7C
            Description : 
            Tag address | 00000000 | Start address of the tag data address list | End address of the tag data address list  ///Addresse de Début/Fin de la liste des address des données de tags
            End address of the tag data address list | 0A000000 | 00000000 | 00000000
            00000000 | 00000000 | 00000000 | 00000000
            Address of the data of tags in the list



            - String tag : 10783144 -> 02954AB4
            Description : 
            00000000 | String tag name address | 00000000 | 00000008
            Selected tag address | Next tag address or 00000000 if nothing | 00000000 | 00000000
            String tag name in UTF16 | 00000000
            Tag address | 10A8A5A0 | 0000006D | 004E0061
            006D0065 | 00000000 | Value address | String value length
            Value in UTF16 | 00000000



            - Int array tag : 1065985C -> 02516F10
            Description : Not used



            - Byte array tag : 105640F4 -> 02191488
            Description : Not used



            - Double tag : 105C76B4 -> 0382AAC4
            Max value : 1e+308
            Description : 
            Tag address | Value | 00000000
            11B0D430 | 0000AFB8 | 00000000 | 00000000
            11B0D430 | Double tag name address | 00000000 | 00000017
            Selected tag address | Next tag address or 00000000 if nothing | 00000000 | 0000003B
            Double tag name in UTF16 | 00000000



            - Float tag : 10623F60 -> 0243E744
            Max value : 1e+38
            Description : Not used



            - Long tag : 10680298 -> 025ED3FC
            Max value : 999999999999999999 (or 0xDE0B6B3A763FFFF)
            Description : Not used



            - Int tag : 1065993C -> 025177C8
            Max value : 2147483647 (or 0x7FFFFFFF)
            Description : 
            Tag address | Value | 00000000 | 00000000
            11B0D430 | 0000AFB8 | 00000000 | 00000000
            11B0D430 | Int tag name address | 00000000 | 00000017
            Selected tag address | Next tag address or 00000000 if nothing | 00000000 | 0000003B
            Int tag name in UTF16 | 00000000



            - Short tag : 10748CF8 -> 028BBD80
            Max value : 32767 (or 0x7FFF)
            Description : 
            Tag address | Value 0000 | 00000000 | 00000000
            11B0D430 | 0000AFB8 | 00000000 | 00000000
            11B0D430 | Short tag name address | 00000000 | 00000017
            Selected tag address | Next tag address or 00000000 if nothing | 00000000 | 0000003B
            Short tag name in UTF16 | 00000000



            - Byte tag : 1056415C -> 02191D38
            Max value : 127 (or 0x7F)
            Description : 
            Tag address | Value 000000 | 00000000 | 00000000
            11B0D430 | 0000AFB8 | 00000000 | 00000000
            11B0D430 | Byte tag name address | 00000000 | 00000017
            Selected tag address | Next tag address or 00000000 if nothing | 00000000 | 0000003B
            Byte tag name in UTF16 | 00000000



            - End tag : 106021FC -> 023C89F0
            Description : ???
         */
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            #region List details
            potionList.View = View.Details;
            enchantmentList.View = View.Details;
            attributeList.View = View.Details;
            #endregion

            #region Discord RPC
            handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("853039518257119253", ref handlers, true, null);
            presence.details = "Make a NBT tag code - Not connected";
            presence.state = "";
            presence.largeImageKey = "nbt_tag_code_maker_1024";
            presence.smallImageKey = "minecraft";
            presence.largeImageText = "NBT Tag Code Maker V2.1";
            presence.smallImageText = "Minecraft";
            DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long startTimestamp = (long)(DateTime.UtcNow - d).TotalSeconds;
            presence.startTimestamp = startTimestamp;
            DiscordRpc.UpdatePresence(ref presence);
            #endregion
        }

        #region Option
        private void creativeTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemPlace.Enabled = true;
            itemNumber.Enabled = true;
            itemID.Enabled = true;
            itemDamage.Enabled = true;
            unbreakable.Enabled = true;
            enchantment.Enabled = true;
            attribute.Enabled = true;
            make.Enabled = true;
            makeAndAdd.Enabled = true;
        }

        private void itemPlace_ValueChanged(object sender, EventArgs e)
        {

        }

        private void itemNumber_ValueChanged(object sender, EventArgs e)
        {

        }

        private void itemID_ValueChanged(object sender, EventArgs e)
        {
            if (itemID.Value == 373)
            {
                potionBox.Enabled = true;
                colorBox.Enabled = false;
            }
            else
            {
                if (itemID.Value == 438)
                {
                    potionBox.Enabled = true;
                    colorBox.Enabled = false;
                }
                else
                {
                    if (itemID.Value == 441)
                    {
                        potionBox.Enabled = true;
                        colorBox.Enabled = false;
                    }
                    else
                    {
                        if (itemID.Value == 298)
                        {
                            potionBox.Enabled = false;
                            colorBox.Enabled = true;
                        }
                        else
                        {
                            if (itemID.Value == 299)
                            {
                                potionBox.Enabled = false;
                                colorBox.Enabled = true;
                            }
                            else
                            {
                                if (itemID.Value == 300)
                                {
                                    potionBox.Enabled = false;
                                    colorBox.Enabled = true;
                                }
                                else
                                {
                                    if (itemID.Value == 301)
                                    {
                                        potionBox.Enabled = false;
                                        colorBox.Enabled = true;
                                    }
                                    else
                                    {
                                        if (itemID.Value == 358)
                                        {
                                            potionBox.Enabled = false;
                                            colorBox.Enabled = true;
                                        }
                                        else
                                        {
                                            colorBox.Enabled = false;
                                            potionBox.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            presence.state = "Item: " + itemID.Value + ":" + itemDamage.Value;
            DiscordRpc.UpdatePresence(ref presence);
        }

        private void itemDamage_ValueChanged(object sender, EventArgs e)
        {
            presence.state = "Item: " + itemID.Value + ":" + itemDamage.Value;
            DiscordRpc.UpdatePresence(ref presence);
        }

        private void unbreakable_CheckedChanged(object sender, EventArgs e)
        {
            /*if (unbreakable.Checked)
            {
                itemDamage.Enabled = false;
            }
            else
            {
                itemDamage.Enabled = true;
            }*/
        }

        private void enchantment_CheckedChanged(object sender, EventArgs e)
        {
            if (enchantment.Checked)
            {
                enchantmentBox.Enabled = true;
            }
            else
            {
                enchantmentBox.Enabled = false;
            }
        }

        private void attribute_CheckedChanged(object sender, EventArgs e)
        {
            if (attribute.Checked)
            {
                attributeBox.Enabled = true;
            }
            else
            {
                attributeBox.Enabled = false;
            }
        }

        private void info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item ID info :\r\n" +
                "\r\n9 : Still water" +
                "\r\n11 : Still lava" +
                "\r\n34 : Piston head" +
                "\r\n55 : Redstone wire" +
                "\r\n104 : Pumpkim stem" +
                "\r\n105 : Melon stem" +
                "\r\n122 : Dragon egg" +
                "\r\n132 : Tripwire" +
                "\r\n137 : Command block" +
                "\r\n210 : Repeating command block" +
                "\r\n211 : Chain command block" +
                "\r\n166 : Barrier" +
                "\r\n2255 : debug_fourj_item (fake barrier block)" +
                "\r\n276 : Diamond sword" +
                "\r\n454 : Trident" +
                "\r\n456 : Turtle helmet" +
                "\r\n298 : Leather helmet" +
                "\r\n299 : Leather tunic" +
                "\r\n300 : Leather pants" +
                "\r\n301 : Leather boots" +
                "\r\n373 : Potion" +
                "\r\n438 : Splash potion" +
                "\r\n441 : Lingering potion" +
                "\r\n1086 : Full oak wood" +
                "\r\n1081 : Full spruce wood" +
                "\r\n1082 : Full birch wood" +
                "\r\n1083 : Full jungle wood" +
                "\r\n1084 : Full acacia wood" +
                "\r\n1085 : Full dark oak wood" +
                "\r\n", "NBT Tag Code Maker");
        }

        private void itemIdList_Click(object sender, EventArgs e)
        {
            Process.Start("https://minecraft-ids.grahamedgecombe.com/");
        }

        private void tagAddressText_TextChanged(object sender, EventArgs e)
        {
            tagAddress = (uint)Convert.ToInt32(tagAddressText.Text, 16);
        }
        #endregion

        #region Potion
        private void addPotion_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = potionList.Items.Add(potionEffectText.Text);
            listViewItem.SubItems.Add(potionLevel.Value.ToString());
            listViewItem.SubItems.Add(potionDuration.Value.ToString());
        }
        #endregion

        #region Enchantment
        private void addEnchantment_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = enchantmentList.Items.Add(enchantmentText.Text);
            listViewItem.SubItems.Add(enchantmentLevel.Value.ToString());
        }
        #endregion

        #region Attribute
        private void addAttribute_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = attributeList.Items.Add(attributeText.Text);
            listViewItem.SubItems.Add(attributeLevel.Value.ToString());
        }
        #endregion

        #region Color
        private void red_ValueChanged(object sender, EventArgs e)
        {
            colorPanel.BackColor = Color.FromArgb((int)red.Value, (int)green.Value, (int)blue.Value);
            htmlValue.Text = ColorTranslator.ToHtml(colorPanel.BackColor);
        }

        private void green_ValueChanged(object sender, EventArgs e)
        {
            colorPanel.BackColor = Color.FromArgb((int)red.Value, (int)green.Value, (int)blue.Value);
            htmlValue.Text = ColorTranslator.ToHtml(colorPanel.BackColor);
        }

        private void blue_ValueChanged(object sender, EventArgs e)
        {
            colorPanel.BackColor = Color.FromArgb((int)red.Value, (int)green.Value, (int)blue.Value);
            htmlValue.Text = ColorTranslator.ToHtml(colorPanel.BackColor);
        }

        private void htmlValue_TextChanged(object sender, EventArgs e)
        {
            //Change le panel de couleurs
            colorPanel.BackColor = ColorTranslator.FromHtml(htmlValue.Text);

            //Désactive les évenement
            red.ValueChanged -= red_ValueChanged;
            green.ValueChanged -= green_ValueChanged;
            blue.ValueChanged -= blue_ValueChanged;

            //Décortique la valeur html
            red.Value = int.Parse(htmlValue.Text.Substring(1, 2), NumberStyles.HexNumber);
            green.Value = int.Parse(htmlValue.Text.Substring(3, 2), NumberStyles.HexNumber);
            blue.Value = int.Parse(htmlValue.Text.Substring(5, 2), NumberStyles.HexNumber);

            //Active les évenement
            red.ValueChanged += red_ValueChanged;
            green.ValueChanged += green_ValueChanged;
            blue.ValueChanged += blue_ValueChanged;
        }
        #endregion

        private static string convertToHex(int HexValue)
        {
            string result;
            if (HexValue < 0)
            {
                result = Convert.ToString(HexValue, 16);
            }
            else
            {
                if (HexValue < 16)
                {
                    result = "0000000" + Convert.ToString(HexValue, 16);
                }
                else
                {
                    if (HexValue < 256)
                    {
                        result = "000000" + Convert.ToString(HexValue, 16);
                    }
                    else
                    {
                        if (HexValue < 4096)
                        {
                            result = "00000" + Convert.ToString(HexValue, 16);
                        }
                        else
                        {
                            if (HexValue < 65536)
                            {
                                result = "0000" + Convert.ToString(HexValue, 16);
                            }
                            else
                            {
                                if (HexValue < 1048576)
                                {
                                    result = "000" + Convert.ToString(HexValue, 16);
                                }
                                else
                                {
                                    if (HexValue < 16777216)
                                    {
                                        result = "00" + Convert.ToString(HexValue, 16);
                                    }
                                    else
                                    {
                                        if (HexValue < 268435456)
                                        {
                                            result = "0" + Convert.ToString(HexValue, 16);
                                        }
                                        else
                                        {
                                            result = Convert.ToString(HexValue, 16);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public string convertUTF16toHexString(string text, bool codeForm, bool startLine)
        {
            Encoding unicode = Encoding.Unicode;
            Encoding utf16 = Encoding.BigEndianUnicode;
            string result = "";
            string codeFromResult = "";

            byte[] unicodeBytes = unicode.GetBytes(text);
            byte[] utf16Bytes = Encoding.Convert(unicode, utf16, unicodeBytes);

            result = BitConverter.ToString(utf16Bytes).Replace("-", "");

            if (codeForm == true)
            {
                if (result.Length % 8 != 0)
                {
                    while (result.Length % 8 != 0)
                    {
                        result = result + "0";
                    }
                }

                int a = result.Length / 8;
                if (startLine == true)
                {
                    for (int valueNumber = 0; valueNumber < result.Length / 8; valueNumber++)
                    {
                        if (valueNumber % 2 == 0) //Paire
                        {
                            codeFromResult = codeFromResult + result.Substring(valueNumber * 8, 8) + " ";
                            if (valueNumber == (result.Length / 8) - 1)
                            {
                                codeFromResult = codeFromResult + "00000000\r\n";
                            }
                        }
                        else
                        {
                            codeFromResult = codeFromResult + result.Substring(valueNumber * 8, 8) + "\r\n";
                        }
                    }
                }
                else
                {
                    for (int valueNumber = 0; valueNumber < result.Length / 8; valueNumber++)
                    {
                        if (valueNumber % 2 == 0) //Paire
                        {
                            codeFromResult = codeFromResult + result.Substring(valueNumber * 8, 8) + "\r\n";
                        }
                        else
                        {
                            codeFromResult = codeFromResult + result.Substring(valueNumber * 8, 8) + " ";
                            if (valueNumber == (result.Length / 8) - 1)
                            {
                                codeFromResult = codeFromResult + "00000000\r\n";
                            }
                        }
                    }
                }

                return codeFromResult;
            }

            return result;
        }

        private void makeCode()
        {
            #region Creative tab
            string CreativeTabAddress;
            
            if (creativeTab.SelectedIndex == 0) //Building blocks
            {
                CreativeTabAddress = "10A0A6C0";
            }
            else if (creativeTab.SelectedIndex == 1) //Decoration
            {
                CreativeTabAddress = "10A0A6D0";
            }
            else if (creativeTab.SelectedIndex == 2) //Redstone & Transportation
            {
                CreativeTabAddress = "10A0A6F0";
            }
            else if (creativeTab.SelectedIndex == 3) //Material
            {
                CreativeTabAddress = "10A0A700";
            }
            else if (creativeTab.SelectedIndex == 4) //Food
            {
                 CreativeTabAddress = "10A0A710";
            }
            else if (creativeTab.SelectedIndex == 5) //Tools, weapons, armor
            {
                CreativeTabAddress = "10A0A720";
            }
            else if (creativeTab.SelectedIndex == 6) //Brewing
            {
                CreativeTabAddress = "10A0A730";
            }
            else if (creativeTab.SelectedIndex == 7) //Other
            {
                CreativeTabAddress = "10A0A770";
            }
            else
            {
                MessageBox.Show("You have to choose a creative tab !", "NBT Tag Code Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            code =
                "30000000 109DF84C" +
                "\r\n10000000 50000000" +
                "\r\n10120001 " + convertToHex((int)itemID.Value * 4);

            code = code +
                "\r\n30000000 " + CreativeTabAddress;
            #endregion

            #region Item
            code = code +
                "\r\n10000000 50000000" +
                "\r\n31000000 " + convertToHex((int)(itemPlace.Value - 1) * 4) +
                "\r\n30100000 00000000" +
                "\r\n10000000 50000000" +
                "\r\n11120001 00000014" +
                "\r\n0012000C " + convertToHex((int)itemNumber.Value) +
                "\r\n00120020 " + convertToHex((int)itemDamage.Value) +
                "\r\n00120018 " + convertToHex((int)tagAddress) +
                "\r\nD0000000 DEADCAFE" +

                "\r\n0100001C " + convertToHex((int)tagAddress) +
                "\r\n" + CoupoundTag + " 00A8A598" +
                "\r\n00000011 00000001" +
                "\r\n3F800000 00000011" +
                "\r\n" + convertToHex((int)tagAddress + 0x30) + " 000000FF" +
                "\r\n30000000 " + convertToHex((int)tagAddress + 0x18) +
                "\r\n10000000 50000000" +
                "\r\n00120044 " + convertToHex((int)tagAddress + 0xD4) +
                "\r\n01000044 " + convertToHex((int)tagAddress + 0xA0);
            #endregion

            #region Unbreakable
            if (unbreakable.Checked)
            {
                code = code +
                    "\r\n" + ByteTag + " 01000000" +
                    "\r\n00000000 00000000";
            }
            else
            {
                code = code +
                    "\r\n" + ByteTag + " 00000000" +
                    "\r\n00000000 00000000";
            }
            #endregion

            #region Unbreakable and color function
            code = code +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 " + convertToHex((int)tagAddress + 0xE0) +
                "\r\n00000000 00000017" +
                "\r\n" + convertToHex((int)tagAddress + 0xA0) + " " + convertToHex((int)tagAddress + 0x134) +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n01000018 " + convertToHex((int)tagAddress + 0xE0) +
                "\r\n0055006E 00620072" +//Un br
                "\r\n00650061 006B0061" +//ea ka
                "\r\n0062006C 00650000" +//bl e
                "\r\n00000000 000000FF" +

                "\r\n01000030 " + convertToHex((int)tagAddress + 0x110) +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x140) +
                "\r\n00000000 00000017" +
                "\r\n" + convertToHex((int)tagAddress + 0x1000) + " " + convertToHex((int)tagAddress + 0x184) +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n01000014 " + convertToHex((int)tagAddress + 0x140) +
                "\r\n00640069 00730070" +//di sp
                "\r\n006C0061 00790000" +//la y
                "\r\n00000000 000000FF" +

                "\r\n0100001C " + convertToHex((int)tagAddress + 0x1000) +
                "\r\n" + CoupoundTag + " 00A8A598" +
                "\r\n00000011 00000001" +
                "\r\n3F800000 00000011" +
                "\r\n" + convertToHex((int)tagAddress + 0x1030) + " 000000FF" +
                "\r\n30000000 " + convertToHex((int)tagAddress + 0x1018) +
                "\r\n10000000 50000000" +
                "\r\n00120044 " + convertToHex((int)tagAddress + 0x10D4) +
                "\r\n01000044 " + convertToHex((int)tagAddress + 0x10A0) +
                "\r\n" + IntTag + " 00" + htmlValue.Text.Substring(1, 6) +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x10E0) +
                "\r\n00000000 00000017" +
                "\r\n" + convertToHex((int)tagAddress + 0x10A0) + " 00000000" +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF";
            #endregion

            #region Color
            #region Armor
            if (itemID.Value == 298)
            {
                code = code +
                    "\r\n0100000C " + convertToHex((int)tagAddress + 0x10E0) +
                    "\r\n0063006F 006C006F" +//co lo
                    "\r\n00720000 000000FF";//r
            }
            if (itemID.Value == 299)
            {
                code = code +
                    "\r\n0100000C " + convertToHex((int)tagAddress + 0x10E0) +
                    "\r\n0063006F 006C006F" +//co lo
                    "\r\n00720000 000000FF";//r
            }
            if (itemID.Value == 300)
            {
                code = code +
                    "\r\n0100000C " + convertToHex((int)tagAddress + 0x10E0) +
                    "\r\n0063006F 006C006F" +//co lo
                    "\r\n00720000 000000FF";//r
            }
            if (itemID.Value == 301)
            {
                code = code +
                    "\r\n0100000C " + convertToHex((int)tagAddress + 0x10E0) +
                    "\r\n0063006F 006C006F" +//co lo
                    "\r\n00720000 000000FF";//r
            }
            #endregion

            #region Map
            if (itemID.Value == 358)//map
            {
                code = code +
                    "\r\n01000014 " + convertToHex((int)tagAddress + 0x10E0) +
                    "\r\n004D0061 00700043" +//Ma pC
                    "\r\n006F006C 006F0072" +//ol or
                    "\r\n00000000 000000FF";
            }
            #endregion

            if (colorBox.Enabled == false)
            {
                code = code +
                    "\r\n01000016 " + convertToHex((int)tagAddress + 0x10E0) +
                    "\r\n00000000 00000000" +
                    "\r\n00000000 00000000" +
                    "\r\n00000000 000000FF";
            }
            #endregion

            #region Enchants, attributes and potions function
            code = code +
                "\r\n01000030 " + convertToHex((int)tagAddress + 0x160) +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x190) +
                "\r\n00000000 00000017" +
                "\r\n" + convertToHex((int)tagAddress + 0x2000) + " " + convertToHex((int)tagAddress + 0x1D4) +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n01000014 " + convertToHex((int)tagAddress + 0x190) +
                "\r\n0065006E 00630068" +//en ch
                "\r\n00000000 00000000" +
                "\r\n00000000 000000FF" +

                "\r\n01000030 " + convertToHex((int)tagAddress + 0x1B0) +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x1E0) +
                "\r\n00000000 00000017" +
                "\r\n" + convertToHex((int)tagAddress + 0x5000) + " " + convertToHex((int)tagAddress + 0x254) +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n01000026 " + convertToHex((int)tagAddress + 0x1E0) +
                "\r\n00410074 00740072" +//At tr
                "\r\n00690062 00750074" +//ib ut
                "\r\n0065004D 006F0064" +//eM od
                "\r\n00690066 00690065" +//if ie
                "\r\n00720073 000000FF" +//rs

                "\r\n01000030 " + convertToHex((int)tagAddress + 0x230) +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x260) +
                "\r\n00000000 00000017" +
                "\r\n" + convertToHex((int)tagAddress + 0xA000) + " " + convertToHex((int)tagAddress + 0x2D4) +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n0100002C " + convertToHex((int)tagAddress + 0x260) +
                "\r\n00430075 00730074" +//Cu st
                "\r\n006F006D 0050006F" +//om Po
                "\r\n00740069 006F006E" +//ti on
                "\r\n00450066 00660065" +//Ef fe
                "\r\n00630074 00730000" +//ec ts
                "\r\n00000000 000000FF" +

                "\r\n01000030 " + convertToHex((int)tagAddress + 0x2B0) +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +

                "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x2E0) +
                "\r\n00000000 00000017" +

                "\r\n" + convertToHex((int)tagAddress + 0xD000) + " 00000000" +
                "\r\n00000000 0000003B" +

                "\r\n00000000 000000FF" +

                "\r\n01000020 " + convertToHex((int)tagAddress + 0x2E0) +

                "\r\n0042006C 006F0063" +//Bl oc
                "\r\n006B0045 006E0074" +//kE nt

                "\r\n00690074 00790054" +//it yT
                "\r\n00610067 00000000" +//ag

                "\r\n00000000 000000FF";
            #endregion

            #region Enchantment
            if (enchantment.Checked)
            {
                code = code +
                "\r\n0100001C " + convertToHex((int)tagAddress + 0x2000) +
                "\r\n" + ListTag + " 00000000" +
                "\r\n" + convertToHex((int)tagAddress + 0x2030) + " " + convertToHex((int)tagAddress + 0x2030 + enchantmentList.CheckedItems.Count * 4) +
                "\r\n" + convertToHex((int)tagAddress + 0x2030 + enchantmentList.CheckedItems.Count * 4) + " 0A000000" +
                "\r\n00000000 000000FF";

                int enchantmentChecked = 0;
                int enchantmentAddress = 0x0;
                string enchantmentAddressList = "";
                string enchantmentString = "";

                int i = 0;
                while (i < enchantmentList.Items.Count)
                {
                    if (enchantmentList.Items[i].Checked)
                    {
                        if (enchantmentChecked % 2 == 0)
                        {
                            enchantmentAddressList = enchantmentAddressList + convertToHex((int)tagAddress + 0x2130 + enchantmentChecked * 0x140) + " ";
                        }
                        else
                        {
                            enchantmentAddressList = enchantmentAddressList + convertToHex((int)tagAddress + 0x2130 + enchantmentChecked * 0x140) + "\r\n";
                        }

                        #region Enchantment string
                        #region Armor
                        if (enchantmentList.Items[i].SubItems[0].Text == "Protection")
                        {
                            enchantmentString = "00000000";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Fire protection")
                        {
                            enchantmentString = "00000001";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Feather falling")
                        {
                            enchantmentString = "00000002";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Blast protection")
                        {
                            enchantmentString = "00000003";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Projectile protection")
                        {
                            enchantmentString = "00000004";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Respiration")
                        {
                            enchantmentString = "00000005";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Aqua affinity")
                        {
                            enchantmentString = "00000006";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Thorns")
                        {
                            enchantmentString = "00000007";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Depth strider")
                        {
                            enchantmentString = "00000008";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Frost walker")
                        {
                            enchantmentString = "00000009";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Curse of binding")
                        {
                            enchantmentString = "0000000A";
                        }
                        #endregion

                        #region Sword
                        if (enchantmentList.Items[i].SubItems[0].Text == "Sharpness")
                        {
                            enchantmentString = "00000010";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Smite")
                        {
                            enchantmentString = "00000011";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Bane of arthropods")
                        {
                            enchantmentString = "00000012";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Knockback")
                        {
                            enchantmentString = "00000013";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Fire aspect")
                        {
                            enchantmentString = "00000014";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Looting")
                        {
                            enchantmentString = "00000015";
                        }
                        #endregion

                        #region Tools
                        if (enchantmentList.Items[i].SubItems[0].Text == "Efficiency")
                        {
                            enchantmentString = "00000020";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Silk touch")
                        {
                            enchantmentString = "00000021";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Unbreaking")
                        {
                            enchantmentString = "00000022";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Fortune")
                        {
                            enchantmentString = "00000023";
                        }
                        #endregion

                        #region Bow
                        if (enchantmentList.Items[i].SubItems[0].Text == "Power")
                        {
                            enchantmentString = "00000030";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Punch")
                        {
                            enchantmentString = "00000031";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Flame")
                        {
                            enchantmentString = "00000032";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Infinity")
                        {
                            enchantmentString = "00000033";
                        }
                        #endregion

                        #region Rod
                        if (enchantmentList.Items[i].SubItems[0].Text == "Luck of the sea")
                        {
                            enchantmentString = "0000003D";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Lure")
                        {
                            enchantmentString = "0000003E";
                        }
                        #endregion

                        #region Trident
                        if (enchantmentList.Items[i].SubItems[0].Text == "Loayalty")
                        {
                            enchantmentString = "00000041";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Impaling")
                        {
                            enchantmentString = "00000042";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Riptide")
                        {
                            enchantmentString = "00000043";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Channeling")
                        {
                            enchantmentString = "00000044";
                        }
                        #endregion

                        #region Other
                        if (enchantmentList.Items[i].SubItems[0].Text == "Mending")
                        {
                            enchantmentString = "00000046";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Curse of vanishing")
                        {
                            enchantmentString = "00000047";
                        }
                        #endregion
                        #endregion

                        #region Level string
                        string enchantmentLevelString = convertToHex(int.Parse(enchantmentList.Items[i].SubItems[1].Text));
                        #endregion

                        code = code +
                            "\r\n0100001C " + convertToHex((int)tagAddress + 0x2130 + enchantmentAddress) +
                            "\r\n" + CoupoundTag + " 00A8A598" +
                            "\r\n00000011 00000001" +
                            "\r\n3F800000 00000011" +
                            "\r\n" + convertToHex((int)tagAddress + 0x2160 + enchantmentAddress) + " 000000FF" +
                            "\r\n30000000 " + convertToHex((int)tagAddress + 0x2148 + enchantmentAddress) +
                            "\r\n10000000 50000000" +
                            "\r\n00120044 " + convertToHex((int)tagAddress + 0x2204 + enchantmentAddress) +
                            "\r\n01000044 " + convertToHex((int)tagAddress + 0x21D0 + enchantmentAddress) +
                            "\r\n" + ShortTag + " " + enchantmentLevelString.Substring(4, 4) + "0000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x2210 + enchantmentAddress) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex((int)tagAddress + 0x21D0 + enchantmentAddress) + " " + convertToHex((int)tagAddress + 0x2254 + enchantmentAddress) +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000C " + convertToHex((int)tagAddress + 0x2210 + enchantmentAddress) +
                            "\r\n006C0076 006C0000" +//lv l
                            "\r\n00000000 000000FF" +
                            "\r\n01000044 " + convertToHex((int)tagAddress + 0x2220 + enchantmentAddress) +
                            "\r\n" + ShortTag + " " + enchantmentString.Substring(4, 4) + "0000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x2260 + enchantmentAddress) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex((int)tagAddress + 0x2220 + enchantmentAddress) + " 00000000" +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000C " + convertToHex((int)tagAddress + 0x2260 + enchantmentAddress) +
                            "\r\n00690064 00000000" +//id
                            "\r\n00000000 000000FF";

                        enchantmentAddress = enchantmentAddress + 0x140;
                        enchantmentChecked++;
                    }
                    i++;
                }

                if (enchantmentChecked % 2 == 1)
                {
                    code = code +
                        "\r\n0100" + convertToHex(enchantmentList.CheckedItems.Count * 4 + 8).Substring(4, 4) + " " + convertToHex((int)tagAddress + 0x2030) +
                        "\r\n" + enchantmentAddressList + "00000000" +
                        "\r\n00000000 000000FF";
                }
                else
                {
                    code = code +
                        "\r\n0100" + convertToHex(enchantmentList.CheckedItems.Count * 4 + 4).Substring(4, 4) + " " + convertToHex((int)tagAddress + 0x2030) +
                        "\r\n" + enchantmentAddressList +
                        "\r\n00000000 000000FF";
                }
            }
            else
            {
                code = code +
                    "\r\n0100000C " + convertToHex((int)tagAddress + 0x2000) +
                    "\r\n" + IntTag + " 00000000" +
                    "\r\n00000000 000000FF";
            }
            #endregion

            #region Attribute
            if (attribute.Checked)
            {
                code = code +
                    "\r\n0100001C " + convertToHex((int)tagAddress + 0x5000) +
                    "\r\n" + ListTag + " 00000000" +
                    "\r\n" + convertToHex((int)tagAddress + 0x5030) + " " + convertToHex((int)tagAddress + 0x5030 + attributeList.CheckedItems.Count * 4) +
                    "\r\n" + convertToHex((int)tagAddress + 0x5030 + attributeList.CheckedItems.Count * 4) + " 0A000000" +
                    "\r\n00000000 000000FF";

                int attributeChecked = 0;
                int attributeAddress = 0x0;
                string attributeAddressList = "";
                string attributeString = "";

                int i = 0;
                while (i < attributeList.Items.Count)
                {
                    if (attributeList.Items[i].Checked)
                    {
                        if (attributeChecked % 2 == 0)
                        {
                            attributeAddressList = attributeAddressList + convertToHex((int)tagAddress + 0x5130 + attributeChecked * 0x150) + " ";
                        }
                        else
                        {
                            attributeAddressList = attributeAddressList + convertToHex((int)tagAddress + 0x5130 + attributeChecked * 0x150) + "\r\n";
                        }

                        #region Attribute string
                        if (attributeList.Items[i].SubItems[0].Text == "Max health")
                        {
                            attributeString = "00000000";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Follow range")
                        {
                            attributeString = "00000001";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Knockback resistance")
                        {
                            attributeString = "00000002";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Mouvement speed")
                        {
                            attributeString = "00000003";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Attack damage")
                        {
                            attributeString = "00000004";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Horse jump strength")
                        {
                            attributeString = "00000005";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Zombie spawn reinforcements")
                        {
                            attributeString = "00000006";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Attack speed")
                        {
                            attributeString = "00000007";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Armor")
                        {
                            attributeString = "00000008";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Armor toughness")
                        {
                            attributeString = "00000009";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Luck")
                        {
                            attributeString = "0000000A";
                        }
                        #endregion

                        #region Attribute level string
                        string[] attributeLevelString = BitConverter.GetBytes(double.Parse(attributeList.Items[i].SubItems[1].Text)).Select(delegate (byte a)
                        {
                            byte b = a;
                            return b.ToString("X2");
                        }).Reverse<string>().ToArray<string>();
                        #endregion

                        code = code +
                            "\r\n0100001C " + convertToHex((int)tagAddress + 0x5130 + attributeAddress) +
                            "\r\n" + CoupoundTag + " 00A8A598" +
                            "\r\n00000011 00000001" +
                            "\r\n3F800000 00000011" +
                            "\r\n" + convertToHex((int)tagAddress + 0x5160 + attributeAddress) + " 000000FF" +
                            "\r\n30000000 " + convertToHex((int)tagAddress + 0x5148 + attributeAddress) +
                            "\r\n10000000 50000000" +
                            "\r\n00120044 " + convertToHex((int)tagAddress + 0x5204 + attributeAddress) +
                            "\r\n01000044 " + convertToHex((int)tagAddress + 0x51D0 + attributeAddress) +
                            "\r\n" + IntTag + " " + attributeString +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x5210 + attributeAddress) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex((int)tagAddress + 0x51D0 + attributeAddress) + " " + convertToHex((int)tagAddress + 0x5254 + attributeAddress) +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000C " + convertToHex((int)tagAddress + 0x5210 + attributeAddress) +
                            "\r\n00490044 00000000" +//ID
                            "\r\n00000000 000000FF" +
                            "\r\n01000044 " + convertToHex((int)tagAddress + 0x5220 + attributeAddress) +
                            "\r\n" + DoubleTag + " 00000000" +
                            "\r\n" + string.Join("", attributeLevelString).Substring(0, 8) + " 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex((int)tagAddress + 0x5260 + attributeAddress) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex((int)tagAddress + 0x5220 + attributeAddress) + " 00000000" +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000E " + convertToHex((int)tagAddress + 0x5260 + attributeAddress) +
                            "\r\n0041006D 006F0075" +//Am ou
                            "\r\n006E0074 000000FF" ;//nt

                        attributeAddress = attributeAddress + 0x150;
                        attributeChecked++;
                    }
                    i++;
                }

                if (attributeChecked % 2 == 1)
                {
                    code = code +
                        "\r\n0100" + convertToHex(attributeList.CheckedItems.Count * 4 + 8).Substring(4, 4) + " " + convertToHex((int)tagAddress + 0x5030) +
                        "\r\n" + attributeAddressList + "00000000" +
                        "\r\n00000000 000000FF";
                }
                else
                {
                    code = code +
                        "\r\n0100" + convertToHex(attributeList.CheckedItems.Count * 4 + 4).Substring(4, 4) + " " + convertToHex((int)tagAddress + 0x5030) +
                        "\r\n" + attributeAddressList +
                        "\r\n00000000 000000FF";
                }
            }
            else
            {
                code = code +
                    "\r\n0100000C " + convertToHex((int)tagAddress + 0x5000) +
                    "\r\n" + IntTag + " 00000000" +
                    "\r\n00000000 000000FF";
            }
            #endregion

            #region Potion
            if (potionBox.Enabled == true)
            {
                code = code +
                    "\r\n0100001C " + convertToHex((int)tagAddress + 0xA000) +
                    "\r\n" + ListTag + " 00000000" +
                    "\r\n" + convertToHex((int)tagAddress + 0xA030) + " " + convertToHex((int)tagAddress + 0xA030 + potionList.CheckedItems.Count * 4) +
                    "\r\n" + convertToHex((int)tagAddress + 0xA030 + potionList.CheckedItems.Count * 4) + " 0A000000" +
                    "\r\n00000000 000000FF";

                int potionEffectChecked = 0;
                int potionEffectAddress = 0x0;
                string potionEffectAddressList = "";
                string potionEffectString = "";

                int i = 0;
                while (i < potionList.Items.Count)
                {
                    if (potionList.Items[i].Checked)
                    {
                        if (potionEffectChecked % 2 == 0)
                        {
                            potionEffectAddressList = potionEffectAddressList + convertToHex((int)tagAddress + 0xA130 + potionEffectChecked * 0x1D0) + " ";
                        }
                        else
                        {
                            potionEffectAddressList = potionEffectAddressList + convertToHex((int)tagAddress + 0xA130 + potionEffectChecked * 0x1D0) + "\r\n";
                        }

                        #region Potion effect string
                        if (potionList.Items[i].SubItems[0].Text == "Speed")
                        {
                            potionEffectString = "00000001";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Slowness")
                        {
                            potionEffectString = "00000002";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Haste")
                        {
                            potionEffectString = "00000003";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Mining fatigue")
                        {
                            potionEffectString = "00000004";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Strength")
                        {
                            potionEffectString = "00000005";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Instant health")
                        {
                            potionEffectString = "00000006";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Instant damage")
                        {
                            potionEffectString = "00000007";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Jump boost")
                        {
                            potionEffectString = "00000008";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Nausea")
                        {
                            potionEffectString = "00000009";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Regeneration")
                        {
                            potionEffectString = "0000000A";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Resistance")
                        {
                            potionEffectString = "0000000B";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Fire resistance")
                        {
                            potionEffectString = "0000000C";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Water breathing")
                        {
                            potionEffectString = "0000000D";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Invisibility")
                        {
                            potionEffectString = "0000000E";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Blindness")
                        {
                            potionEffectString = "0000000F";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Night vision")
                        {
                            potionEffectString = "00000010";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Hunger")
                        {
                            potionEffectString = "00000011";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Weakness")
                        {
                            potionEffectString = "00000012";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Poison")
                        {
                            potionEffectString = "00000013";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Wither")
                        {
                            potionEffectString = "00000014";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Health boost")
                        {
                            potionEffectString = "00000015";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Absorption")
                        {
                            potionEffectString = "00000016";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Saturation")
                        {
                            potionEffectString = "00000017";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Glowing")
                        {
                            potionEffectString = "00000018";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Levitation")
                        {
                            potionEffectString = "00000019";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Luck")
                        {
                            potionEffectString = "0000001A";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Bad luck")
                        {
                            potionEffectString = "0000001B";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Conduit power")
                        {
                            potionEffectString = "0000001C";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Slow falling")
                        {
                            potionEffectString = "0000001D";
                        }
                        /*if (potionList.Items[i].SubItems[0].Text == "Dolphin's grace")
                        {
                            potionEffectString = "0000001E";
                        }*/
                        #endregion

                        #region Potion level string
                        string potionLevelString = convertToHex(int.Parse(potionList.Items[i].SubItems[1].Text) - 1);
                        #endregion

                        #region Potion duration string
                        string potionDurationString = convertToHex(int.Parse(potionList.Items[i].SubItems[2].Text));
                        #endregion

                        code = code +
                            "\r\n0100001C " + convertToHex((int)tagAddress + 0xA130 + potionEffectAddress) +
                            "\r\n" + CoupoundTag + " 00A8A598" +
                            "\r\n00000011 00000001" +
                            "\r\n3F800000 00000011" +
                            "\r\n" + convertToHex((int)tagAddress + 0xA160 + potionEffectAddress) + " 000000FF" +
                            "\r\n30000000 " + convertToHex((int)tagAddress + 0xA148 + potionEffectAddress) +
                            "\r\n10000000 50000000" +
                            "\r\n00120044 " + convertToHex((int)tagAddress + 0xA204 + potionEffectAddress) +
                            "\r\n01000044 " + convertToHex((int)tagAddress + 0xA1D0 + potionEffectAddress) +
                            "\r\n" + IntTag + " " + potionEffectString +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex((int)tagAddress + 0xA210 + potionEffectAddress) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex((int)tagAddress + 0xA1D0 + potionEffectAddress) + " " + convertToHex((int)tagAddress + 0xA254 + potionEffectAddress) +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000C " + convertToHex((int)tagAddress + 0xA210 + potionEffectAddress) +
                            "\r\n00490064 00000000" +//ID
                            "\r\n00000000 000000FF" +
                            "\r\n01000044 " + convertToHex((int)tagAddress + 0xA220 + potionEffectAddress) +
                            "\r\n" + IntTag + " " + potionDurationString +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex((int)tagAddress + 0xA260 + potionEffectAddress) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex((int)tagAddress + 0xA220 + potionEffectAddress) + " " + convertToHex((int)tagAddress + 0xA2C4 + potionEffectAddress) +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n01000014 " + convertToHex((int)tagAddress + 0xA260 + potionEffectAddress) +
                            "\r\n00440075 00720061" +//Du ra
                            "\r\n00740069 006F006E" +//ti on
                            "\r\n00000000 000000FF" +
                            "\r\n01000044 " + convertToHex((int)tagAddress + 0xA290 + potionEffectAddress) +
                            "\r\n" + IntTag + " " + potionLevelString +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex((int)tagAddress + 0xA2D0 + potionEffectAddress) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex((int)tagAddress + 0xA290 + potionEffectAddress) + " 00000000" +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n01000014 " + convertToHex((int)tagAddress + 0xA2D0 + potionEffectAddress) +
                            "\r\n0041006D 0070006C" +//Am pl
                            "\r\n00690066 00690065" +//if ie
                            "\r\n00720000 000000FF";//r

                        potionEffectAddress += 0x1D0;
                        potionEffectChecked++;
                    }
                    i++;
                }

                if (potionEffectChecked % 2 == 1)
                {
                    code = code +
                        "\r\n0100" + convertToHex(potionList.CheckedItems.Count * 4 + 8).Substring(4, 4) + " " + convertToHex((int)tagAddress + 0xA030) +
                        "\r\n" + potionEffectAddressList + "00000000" +
                        "\r\n00000000 000000FF";
                }
                else
                {
                    code = code +
                        "\r\n0100" + convertToHex(potionList.CheckedItems.Count * 4 + 4).Substring(4, 4) + " " + convertToHex((int)tagAddress + 0xA030) +
                        "\r\n" + potionEffectAddressList +
                        "\r\n00000000 000000FF";
                }
            }
            else
            {
                code = code +
                    "\r\n0100000C " + convertToHex((int)tagAddress + 0xA000) +
                    "\r\n" + IntTag + " 00000000" +
                    "\r\n00000000 000000FF";
            }
            #endregion

            #region Test
            if (signBox.Enabled == true)
            {
                #region CoupondTag
                code = code +
                "\r\n0100001C " + convertToHex((int)tagAddress + 0xD000) +
                    "\r\n" + CoupoundTag + " 00A8A598" +
                    "\r\n00000011 00000001" +

                    "\r\n3F800000 00000011" +
                "\r\n" + convertToHex((int)tagAddress + 0xD030) + " 000000FF" +

                "\r\n30000000 " + convertToHex((int)tagAddress + 0xD018) + //0xD030 + 0x44 = 0x74
                "\r\n10000000 50000000" +
                "\r\n00120044 " + convertToHex((int)tagAddress + 0xD0D4) ; //Next
                #endregion

                #region Elements in the CoupondTag
                code = code +
                //Int tag : CreatedByHost
                "\r\n01000060 " + convertToHex((int)tagAddress + 0xD0A0) +
                    "\r\n" + IntTag; //Tag address | Value
                    if (createdByHost.Checked)
                    {
                        code = code + " 00000001"; 
                    }
                    else
                    {
                        code = code + " 00000000";
                    }
                    code = code +
                    "\r\n00000000 00000000" +
                    
                    "\r\n11B0D430 0000AFB8" +
                    "\r\n00000000 00000000" +
                    
                    "\r\n11B0D430 " + convertToHex((int)tagAddress + 0xD0E0) + //Int tag name address
                    "\r\n00000000 00000017" +
                    
                    "\r\n" + convertToHex((int)tagAddress + 0xD0A0) + " " + convertToHex((int)tagAddress + 0xD134) + //Selected tag address | Next tag address
                    "\r\n00000000 0000003B" +

                    "\r\n00430072 00650061" + //Cr ea
                    "\r\n00740065 00640042" + //te dB

                    "\r\n00790048 006F0073" + //yH os
                    "\r\n00740000 00000000" + //t
                "\r\n00000000 000000FF" +


                //Byte tag : CreatedByRestrictedPlayer
                "\r\n01000080 " + convertToHex((int)tagAddress + 0xD100) +
                    "\r\n" + ByteTag; //Tag address | Value
                    if (createdByRestrictedPlayer.Checked)
                    {
                        code = code + " 01000000";
                    }
                    else
                    {
                        code = code + " 00000000";
                    }
                    code = code +
                    "\r\n00000000 00000000" +

                    "\r\n11B0D430 0000AFB8" +
                    "\r\n00000000 00000000" +

                    "\r\n11B0D430 " + convertToHex((int)tagAddress + 0xD140) + //Int tag name address
                    "\r\n00000000 00000017" +

                    "\r\n" + convertToHex((int)tagAddress + 0xD100) + " " + convertToHex((int)tagAddress + 0xD1B4) + //Selected tag address | Next tag address
                    "\r\n00000000 0000003B" +

                    "\r\n00430072 00650061" + //Cr ea
                    "\r\n00740065 00640042" + //te dB

                    "\r\n00790052 00650073" + //yR es
                    "\r\n00740072 00690063" + //tr ic

                    "\r\n00740065 00640050" + //te dP
                    "\r\n006C0061 00790065 " + //la ye

                    "\r\n00720000 00000000" + //r
                    "\r\n00000000 00000000" + //r
                "\r\n00000000 000000FF" +


                //Byte tag : Censored
                "\r\n01000060 " + convertToHex((int)tagAddress + 0xD180) +
                    "\r\n" + ByteTag; //Tag address | Value
                    if (censored.Checked)
                    {
                        code = code + " 01000000";
                    }
                    else
                    {
                        code = code + " 00000000";
                    }
                    code = code +
                    "\r\n00000000 00000000" +

                    "\r\n11B0D430 0000AFB8" +
                    "\r\n00000000 00000000" +

                    "\r\n11B0D430 " + convertToHex((int)tagAddress + 0xD1C0) + //Int tag name address
                    "\r\n00000000 00000017" +

                    "\r\n" + convertToHex((int)tagAddress + 0xD180) + " " + convertToHex((int)tagAddress + 0xD214) + //Selected tag address | Next tag address
                    "\r\n00000000 0000003B" +

                    "\r\n00430065 006E0073" + //Ce ns
                    "\r\n006F0072 00650064" + //or ed

                    "\r\n00000000 00000000" +
                    "\r\n00000000 00000000" +
                "\r\n00000000 000000FF" +


                //Byte tag : Verified
                "\r\n01000060 " + convertToHex((int)tagAddress + 0xD1E0) +
                    "\r\n" + ByteTag; //Tag address | Value
                    if (verified.Checked)
                    {
                        code = code + " 01000000";
                    }
                    else
                    {
                        code = code + " 00000000";
                    }
                    code = code +
                    "\r\n00000000 00000000" +

                    "\r\n11B0D430 0000AFB8" +
                    "\r\n00000000 00000000" +

                    "\r\n11B0D430 " + convertToHex((int)tagAddress + 0xD220) + //Int tag name address
                    "\r\n00000000 00000017" +

                    "\r\n" + convertToHex((int)tagAddress + 0xD1E0) + " " + convertToHex((int)tagAddress + 0xD254) + //Selected tag address | Next tag address
                    "\r\n00000000 0000003B" +

                    "\r\n00560065 00720069" + //Ve ri
                    "\r\n00660069 00650064" + //fi ed 

                    "\r\n00000000 00000000" +
                    "\r\n00000000 00000000" +
                "\r\n00000000 000000FF" +


                //String tag : Text1
                "\r\n010000" + Convert.ToString(0x50 + (signText1.TextLength * 2), 16) + " " + convertToHex((int)tagAddress + 0xD240) +
                    "\r\n00000000 " + convertToHex((int)tagAddress + 0xD260) + //String tag name address
                    "\r\n00000000 00000008" +

                    "\r\n" + convertToHex((int)tagAddress + 0xD270) + " " + convertToHex((int)tagAddress + 0xD2C4) + //Selected tag address | Next tag address
                    "\r\n00000000 00000000" +

                    "\r\n00540065 00780074" + //Te xt
                    "\r\n00310000 00000000" + //1

                    "\r\n" + StringTag + " 10A8A5A0" + //Tag address
                    "\r\n0000006D 004E0061" +

                    "\r\n006D0065 00000000" +
                    "\r\n" + convertToHex((int)tagAddress + 0xD290) + " " + convertToHex(0x0 + signText1.TextLength) + //Value address | String value length

                    "\r\n" + convertUTF16toHexString(signText1.Text, true, true) +
                "00000000 000000FF" +


                //String tag : Text2
                "\r\n010000" + Convert.ToString(0x50 + (signText2.TextLength * 2), 16) + " " + convertToHex((int)tagAddress + 0xD2B0) +
                    "\r\n00000000 " + convertToHex((int)tagAddress + 0xD2D0) + //String tag name address
                    "\r\n00000000 00000008" +

                    "\r\n" + convertToHex((int)tagAddress + 0xD2E0) + " " + convertToHex((int)tagAddress + 0xD334) + //Selected tag address | Next tag address
                    "\r\n00000000 00000000" +

                    "\r\n00540065 00780074" + //Te xt
                    "\r\n00320000 00000000" + //2

                    "\r\n" + StringTag + " 10A8A5A0" + //Tag address
                    "\r\n0000006D 004E0061" +

                    "\r\n006D0065 00000000" +
                    "\r\n" + convertToHex((int)tagAddress + 0xD300) + " " + convertToHex(0x0 + signText2.TextLength) + //Value address | String value length

                    "\r\n" + convertUTF16toHexString(signText2.Text, true, true) +
                "00000000 000000FF" +


                //String tag : Text3
                "\r\n010000" + Convert.ToString(0x50 + (signText3.TextLength * 2), 16) + " " + convertToHex((int)tagAddress + 0xD320) +
                    "\r\n00000000 " + convertToHex((int)tagAddress + 0xD340) + //String tag name address
                    "\r\n00000000 00000008" +

                    "\r\n" + convertToHex((int)tagAddress + 0xD350) + " " + convertToHex((int)tagAddress + 0xD3A4) + //Selected tag address | Next tag address
                    "\r\n00000000 00000000" +

                    "\r\n00540065 00780074" + //Te xt
                    "\r\n00330000 00000000" + //3

                    "\r\n" + StringTag + " 10A8A5A0" + //Tag address
                    "\r\n0000006D 004E0061" +

                    "\r\n006D0065 00000000" +
                    "\r\n" + convertToHex((int)tagAddress + 0xD370) + " " + convertToHex(0x0 + signText3.TextLength) + //Value address | String value length

                    "\r\n" + convertUTF16toHexString(signText3.Text, true, true) +
                "00000000 000000FF" +


                //String tag : Text4
                "\r\n010000" + Convert.ToString(0x50 + (signText4.TextLength * 2), 16) + " " + convertToHex((int)tagAddress + 0xD390) +
                    "\r\n00000000 " + convertToHex((int)tagAddress + 0xD3B0) + //String tag name address
                    "\r\n00000000 00000008" +

                    "\r\n" + convertToHex((int)tagAddress + 0xD3C0) + " " + convertToHex((int)tagAddress + 0xD414) + //Selected tag address | Next tag address
                    "\r\n00000000 00000000" +

                    "\r\n00540065 00780074" + //Te xt
                    "\r\n00340000 00000000" + //4

                    "\r\n" + StringTag + " 10A8A5A0" + //Tag address
                    "\r\n0000006D 004E0061" +

                    "\r\n006D0065 00000000" +
                    "\r\n" + convertToHex((int)tagAddress + 0xD3E0) + " " + convertToHex(0x0 + signText4.TextLength) + //Value address | String value length

                    "\r\n" + convertUTF16toHexString(signText4.Text, true, true) +
                "00000000 000000FF" +


                //String tag : uuid
                "\r\n01000080 " + convertToHex((int)tagAddress + 0xD400) +
                    "\r\n00000000 " + convertToHex((int)tagAddress + 0xD420) + //String tag name address
                    "\r\n00000000 00000008" +

                    "\r\n" + convertToHex((int)tagAddress + 0xD430) + " 00000000" + //Selected tag address | Next tag address
                    "\r\n00000000 00000000" +

                    "\r\n00750075 00690064" + //uu id
                    "\r\n00000000 00000000" + 

                    "\r\n" + StringTag + " 10A8A5A0" + //Tag address
                    "\r\n0000006D 004E0061" +

                    "\r\n006D0065 00000000" +
                    "\r\n" + convertToHex((int)tagAddress + 0xD450) + " 00000012" + //Value address | String value length

                    "\r\n004E0042 00540020" + //NB T
                    "\r\n00540061 00670020" + //Ta g

                    "\r\n0043006F 00640065" + //Co de
                    "\r\n0020004D 0061006B" + // M ak

                    "\r\n00650072 00000000" + //er
                    "\r\n00000000 00000000" +
                "\r\n00000000 000000FF";
                #endregion
            }
            else
            {
                code = code +
                    "\r\n0100000C " + convertToHex((int)tagAddress + 0xD000) +
                    "\r\n" + IntTag + " 00000000" +
                    "\r\n00000000 000000FF";
            }
            #endregion

            code = code + "\r\nD0000000 DEADCAFE";            
        }

        #region Code buttons
        private void codeText_TextChanged(object sender, EventArgs e)
        {
            if (codeText.Text != "")
            {
                makeAndAdd.Enabled = true;
            }
        }

        private void make_Click(object sender, EventArgs e)
        {
            tagAddress = (uint)Convert.ToInt32(tagAddressText.Text, 16);
            makeCode();
            codeText.Text = code;
        }

        private void makeAndAdd_Click(object sender, EventArgs e)
        {
            tagAddress = (uint)Convert.ToInt32(tagAddressText.Text, 16) + 0x00010000;
            makeCode();
            codeText.Text = codeText.Text + "\r\n" + code;
        }

        private void copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(codeText.Text);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            codeText.ResetText();
        }
        #endregion

        #region Connection
        private void ipText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (BeforeConnect.ValidateIPv4(ipText.Text) == true)
                {
                    connect.Enabled = true;
                }
                else
                {
                    connect.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                MamiesModGecko = new TCPGecko(ipText.Text);
                MamiesModGecko.simplyConnect();
                GetNintendoNetwork();
                MessageBox.Show("Welcome " + nintendoNetwork.Replace("\0", "") + ",\n you are now connected on NBT Tag Code Maker !", "NBT Tag Code Maker");

                ipText.Enabled = false;
                connect.Enabled = false;
                disconnect.Enabled = true;
                activateTheCode.Enabled = true;

                presence.details = "Make a NBT tag code - Connected on " + nintendoNetwork;
                DiscordRpc.UpdatePresence(ref presence);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "NBT Tag Code Maker");
            }
            catch (SocketException)
            {
                MessageBox.Show("Error: your ip is not the right one or you are not connected to the internet !", "NBT Tag Code Maker");
            }
            catch
            {
                MessageBox.Show("An unknown error has occurred !", "NBT Tag Code Maker");
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            MamiesModGecko.Disconnect();

            ipText.Enabled = true;
            connect.Enabled = true;
            disconnect.Enabled = false;
            activateTheCode.Enabled = false;

            presence.state = "Make a NBT tag code - Disconnected";
            DiscordRpc.UpdatePresence(ref presence);
        }

        private void GetNintendoNetwork()
        {
            string text1 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x4C));
            string text2 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x50));
            string text3 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x54));
            string text4 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x58));
            string text5 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x5C));
            string text6 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x60));
            string text7 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x64));
            string text8 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x68));
            string text9 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x68));
            nintendoNetwork = text1 + text2 + text3 + text4 + text5 + text6 + text7 + text8 + text9;
        }

        private void activateTheCode_Click(object sender, EventArgs e)
        {
            if (codeText.Text != "")
            {
                codesList.Clear();
                MamiesModGecko.addCodeToCodesList(codesList, codeText.Text);
                MamiesModGecko.enableCodes(codesList);
            }
        }
        #endregion

        #region Credits
        private void ntgamesChannelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/c/nt-games-ytb");
        }

        private void daidoChannelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCXRPjFwZ_IBuRsbiJ5GlXdg");
        }
        #endregion

        #region Load and Save
        private void loadCode_Click(object sender, EventArgs e)
        {

        }

        private void saveCode_Click(object sender, EventArgs e)
        {

        }

        private void loadTag_Click(object sender, EventArgs e)
        {

        }

        private void saveTag_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
